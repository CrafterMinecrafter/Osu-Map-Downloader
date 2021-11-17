using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Input;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using OsuMapDownloader.settings;

namespace OsuMapDownloader
{
    class Program
    {

        private static Server httpServer;

        //private static Thread settingsFormThread;

        private static WebClient web = null;


        public static Thread threadForWait
        {
            get => new Thread(DownloadAndOpenBeatmap);
        }
        static async Task Main(string[] args)
        {
            
            Console.WriteLine("Welcome to Osu Map Downloader.\nVERSION: " + Application.ProductVersion + "\n\n\n");

            //Console.WriteLine("To Import downloaded beatmaps use hotkey {ctrl+alt+i}");
            //Console.WriteLine("and you can turn AutoImport in settings");
            //Console.WriteLine("To open settings use hotkey {ctrl+alt+t}\n\n\n");
            Console.WriteLine("Loading Settings...");
            _ = Settings.data.ToJson();
            Console.WriteLine("Loaded.");

            Console.WriteLine("Starting server...");

            /*settingsFormThread = new Thread(() =>
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                Application.Run(new SettingsForm());
            });
            settingsFormThread.Start();*/

            httpServer = new Server();
            await httpServer.Start();
        }


        private static void DownloadAndOpenBeatmap(object mapID)
        {
            if (web == null) web = new WebClient();

            string path = new DirectoryInfo($"./temp/{(string)mapID}.osz").FullName;

            Console.WriteLine($"Downloading beatmap with ID:{((string)mapID)}");
            web.DownloadFileAsync(new Uri($"https://api.chimu.moe/v1/download/{(string)mapID}?n=1"), path);

            web.DownloadFileCompleted += (object sender, System.ComponentModel.AsyncCompletedEventArgs e) =>
            {
                Console.WriteLine("Downloading done!");

                if (Settings.data.AutoImport)
                {
                    Console.WriteLine($"Importing ...");
                    Process.Start(path);
                    Console.WriteLine($"Done!");
                }
            };

        }

    }
}