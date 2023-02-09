namespace WVN.WinForms;
[Serializable]
public class WindowState
{
    public Point Location { get; set; }
    public Size Size { get; set; }
    public FormWindowState FormWindowState { get; set; }
}
