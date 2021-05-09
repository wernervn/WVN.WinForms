using System;
using System.Drawing;
using System.Windows.Forms;

namespace WVN.WinForms.Extensions
{
    public static class ControlExtensions
    {
        public static void HideDuringAction(this Control control, Action action)
        {
            control.Hide();
            control.SuspendLayoutDuringAction(action);
            control.Show();
        }

        public static void SuspendLayoutDuringAction(this Control control, Action action)
        {
            control.SuspendLayout();
            action();
            control.ResumeLayout();
        }

        public static void MoveControl(this Control control, Rectangle rect)
        {
            control.Location = rect.Location;
            control.Size = rect.Size;
        }
    }
}
