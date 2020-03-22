﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WindowsInput.Native;

namespace RapidSynthesis
{
    class HotkeyContainer
    {
        public bool AcceptingInputs { get; set; } = false;
        public HashSet<Key> ActiveNonModKeys { get; set; } = new HashSet<Key>();
        // Key vaues:
        public Key LastPressedKey { get; set; } = Key.None;
        public HashSet<Key> ActiveModKeys { get; set; } = new HashSet<Key>();
        
        public HotkeyContainer() { }
        public HotkeyContainer(Key pressedKey, HashSet<Key> modKeys)
        {
            LastPressedKey = pressedKey;
            ActiveModKeys = modKeys;
        }

        public VirtualKeyCode[] ModKeys()
        {
            return ActiveModKeys.Select((k) => HotkeyProcessor.GetVKCFromKeyCode(k)).ToArray();
        }
        public VirtualKeyCode Keys()
        {
            return HotkeyProcessor.GetVKCFromKeyCode(LastPressedKey);
        }
    }
}
