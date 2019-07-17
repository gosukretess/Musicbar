using System;
using System.Runtime.InteropServices;
using Musicbar.Models;

namespace Musicbar.Services
{
    public class PlaybackControlUtil
    {
        [DllImport("user32.dll")]
        private static extern void keybd_event(byte virtualKey, byte scanCode, uint flags, IntPtr extraInfo);

        private const int VK_MEDIA_NEXT_TRACK = 0xB0;
        private const int VK_MEDIA_PLAY_PAUSE = 0xB3;
        private const int VK_MEDIA_PREV_TRACK = 0xB1;

        public void ControlPlayback(ControlAction action)
        {
            keybd_event(ControlActionToWindowsButtonId(action), 0, 1, IntPtr.Zero);
        }

        private byte ControlActionToWindowsButtonId(ControlAction action)
        {
            switch (action)
            {
                case ControlAction.Prev:
                    return VK_MEDIA_PREV_TRACK;
                case ControlAction.Play:
                    return VK_MEDIA_PLAY_PAUSE;
                case ControlAction.Next:
                    return VK_MEDIA_NEXT_TRACK;
                default:
                    return VK_MEDIA_PLAY_PAUSE;
            }
        }
    }
}