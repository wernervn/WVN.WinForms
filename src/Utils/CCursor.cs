using System;
using System.Windows.Forms;

namespace WVN.WinForms.Utils
{
    public class CCursor : IDisposable
    {
        private readonly Cursor saved;

        public CCursor(Cursor newCursor)
        {
            saved = Cursor.Current;

            Cursor.Current = newCursor;
        }

        public void Dispose()
        {
            Cursor.Current = saved;
        }
    }
}
