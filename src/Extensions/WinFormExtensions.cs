using System.Drawing;
using System.Windows.Forms;

namespace WVN.WinForms.Extensions
{
    public static class WinFormExtensions
    {
        private static readonly Size NullSize = new(0, 0);
        private static readonly Point NullLocation = new(0, 0);

        public static void SetWindowState(this Form form, WindowState state)
        {
            if (state.FormWindowState == FormWindowState.Normal)
            {
                if (state.Location != NullLocation && state.Location.X >= 0 && state.Location.Y >= 0)
                {
                    form.Location = state.Location;
                }

                if (state.Size != NullSize)
                {
                    form.Size = state.Size;
                }

                return;
            }
            form.WindowState = state.FormWindowState;
        }

        public static WindowState GetWindowState(this Form form)
        {
            WindowState state = new() { FormWindowState = form.WindowState };
            if (form.WindowState == FormWindowState.Normal)
            {
                state.Location = form.Location;
                state.Size = form.Size;
            }
            return state;
        }
    }
}
