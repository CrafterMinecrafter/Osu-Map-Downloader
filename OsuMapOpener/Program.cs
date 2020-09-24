using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace OsuMapOpener
{
    class Program
    {
        static string OsuPath;
        static string DownloadsPath;
        static int UpdateInterval;
        static void Main()
        {
            Console.WriteLine("Loading Settings...");
            #region Loading Settings
            try
            {
                OsuPath = File.ReadAllText("./Settings/PathToOsu!.txt");
                DownloadsPath = File.ReadAllText("./Settings/PathToDownloads.txt");
                UpdateInterval = Convert.ToInt32(File.ReadAllText("./Settings/MS_UpdateInterval.txt"));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to load Settings, Error:\n" + ex.Message);
            }
            finally { }
            #endregion
            Console.WriteLine("Loaded!");
            Console.WriteLine("Starting map checker");
            for (; ; )
            {
                Thread.Sleep(UpdateInterval);
                FindAndOpenMaps();
            }
        }
        static void FindAndOpenMaps()
        {
            string[] files = Directory.GetFiles(DownloadsPath);
            for (int i = files.Length - 1; i >= 0; i--)
            {
                if (files[i].EndsWith(".osz"))
                {
                    Process.Start(OsuPath, files[i]);
                    Console.WriteLine("opening: " + Path.GetFileNameWithoutExtension(files[i]));
                }
            }
        }

    }
}
