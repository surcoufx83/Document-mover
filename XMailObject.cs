using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Document_mover
{
    class XMailObject
    {

        public string Id { get; private set; }
        private DirectoryInfo dir;

        private XmlDocument xml;
        public string From { get; private set; }
        public string Subject { get; private set; }


        public XMailObject(string id, DirectoryInfo path)
        {
            this.Id = id;
            dir = path;
            xml = new XmlDocument();
            xml.Load(Path.Combine(path.FullName, "Mail.ind.xml"));
            From = xml.DocumentElement.SelectSingleNode("/Root/From/Address/MailAddress").InnerText;
            Subject = xml.DocumentElement.SelectSingleNode("/Root/Subject").InnerText;
        }

        public FileInfo GetPreviewFile()
        {
            DirectoryInfo[] origs = dir.GetDirectories("original");
            FileInfo[] files;
            if (origs.Length == 1)
            {
                files = origs[0].GetFiles("*.pdf");
                if (files.Length == 1)
                    return files[0];
            }
            files = dir.GetFiles("MailBody.html");
            if (files.Length == 0)
                files = dir.GetFiles("MailBody.txt");
            if (files.Length == 0)
                files = dir.GetFiles("MailBody.tif");
            return files[0];
        }

        public FileInfo[] GetFiles()
        {
            FileInfo[] tempfiles;
            List<FileInfo> files = new List<FileInfo>();

            tempfiles = dir.GetFiles("MailBody.html");
            if (tempfiles.Length == 0)
                tempfiles = dir.GetFiles("MailBody.txt");
            if (tempfiles.Length == 0)
                tempfiles = dir.GetFiles("MailBody.tif");
            if (tempfiles.Length > 0)
                files.Add(tempfiles[0]);

            DirectoryInfo[] origs = dir.GetDirectories("original");
            if (origs.Length == 1)
            {
                tempfiles = origs[0].GetFiles();
                foreach (FileInfo file in tempfiles)
                {
                    if (file.Name != "OrgMail.txt")
                        files.Add(file);
                }
            }
            return files.ToArray();
        }

        public void Remove()
        {
            DirectoryInfo signaldir = dir.Parent.Parent.GetDirectories("signal")[0];
            FileInfo[] signals = signaldir.GetFiles(Id + ".*");
            foreach (FileInfo signal in signals)
            {
                signal.Delete();
            }
            dir.Delete(true);
        }

    }
}
