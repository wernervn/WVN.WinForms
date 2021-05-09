using System.IO;
using System.Windows.Forms;

namespace WVN.WinForms.Extensions
{
    public static class WinFormExtensions
    {
        public static void ResetLastPosition(this Form form)
        {
            if (File.Exists("formLayout.json"))
            {
                var layout = File.ReadAllText("formLayout.json").FromJson<WindowSettings>();
                if (layout.WindowState == FormWindowState.Normal)
                {
                    form.Location = layout.Location;
                    form.Size = layout.Size;
                    return;
                }
                form.WindowState = layout.WindowState;
            }
        }

        public static void SaveLastPosition(this Form form)
        {
            WindowSettings layout;
            if (File.Exists("formLayout.json"))
            {
                layout = File.ReadAllText("formLayout.json").FromJson<WindowSettings>();
            }
            else
            {
                layout = new WindowSettings();
            }

            layout.WindowState = form.WindowState;
            if (form.WindowState == FormWindowState.Normal)
            {
                layout.Location = form.Location;
                layout.Size = form.Size;
            }
            File.WriteAllText("formLayout.json", layout.ToJson());
        }
    }
}
