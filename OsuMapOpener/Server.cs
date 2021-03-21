using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace OsuMapOpener
{
    class Server
    {
        /// <summary> 
        /// Stops the Program.FindAndOpenBeatmap method
        /// </summary>
        public static bool StopAllChecks = false;

        public static async Task Start()
        {
            HttpListener listener = new HttpListener();
            listener.Prefixes.Add("http://localhost:9524/OsuMapOpener/");
            listener.Start();
            Console.WriteLine("Server started!");
            for (; ; )
            {
                byte[] content = null;
                var context = await listener.GetContextAsync();
                try
                {
                    switch (context.Request.QueryString["f"])
                    {
                        case "1":
                            {
                                string mapID = context.Request.QueryString["MapID"];
                                if (mapID != "")
                                {
                                    content = Encoding.ASCII.GetBytes("Ok\nWaiting started\nmapID:" + mapID);
                                    Program.threadForWait.Start(mapID);
                                }
                                else
                                {
                                    content = Encoding.ASCII.GetBytes("what?");
                                }

                                break;
                            }
                        case "2":
                            {
                                content = Encoding.ASCII.GetBytes("ok\nChecks stopped");
                                StopAllChecks = true;
                                break;
                            }
                        default:
                            {
                                content = Encoding.ASCII.GetBytes("what?");
                                break;
                            }
                    }
                }
                catch (Exception ex)
                {
                    content = Encoding.ASCII.GetBytes(ex.ToString());
                }
                var stream = context.Response.OutputStream;
                stream.Write(content, 0, content.Length);
                stream.Close();
            }
        }
    }
}
