using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace OsuMapDownloader.settings
{
    public static class Settings
    {
        private static SettingsData cached;

        private static readonly string path = "./settings.json";

        public static SettingsData data
        {
            get
            {
                if (cached != null)
                {
                    return cached;
                }

                if (!File.Exists(path))
                {
                    cached = new SettingsData();

                    Save();
                }
                else
                {
                    Load();
                }

                return cached;
            }
        }

        public static void Save()
        {
            File.WriteAllText(path, cached.ToJson());
        }
        public static void Load()
        {
            cached = JsonConvert.DeserializeObject<SettingsData>(File.ReadAllText(path));
        }
    }

    [Serializable]
    public class SettingsData
    {

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public bool AutoImport = true;
    }
}
