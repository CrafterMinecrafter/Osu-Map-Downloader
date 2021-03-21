using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace OsuMapOpener
{
    class Program
    {
        static string OsuPath;
        static string DownloadsPath;

        public static Thread threadForWait
        {
            get => new Thread(FindAndOpenBeatmap);
        }

        static async Task Main(string[] args)
        {
            Console.WriteLine("Loading Settings...");
            #region Loading Settings
            try
            {
                OsuPath = File.ReadAllText("./Settings/PathToOsu!.txt");
                DownloadsPath = File.ReadAllText("./Settings/PathToDownloads.txt");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to load Settings, Error:\n" + ex.Message);
            }
            #endregion
            Console.WriteLine("Loaded!");
            Console.WriteLine("Starting server...");
            await Server.Start();
        }
        private static string[] FindBeatmap(string mapID)
        {
            return Directory.GetFiles(DownloadsPath).Where(e => Regex.Match(e, mapID + " .+.osz$").Success).ToArray();
        }
        public static void FindAndOpenBeatmap(object MapID)
        {
            string[] files = FindBeatmap((string)MapID);
            while (files.Length == 0)
            {
                Thread.Sleep(200);
                if (Server.StopAllChecks)
                {
                    Server.StopAllChecks = false;
                    break;
                }
                Console.WriteLine("waiting for beatmap downloading: " + (string)MapID);
                files = FindBeatmap((string)MapID);
            }
            string beatmap = files.FirstOrDefault();
            if (beatmap == null)
            {
                Console.WriteLine("import beatmap failed");
                Thread.CurrentThread.Abort();
                return;
            }
            Process.Start(OsuPath, beatmap);
            Console.WriteLine("importing: " + Path.GetFileNameWithoutExtension(beatmap));
            Thread.CurrentThread.Abort();
        }
    }
}
