using System;
using System.Runtime.InteropServices; 
using System.Drawing; 

namespace FileExplore
{
        public class GetSystemImgList
        {

            [DllImport("Shell32.dll")]
            private static extern int SHGetFileInfo(
                string pszPath, uint dwFileAttributes,
                out SHFILEINFO psfi, uint cbFileInfo,
                SHGFI uFlags);

            [StructLayout(LayoutKind.Sequential)]
            private struct SHFILEINFO
            {
                public IntPtr hIcon;
                public int iIcon;
                public uint dwAttributes;
                [MarshalAs(UnmanagedType.LPStr, SizeConst = 260)]
                public string szDisplayName;
                [MarshalAs(UnmanagedType.LPStr, SizeConst = 80)]
                public string szTypeName;            
            };


            private enum SHGFI
            {
                LargeIcon = 0x00000000,
                SmallIcon = 0x00000001,
                SelectIcon = 0x00000002,
                UseFileAttributes = 0x00000010,
                Icon = 0x00000100,
                DisplayName = 0x00000200,
                Typename = 0x00000400,
                SysIconIndex = 0x00004000,
                LinkOverlay = 0x00008000
            }


            public GetSystemImgList()
            {     
            }

            /// <summary>
            /// ����/���� �̹��� ���
            /// </summary>
            /// <param name="pszPath">����/���� ���</param>
            /// <param name="bBigSmall">ū�̹���/�����̹���</param>
            /// <param name="bSelect">���� �̹���</param>
            /// <returns></returns>
            public Icon GetIcon(String pszPath, bool bBigSmall, bool bSelect)
            {
                SHGFI uFlags;
                SHFILEINFO psfi = new SHFILEINFO();
                int cbFileInfo = Marshal.SizeOf(psfi);               

                if (bBigSmall)
                    uFlags = SHGFI.Icon | SHGFI.SmallIcon;
                else
                    uFlags = SHGFI.Icon | SHGFI.LargeIcon;

                if (bSelect)
                    uFlags = uFlags | SHGFI.SelectIcon;

                // ����/���� ������ ���
                SHGetFileInfo(pszPath, 256, out psfi, (uint)cbFileInfo, uFlags);

                // ������ �������� ��ȯ
                return Icon.FromHandle(psfi.hIcon);
            }
        }
    }

