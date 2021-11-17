using OsuMapDownloader.settings;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OsuMapDownloader
{
    public class KeyboardHandler
    {
        private LowLevelKeyboardHook hook;

        public KeyboardHandler()
        {
            hook = new LowLevelKeyboardHook();
            hook.OnKeyPressed += hook_OnKeyPressed;
            hook.OnKeyUnpressed += hook_OnKeyUnpressed;
            hook.HookKeyboard();
        }

        private bool LCTRL_key_pressed, ALT_key_pressed;
        private bool I_key_pressed, T_key_pressed;


        private void hook_OnKeyPressed(object sender, Keys e)
        { 
            if (e == Keys.LControlKey)
            {
                LCTRL_key_pressed = true;
            }
            if (e == Keys.Alt)
            {
                ALT_key_pressed = true;
            }
            if (e == Keys.I)
            {
                I_key_pressed = true;
            }
            if (e == Keys.T)
            {
                T_key_pressed = true;
            }
            CheckKeyCombo();
        }

        private void hook_OnKeyUnpressed(object sender, Keys e)
        {
            if (e == Keys.LControlKey)
            {
                LCTRL_key_pressed = false;
            }
            if (e == Keys.Alt)
            {
                ALT_key_pressed = false;
            }
            if (e == Keys.I)
            {
                I_key_pressed = false;
            } else if (e == Keys.T)
            {
                T_key_pressed = false;
            }
        }

        private void CheckKeyCombo()
        {
            if (LCTRL_key_pressed && ALT_key_pressed)
            {
                if (I_key_pressed) //import hotkey
                {
                    Console.WriteLine("Test");
                    FileInfo[] files = new DirectoryInfo($"./temp/").GetFiles();

                    foreach (FileInfo file in files)
                    {
                        if (file.Extension == ".osz")
                            Process.Start(file.FullName);
                    }
                }
                if (T_key_pressed) //open settings hotkey
                {
                    new SettingsForm().ShowDialog();
                }
            }
        }
    }
}
