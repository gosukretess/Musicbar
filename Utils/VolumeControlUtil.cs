using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;

namespace Musicbar.Utils
{
    public class VolumeControlUtil
    {
        private Window window;
        private const int APPCOMMAND_VOLUME_MUTE = 0x80000;
        private const int APPCOMMAND_VOLUME_UP = 0xA0000;
        private const int APPCOMMAND_VOLUME_DOWN = 0x90000;
        private const int WM_APPCOMMAND = 0x319;

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessageW(IntPtr hWnd, int Msg,
            IntPtr wParam, IntPtr lParam);

        public VolumeControlUtil(System.Windows.Window window)
        {
            this.window = window;
        }

        public void Mute()
        {
            var handle = new WindowInteropHelper(window).Handle;
            SendMessageW(handle, WM_APPCOMMAND, handle,
                (IntPtr)APPCOMMAND_VOLUME_MUTE);
        }

        public void VolDown()
        {
            var handle = new WindowInteropHelper(window).Handle;
            SendMessageW(handle, WM_APPCOMMAND, handle,
                (IntPtr)APPCOMMAND_VOLUME_DOWN);
        }

        public void VolUp()
        {
            var handle = new WindowInteropHelper(window).Handle;
            SendMessageW(handle, WM_APPCOMMAND, handle,
                (IntPtr)APPCOMMAND_VOLUME_UP);
        }
    }
}