﻿using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;
using System.Threading.Tasks;
using DolphinScript.Lib.Backend;
using System.Collections.Generic;
using DolphinScript.Lib.ScriptEventClasses;
using static DolphinScript.Lib.Backend.WinAPI;
using System.Runtime.InteropServices;

namespace SmiteMixerCodeGrabberGUI.Classes
{
    static class DynamicResolution
    {        
        public static List<ScriptEvent> GetRedeemLoop(string code)
        {
            if(Properties.Settings.Default.UseSlowTyping)
            {
                List<ScriptEvent> SlowTypingScript = new List<ScriptEvent>()
                {
                    new MouseMoveToAreaOnWindow() { ClickArea = new RECT(), WindowToClickTitle = Properties.Settings.Default.smiteWindowTitle },
                    GetPause(1.0, 1.5),
                    GetEnterKeyClick(),
                    GetPause(1.0, 1.5)
                };
                var fullcode = "/claimpromotion " + code;
                foreach (var letter in fullcode)
                {
                    SlowTypingScript.Add(new KeyboardKeyPress() { KeyboardKeys = letter.ToString() });
                    SlowTypingScript.Add(GetPause(0.1, 0.3));
                }
                SlowTypingScript.Add(GetPause(0.3, 0.5));
                GetEnterKeyClick();
                SlowTypingScript.Add(GetPause(1.0, 1.5));
                GetESCKeyClick();
                return SlowTypingScript;
            }
            else
            {
                return new List<ScriptEvent>()
                {
                    new MouseMoveToAreaOnWindow() { ClickArea = new RECT(), WindowToClickTitle = Properties.Settings.Default.smiteWindowTitle },
                    GetPause(1.0, 1.5),
                    GetEnterKeyClick(),
                    GetPause(1.0, 1.5),
                    new KeyboardKeyPress() { KeyboardKeys = "/claimpromotion " + code },
                    GetPause(0.3, 0.5),
                    GetEnterKeyClick(),
                    GetPause(1.0, 1.5),
                    GetESCKeyClick()
                };
            }
        }

        static MoveWindowToFront GetMoveWindowToFront()
        {
            return new MoveWindowToFront() { WindowToClickTitle = Properties.Settings.Default.smiteWindowTitle };
        }

        static RandomPauseInRange GetPause(double min, double max)
        {
            return new RandomPauseInRange() { DelayMaximum = max, DelayMinimum = min };
        }

        static MouseMoveToAreaOnWindow GetMouseMoveToWindow(WinAPI.RECT clickArea)
        {
            return new MouseMoveToAreaOnWindow() { ClickArea = clickArea, WindowToClickTitle = Properties.Settings.Default.smiteWindowTitle };
        }

        static MouseClick GetLeftMouseClick()
        {
            return new MouseClick() { MouseButton = VirtualMouseStates.Left_Click };
        }

        static DolphinScript.Classes.ScriptEventClasses.KeybdEvent GetEnterKeyClick()
        {
            return new DolphinScript.Classes.ScriptEventClasses.KeybdEvent() { KeybdEventBtn = VirtualKeyStates.VK_RETURN };
        }

        static DolphinScript.Classes.ScriptEventClasses.KeybdEvent GetESCKeyClick()
        {
            return new DolphinScript.Classes.ScriptEventClasses.KeybdEvent() { KeybdEventBtn = VirtualKeyStates.VK_ESCAPE };
        }
    }
}
