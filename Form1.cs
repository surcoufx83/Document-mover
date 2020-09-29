using Serilog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CefSharp;
using CefSharp.WinForms;
using System.Text.RegularExpressions;

namespace Document_mover
{
    public partial class MainForm : Form
    {

        string[] plainSources;
        string[] mailSources;
        string logFile;
        string trashFolder;
        string trashDataFile;
        ChromiumWebBrowser browser;
        ChromiumWebBrowser browser2;
        SortedList<string, string> destinations;
        SortedList<string, XMailObject> mailcache;
        FileMover mover = new FileMover();

        Control selectedButton;
        string compiledFilename = "";
        string selectedDestinationKey = "";
        DirectoryInfo selectedDestination;
        FileInfo selectedFile;
        XMailObject selectedMail;
        bool selectedPlainFile = false;
        bool selectedMailFile = false;
        string selectedFolder = "";

        public MainForm()
        {
            InitializeComponent();
            InitSettings();
            InitEvents();
            if (logFile != null)
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.File(logFile)
                .CreateLogger();
            LogInformation("Application started.");
            ScanSources();
        }

        private void InitSettings()
        {

            plainSources = new string[] { "Z:\\documents\\xScanInput" };
            mailSources = new string[] { "Z:\\documents\\xEMailinput" };
            trashFolder = "Z:\\documents\\xTrash";
            trashDataFile = "Z:\\documents\\xTrash\\recycle.log";
            logFile = "Z:\\documents\\xTrash\\mover.log";

            destinations = new SortedList<string, string>();
            destinations.Add("Elias", "Z:\\documents\\Elias");
            destinations.Add("Stefan", "Z:\\documents\\Stefan");
            destinations.Add("Wissenswertes", "Z:\\documents\\Wissenswertes");

            foreach (string key in destinations.Keys)
            {
                DestinationKeyList.Items.Add(key);
            }

            browser = new ChromiumWebBrowser("about:blank")
            {
                Dock = DockStyle.Fill
            };
            browser2 = new ChromiumWebBrowser("about:blank")
            {
                Dock = DockStyle.Fill
            };
            splitContainer3.Panel1.Controls.Add(browser);
            splitContainer3.Panel2.Controls.Add(browser2);

        }

        private void InitEvents()
        {
            mover.BeforeFileCopy += Mover_BeforeFileCopy;
            mover.BeforeFileDelete += Mover_BeforeFileDelete;
            mover.BeforeFileMove += Mover_BeforeFileMove;
            mover.FileCopied += Mover_FileCopied;
            mover.FileDeleted += Mover_FileDeleted;
            mover.FileMoved += Mover_FileMoved;
            mover.FileCopyFailed += Mover_FileCopyFailed;
            mover.FileDeleteFailed += Mover_FileDeleteFailed;
            mover.FileMoveFailed += Mover_FileMoveFailed;
        }

        private void LogInformation(string message)
        {
            if (logFile != null)
                Log.Information(message);
        }

        private void LogVerbose(string message)
        {
            if (logFile != null)
                Log.Verbose(message);
        }

        private void LogVerbose(string message, string item1)
        {
            if (logFile != null)
                Log.Verbose(message, item1);
        }

        private void LogVerbose(string message, string item1, string item2)
        {
            if (logFile != null)
                Log.Verbose(message, item1, item2);
        }

        private void LogWarning(string message)
        {
            if (logFile != null)
                Log.Warning(message);
        }

        private void LogWarning(string message, string item1)
        {
            if (logFile != null)
                Log.Warning(message, item1);
        }

        private void LogError(Exception ex, string message, string item1)
        {
            if (logFile != null)
                Log.Error(ex, message, item1);
        }

        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            LogInformation("Application exiting.");
            Application.Exit();
        }

        private void ScanSources()
        {
            FileListFlow.Controls.Clear();
            mailcache = new SortedList<string, XMailObject>();
            int items = 0;
            Int64 size = 0;
            if (plainSources.Length != 0)
                ScanPlainSources(ref items, ref size);
            if (mailSources.Length != 0)
                ScanMailSources(ref items, ref size);
        }

        private void Scan__AddPlainItem(FileInfo file, ref int items, ref Int64 size)
        {
            LogVerbose("Found file {file}.", file.FullName);
            Control c = new Button
            {
                FlatStyle = FlatStyle.Popup,
                Size = new Size(160, 64),
                Tag = "plain@" + file.FullName,
                Text = file.Name,
                TextAlign = ContentAlignment.MiddleCenter
            };
            c.Click += OnFileButtonClick;
            FileListFlow.Controls.Add(c);
        }

        private void Scan__AddMailItem(DirectoryInfo mail, ref int items, ref Int64 size)
        {
            LogVerbose("Found mail {mail}.", mail.FullName);
            mailcache.Add(mail.Name, new XMailObject(mail.Name, mail));
            XMailObject mailObject = mailcache[mail.Name];
            Control c = new Button
            {
                FlatStyle = FlatStyle.Popup,
                Size = new Size(160, 64),
                Tag = "mail@" + mail.Name,
                Text = mailObject.From + ": " + mailObject.Subject,
                TextAlign = ContentAlignment.MiddleCenter
            };
            c.Click += OnFileButtonClick;
            FileListFlow.Controls.Add(c);
        }

        private void ScanPlainSources(ref int items, ref Int64 size)
        {
            for (int i=0; i<plainSources.Length; i++)
            {
                DirectoryInfo di = new DirectoryInfo(plainSources[i]);
                if (!di.Exists)
                {
                    LogWarning("Source plain folder {dir} does not exist.", plainSources[i]);
                    continue;
                }
                ScanPlainSources_Folder(di, ref items, ref size);
            }
        }

        private void ScanPlainSources_Folder(DirectoryInfo dir, ref int items, ref Int64 size)
        {
            DirectoryInfo[] dirs = dir.GetDirectories();
            foreach (DirectoryInfo subdir in dirs)
            {
                if (subdir.Name.StartsWith("."))
                    continue;
                ScanPlainSources_Folder(subdir, ref items, ref size);
            }
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                Scan__AddPlainItem(file, ref items, ref size);
            }
        }

        private void ScanMailSources(ref int items, ref Int64 size)
        {
            for (int i = 0; i < mailSources.Length; i++)
            {
                DirectoryInfo di = new DirectoryInfo(mailSources[i]);
                if (!di.Exists)
                {
                    LogWarning("Source mail folder {dir} does not exist.", mailSources[i]);
                    continue;
                }
                DirectoryInfo[] subdirs = di.GetDirectories("data");
                if (subdirs.Length != 1)
                {
                    LogWarning("Source mail folder {dir} does not contain a data dir.", mailSources[i]);
                    continue;
                }
                ScanMailSources_Folder(subdirs[0], ref items, ref size);
            }
        }

        private void ScanMailSources_Folder(DirectoryInfo dir, ref int items, ref Int64 size)
        {
            DirectoryInfo[] dirs = dir.GetDirectories("Mail*");
            foreach (DirectoryInfo subdir in dirs)
            {
                Scan__AddMailItem(subdir, ref items, ref size);
            }
        }

        private void OnFileButtonClick(object sender, EventArgs e)
        {
            selectedButton = (Control)sender;
            string tag = (string)selectedButton.Tag;
            LogVerbose("User clicked button for file {file}.", tag);
            selectedPlainFile = tag.StartsWith("plain");
            selectedMailFile = tag.StartsWith("mail");
            tag = tag.Substring(tag.IndexOf("@") + 1);
            string tagfile = "";
            if (tag.Contains("@"))
            {
                tagfile = tag.Substring(tag.IndexOf("@") + 1);
                tag = tag.Substring(0, tag.IndexOf("@"));
            }
            if (selectedPlainFile)
            {
                selectedFile = new FileInfo(tag);
                selectedMail = null;
                splitContainer4.Panel2Collapsed = true;
                if (!selectedFile.Exists)
                {
                    LogWarning("File no longer exists");
                    MessageBox.Show("The file no longer exists. Maybe it has already been deleted by someone else.");
                    FileListFlow.Controls.Remove(selectedButton);
                    return;
                }
            } else if (selectedMailFile)
            {
                selectedFile = null;
                if (!mailcache.ContainsKey(tag))
                {
                    LogWarning("Mail not in cache");
                    MessageBox.Show("The file can't be found in cache.");
                    FileListFlow.Controls.Remove(selectedButton);
                    return;
                }
                selectedMail = mailcache[tag];
                if (tagfile != "")
                    selectedFile = new FileInfo(tagfile);
                else
                    selectedFile = selectedMail.GetPreviewFile();
                if (!selectedFile.Exists)
                {
                    LogWarning("File no longer exists");
                    MessageBox.Show("The file no longer exists. Maybe it has already been deleted by someone else.");
                    FileListFlow.Controls.Remove(selectedButton);
                    return;
                }
                splitContainer4.Panel2Collapsed = false;
                splitContainer4.SplitterDistance = splitContainer4.Height - 100;
                OnFileButtonClick__SetMailFiles(selectedMail);
            }
            OnFileButtonClick__SetPreview();
            OnFileButtonClick__SetFields();
        }

        private void OnFileButtonClick__SetPreview()
        {
            if (selectedFile == null && selectedMail == null)
                browser.Load("about:blank");
            try
            {
                browser.Load("file://" + selectedFile.FullName);
            } catch(Exception ex)
            {
                LogError(ex, "Error loading preview for file {file}.", selectedFile.FullName);
            }
        }

        private void OnFileButtonClick__SetMailFiles(XMailObject mail)
        {
            MailFilesFlow.Controls.Clear();
            FileInfo[] files = mail.GetFiles();
            foreach (FileInfo file in files)
            {
                Control c = new Button
                {
                    FlatStyle = FlatStyle.Popup,
                    Size = new Size(160, 64),
                    Tag = "mail@" + mail.Id + "@" + file.FullName,
                    Text = file.Name,
                    TextAlign = ContentAlignment.MiddleCenter
                };
                c.Click += OnFileButtonClick;
                MailFilesFlow.Controls.Add(c);
            }
            
        }

        private void OnFileButtonClick__SetFields()
        {
            if (selectedFile != null)
            {
                string extension = selectedFile.Extension.ToLower();
                ExtensionTextbox.Text = extension;
            }
            if (compiledFilename != "")
            {
                FileInfo fi = new FileInfo(compiledFilename);
                if (fi.Exists)
                {
                    CopyFileButton.Visible = false;
                    MoveFileButton.Visible = false;
                    FileExistsLabel.Visible = true;
                    DeleteExistingFileButton.Visible = true;
                    if (splitContainer3.Panel2Collapsed == true)
                    {
                        splitContainer3.Panel2Collapsed = false;
                        splitContainer3.SplitterDistance = splitContainer3.Height / 2;
                    }
                    browser2.Load("file://" + compiledFilename);
                }
                else
                {
                    CopyFileButton.Visible = true;
                    MoveFileButton.Visible = true;
                    FileExistsLabel.Visible = false;
                    DeleteExistingFileButton.Visible = false;
                    if (splitContainer3.Panel2Collapsed == false)
                        splitContainer3.Panel2Collapsed = true;
                }
            } else
            {
                CopyFileButton.Visible = false;
                DeleteExistingFileButton.Visible = false;
                DeleteMailButton.Visible = false;
                DeleteSourceFileButton.Visible = false;
                FileExistsLabel.Visible = false;
                MoveFileButton.Visible = false;
                if (splitContainer3.Panel2Collapsed == false)
                    splitContainer3.Panel2Collapsed = true;
            }
            DeleteMailButton.Visible = selectedMailFile;
            DeleteSourceFileButton.Visible = !selectedMailFile;
        }

        private void Mover_BeforeFileCopy(object sender, EventArgs e)
        {
            
        }

        private void Mover_BeforeFileDelete(object sender, FileDeleteEventArgs e)
        {
            
        }

        private void Mover_BeforeFileMove(object sender, EventArgs e)
        {
            
        }

        private void Mover_FileCopied(object sender, EventArgs e)
        {
            
        }

        private void Mover_FileDeleted(object sender, FileDeleteEventArgs e)
        {
            
        }

        private void Mover_FileMoved(object sender, EventArgs e)
        {
            
        }

        private void Mover_FileCopyFailed(object sender, EventArgs e)
        {
            
        }

        private void Mover_FileDeleteFailed(object sender, FileDeleteEventArgs e)
        {
            
        }

        private void Mover_FileMoveFailed(object sender, EventArgs e)
        {

        }

        private void DatetimeCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            UpdateFilename();
        }

        private void DatetimePicker_ValueChanged(object sender, EventArgs e)
        {
            UpdateFilename();
        }

        private void FilenameTextbox1_TextChanged(object sender, EventArgs e)
        {
            UpdateFilename();
        }

        private void FilenameTextbox1_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateFilename();
        }

        private void FilenameTextbox2_TextChanged(object sender, EventArgs e)
        {
            UpdateFilename();
        }

        private void FilenameTextbox2_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateFilename();
        }

        private void DestinationKeyList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox box = (ListBox)sender;
            if (box.SelectedIndex > 0)
            {
                string key = (string)box.SelectedItem;
                LogVerbose("User selected destination {index} / {name}.", box.SelectedIndex.ToString(), key);
                if (destinations.ContainsKey(key))
                {
                    DestinationKeyList_SelectedIndexChanged_InitFilebrowser(key, destinations[key]);
                }
            }
        }

        private void DestinationKeyList_SelectedIndexChanged_InitFilebrowser(string key, string destination)
        {
            if (key == selectedDestinationKey)
                return;
            selectedDestinationKey = key;
            DirectoryInfo di = new DirectoryInfo(destination);
            selectedDestination = di;
            if (!di.Exists)
            {
                LogWarning("Selected destination no longer exists");
                MessageBox.Show("The destination does not exist!!!");
                return;
            }
            folderBrowserDialog1.SelectedPath = di.FullName;
            DestinationFolderLabel.Text = di.FullName;
            UpdateFilename();
        }

        private void DestinationFolderLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult dr = folderBrowserDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                DestinationFolderLabel.Text = folderBrowserDialog1.SelectedPath;
                selectedDestination = new DirectoryInfo(folderBrowserDialog1.SelectedPath);
                UpdateFilename();
            }
        }

        private void UpdateFilename()
        {
            List<string> pathItems = new List<string>();
            if (selectedDestination == null)
            {
                compiledFilename = "";
                FilenameLabel.Text = compiledFilename;
                OnFileButtonClick__SetFields();
                return;
            }

            if (DatetimeCheckbox.Checked)
                pathItems.Add(DatetimePicker.Value.ToString("yyyy-MM-dd"));
            if (FilenameTextbox1.Text.Trim() != "")
                pathItems.Add(FilenameTextbox1.Text.Trim());
            if (FilenameTextbox2.Text.Trim() != "")
                pathItems.Add(FilenameTextbox2.Text.Trim());

            string path = Path.Combine(selectedDestination.FullName, RemoveIllegalFileNameChars(string.Join(" ", pathItems)) + ExtensionTextbox.Text);
            compiledFilename = path;
            FilenameLabel.Text = compiledFilename;
            OnFileButtonClick__SetFields();

        }

        private static string RemoveIllegalFileNameChars(string input, string replacement = "")
        {
            var regexSearch = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());
            var r = new Regex(string.Format("[{0}]", Regex.Escape(regexSearch)));
            input = r.Replace(input, replacement);
            input = input.Replace("ä", "ae");
            input = input.Replace("Ä", "Ae");
            input = input.Replace("ö", "oe");
            input = input.Replace("Ö", "Oe");
            input = input.Replace("ü", "ue");
            input = input.Replace("Ü", "Ue");
            input = input.Replace("ß", "ss");
            return input;
        }

        private void DeleteExistingFileButton_Click(object sender, EventArgs e)
        {
            FileInfo file = new FileInfo(compiledFilename);
            DialogResult dr = MessageBox.Show("Attention! Please confirm that the file " + file.Name + " can be irrevocably deleted from the folder " + file.Directory.FullName + ".", "Confirmation required", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.Yes)
            {
                if (mover.DeleteFile(file, trashFolder, trashDataFile))
                {
                    UpdateFilename();
                }
            }
        }

        private void CopyFileButton_Click(object sender, EventArgs e)
        {
            FileInfo file = new FileInfo(compiledFilename);
            if (file.Exists || selectedFile == null)
                return;
            if (!mover.CopyFile(selectedFile, file))
                MessageBox.Show("Error copying file...");
        }

        private void MoveFileButton_Click(object sender, EventArgs e)
        {
            FileInfo file = new FileInfo(compiledFilename);
            if (file.Exists || selectedFile == null)
                return;
            if (!mover.MoveFile(selectedFile, file))
            {
                MessageBox.Show("Error moving file...");
                return;
            }
            FileListFlow.Controls.Remove(selectedButton);
            if (FileListFlow.Controls.Count != 0)
            {
                OnFileButtonClick(FileListFlow.Controls[0], EventArgs.Empty);
            }
        }

        private void DeleteSourceFileButton_Click(object sender, EventArgs e)
        {
            FileInfo file = new FileInfo(compiledFilename);
            if (!mover.DeleteFile(selectedFile, trashFolder, trashDataFile))
            {
                MessageBox.Show("Error deleting file...");
                return;
            }
            FileListFlow.Controls.Remove(selectedButton);
            if (FileListFlow.Controls.Count != 0)
            {
                OnFileButtonClick(FileListFlow.Controls[0], EventArgs.Empty);
            }
        }

        private void RescanMenuItem_Click(object sender, EventArgs e)
        {
            ScanSources();
        }

        private void MainForm_ResizeEnd(object sender, EventArgs e)
        {
            splitContainer2.SplitterDistance = splitContainer2.Height - 250;
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            splitContainer2.SplitterDistance = splitContainer2.Height - 250;
        }

        private void DeleteMailButton_Click(object sender, EventArgs e)
        {
            if (selectedMail == null)
                return;
            browser.Load("about:blank");
            selectedMail.Remove();
            FileListFlow.Controls.Remove(selectedButton);
            mailcache.Remove(selectedMail.Id);
            selectedFile = null;
            selectedMail = null;
            if (FileListFlow.Controls.Count != 0)
            {
                OnFileButtonClick(FileListFlow.Controls[0], EventArgs.Empty);
            }
        }
    }
}
