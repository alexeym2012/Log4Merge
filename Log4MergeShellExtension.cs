using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices.ComTypes;
using System.Collections.Generic;

namespace Log4MergeShellExtension
{
    [ComVisible(true)]
    [Guid("D9B59A76-6F4C-4B07-A3F8-1C5B3D2A5A67")] // your shell extension GUID
    [ClassInterface(ClassInterfaceType.None)]
    public class ShellExtension : IContextMenu, IShellExtInit
    {
        private string[] selectedFiles;

        // Called by Explorer to initialize selected items
        public void Initialize(IntPtr pidlFolder, IntPtr pDataObj, IntPtr hKeyProgID)
        {
            selectedFiles = ShellUtilities.GetSelectedFiles(pDataObj);
        }

        // Add menu item
        public int QueryContextMenu(IntPtr hMenu, uint indexMenu, uint idCmdFirst, uint idCmdLast, uint uFlags)
        {
            if (selectedFiles == null || selectedFiles.Length == 0)
                return 0;

            // Insert a simple menu item; icon is handled via registry
            NativeMethods.InsertMenu(hMenu, indexMenu, 0x0, idCmdFirst, "Open with Log4Merge");
            return 1; // number of items added
        }

        // Called when user clicks the menu
        public void InvokeCommand(IntPtr pici)
        {
            if (selectedFiles == null || selectedFiles.Length == 0)
                return;

            string exePath = Assembly.GetExecutingAssembly().Location;
            if (!File.Exists(exePath))
                return;

            Process.Start(exePath, string.Join(" ", Array.ConvertAll(selectedFiles, f => $"\"{f}\"")));
        }

        // Optional tooltip
        public void GetCommandString(int idCmd, uint uType, IntPtr pReserved, StringBuilder pszName, uint cchMax)
        {
            pszName.Clear();
            pszName.Append("Open all selected files in Log4Merge");
        }
    }

    #region COM Interfaces
    [ComImport]
    [Guid("000214e4-0000-0000-c000-000000000046")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    interface IContextMenu
    {
        [PreserveSig]
        int QueryContextMenu(IntPtr hMenu, uint indexMenu, uint idCmdFirst, uint idCmdLast, uint uFlags);
        void InvokeCommand(IntPtr pici);
        void GetCommandString(int idCmd, uint uType, IntPtr pReserved, StringBuilder pszName, uint cchMax);
    }

    [ComImport]
    [Guid("000214E8-0000-0000-C000-000000000046")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    interface IShellExtInit
    {
        void Initialize(IntPtr pidlFolder, IntPtr pDataObj, IntPtr hKeyProgID);
    }
    #endregion

    internal static class NativeMethods
    {
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        public static extern bool InsertMenu(IntPtr hMenu, uint uPosition, uint uFlags, uint uIDNewItem, string lpNewItem);

        [DllImport("shell32.dll", CharSet = CharSet.Unicode)]
        public static extern uint DragQueryFile(IntPtr hDrop, uint iFile, StringBuilder lpszFile, int cch);

        [DllImport("ole32.dll")]
        public static extern void ReleaseStgMedium(ref STGMEDIUM pmedium);
    }

    internal static class ShellUtilities
    {
        internal enum CLIPFORMAT : short
        {
            CF_HDROP = 15
        }

        public static string[] GetSelectedFiles(IntPtr pDataObj)
        {
            if (pDataObj == IntPtr.Zero)
                return Array.Empty<string>();

            IDataObject dataObject = (IDataObject)Marshal.GetObjectForIUnknown(pDataObj);

            FORMATETC fmt = new FORMATETC
            {
                cfFormat = (short)CLIPFORMAT.CF_HDROP,
                dwAspect = DVASPECT.DVASPECT_CONTENT,
                lindex = -1,
                ptd = IntPtr.Zero,
                tymed = TYMED.TYMED_HGLOBAL
            };

            dataObject.GetData(ref fmt, out STGMEDIUM medium);

            try
            {
                IntPtr hDrop = medium.unionmember;
                uint count = NativeMethods.DragQueryFile(hDrop, 0xFFFFFFFF, null, 0);
                List<string> files = new List<string>();
                StringBuilder sb = new StringBuilder(260);

                for (uint i = 0; i < count; i++)
                {
                    NativeMethods.DragQueryFile(hDrop, i, sb, sb.Capacity);
                    files.Add(sb.ToString());
                    sb.Clear();
                }

                return files.ToArray();
            }
            finally
            {
                NativeMethods.ReleaseStgMedium(ref medium);
            }
        }
    }
}
