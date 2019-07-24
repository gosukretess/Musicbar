using WindowsInput;
using WindowsInput.Native;
using Musicbar.Models;

namespace Musicbar.Utils
{
    public class PlaybackControlUtil
    {
        private readonly InputSimulator inputSimulator;

        public PlaybackControlUtil()
        {
            inputSimulator = new InputSimulator();
        }

        public void ControlPlayback(ControlAction action)
        {
            switch (action)
            {
                case ControlAction.Prev:
                    inputSimulator.Keyboard.KeyDown(VirtualKeyCode.MEDIA_PREV_TRACK);
                    break;
                case ControlAction.Play:
                    inputSimulator.Keyboard.KeyDown(VirtualKeyCode.MEDIA_PLAY_PAUSE);
                    break;
                case ControlAction.Next:
                    inputSimulator.Keyboard.KeyDown(VirtualKeyCode.MEDIA_NEXT_TRACK);
                    break;
            }
        }
    }
}