namespace WVN.WinForms.Utils;

#pragma warning disable S3881 // "IDisposable" should be implemented correctly
public class CCursor : IDisposable
#pragma warning restore S3881 // "IDisposable" should be implemented correctly
{
    private readonly Cursor saved;

    public CCursor(Cursor newCursor)
    {
        saved = Cursor.Current!;

        Cursor.Current = newCursor;
    }

    public void Dispose()
    {
        Cursor.Current = saved;
    }
}
