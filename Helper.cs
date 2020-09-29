using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Document_mover
{
    static class Helper
    {

        public static int UnixTimestamp
        {
            get { return (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds; }
        }

    }
}
