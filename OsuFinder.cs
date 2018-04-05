using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuUtil
{
    public static class OsuFinder
    {
        public static string TryFindOsuLocation()
        {
            RegistryKey registryKey = Registry.ClassesRoot.OpenSubKey("osu\\shell\\open\\command");

            if (registryKey == null)
                return null;

            string str = registryKey.GetValue("").ToString();

            if (str == null)
                return null;

            string[] strArray = str.Split('"');

            if (strArray.Length < 2)
                return null;

            return Path.GetDirectoryName(strArray[1]);
        }

        public static bool IsValidInstallation(string osuDirectory)
        {
            return File.Exists(osuDirectory + Path.DirectorySeparatorChar + "osu!.exe");
        }
    }
}
