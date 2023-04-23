using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interface1
{
    internal class SettingsDark
    {
        public string intPath = Application.StartupPath + @"\config.ini";
        [DllImport("kernel32", CharSet = CharSet.Auto)]

        private static extern int GetPrivateProfileString(String sectionName, string KeyName, string defaultValue, StringBuilder returnedString, int Size, string fileName);
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(String section, String keyname, string value, string path);

        public StringBuilder sbTheme;
        public string theme { get; set; }

        public void readIni()
        {
            int resultSize;
            sbTheme = new StringBuilder(10);
            resultSize = GetPrivateProfileString("SECTION", "key","",sbTheme,sbTheme.Capacity, intPath);

            this.theme= sbTheme.ToString();
        }

        public void writeIni(string section, string key, string value)
        {
            WritePrivateProfileString(section, key, value, intPath);
        }


    }
}
