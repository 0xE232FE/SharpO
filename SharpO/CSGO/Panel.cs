using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SharpO.CSGO
{
    public class Panel: InterfaceBase
    {
        public delegate void PaintTraverseDlg(IntPtr panelAdr, int vguiPanel, int forceRepaint, int allowForce);
        public delegate int GetPanelDlg(int type);
        public delegate string GetNameDlg(uint panel);

        public PaintTraverseDlg PaintTraverse;
        public GetPanelDlg GetPanel;
        public GetNameDlg GetName;

        public Panel(IntPtr baseAdr) : base(baseAdr)
        {
            GetPanel = GetInterfaceFunction<GetPanelDlg>(1);
            GetName = GetInterfaceFunction<GetNameDlg>(36);
            PaintTraverse = GetInterfaceFunction<PaintTraverseDlg>(41);
        }
    }
}