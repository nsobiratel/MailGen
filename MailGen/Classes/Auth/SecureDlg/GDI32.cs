namespace MailGen.Classes.Auth.SecureDlg
{
    using System;
    using System.Runtime.InteropServices;

    public static class Gdi32
    {
        [DllImport("gdi32.dll", EntryPoint = "DeleteObject")]
        public static extern bool DeleteObject(IntPtr hObject);
    }
}