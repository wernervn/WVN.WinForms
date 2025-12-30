namespace WVN.WinForms.Extensions;

public static class ListViewExtensions
{
    public static void ResizeColumnsAll(this ListView lvw)
    {
        ColumnHeaderAutoResizeStyle resizer = lvw.Items.Count == 0 ?
            ColumnHeaderAutoResizeStyle.HeaderSize :
            ColumnHeaderAutoResizeStyle.ColumnContent;
        lvw.AutoResizeColumns(resizer);
    }
}
