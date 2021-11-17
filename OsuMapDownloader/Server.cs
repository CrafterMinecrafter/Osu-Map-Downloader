using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace OsuMapDownloader
{
    class Server
    {
        public async Task Start()
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
#if DEBUG
                        case "d":
                            {
                                content = DebugRequest();
                                break;
                            }
#endif

                        case "1":
                            {
                                content = DownloadRequest(context.Request.QueryString["MapID"]);
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

        private byte[] DownloadRequest(string mapID)
        {
            byte[] message;
            if (mapID != "")
            {
                message = Encoding.ASCII.GetBytes("Ok\nDownloading started\nmapID:" + mapID);
                Program.threadForWait.Start(mapID);
            }
            else
            {
                message = Encoding.ASCII.GetBytes("what?");
            }

            return message;
        }
#if DEBUG
        private byte[] DebugRequest()
        {
            return Encoding.ASCII.GetBytes(settings.Settings.data.ToJson());
        }

#endif
    }
}
