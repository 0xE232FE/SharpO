using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpO.CSGO
{
    public class Surface : InterfaceBase
    {
        public delegate int DrawSetColorDlg(int r, int g, int b, int a);
        public delegate int DrawLineDlg(int x0, int y0, int x1, int y1);
        public delegate int DrawFilledRectDlg(int x0, int y0, int x1, int y1);

        public DrawSetColorDlg DrawSetColor;
        public DrawLineDlg DrawLine;
        public DrawFilledRectDlg DrawFilledRect;

        public Surface(IntPtr baseAdr) : base(baseAdr)
        {
            DrawSetColor = GetInterfaceFunction<DrawSetColorDlg>(15);
            DrawLine = GetInterfaceFunction<DrawLineDlg>(19);
            DrawFilledRect = GetInterfaceFunction<DrawFilledRectDlg>(16);
        }
    }
}