using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpO.CSGO
{
    public class Engine: InterfaceBase
    {
        public delegate void GetScreenSizeDlg(out int width, out int height);
        public delegate void ClientCmd_UnrestrictedDlg(string text, int flags);
        public delegate int GetLocalPlayerDlg();
        //public delegate void GetViewAnglesDlg(out Vector vector);
        //public delegate void SetViewAngleDlg(Vector vector);

        public GetScreenSizeDlg GetScreenSize;
        public ClientCmd_UnrestrictedDlg ClientCmd_Unrestricted;
        public GetLocalPlayerDlg GetLocalPlayer;
        //public GetViewAnglesDlg GetViewAngles;
        //public SetViewAngleDlg SetViewAngles;

        public Engine(IntPtr baseAdr) : base(baseAdr)
        {
            GetScreenSize = GetInterfaceFunction<GetScreenSizeDlg>(5);
            ClientCmd_Unrestricted = GetInterfaceFunction<ClientCmd_UnrestrictedDlg>(114);
            GetLocalPlayer = GetInterfaceFunction<GetLocalPlayerDlg>(12);
            //GetViewAngles = GetInterfaceFunction<GetViewAnglesDlg>(18);
            //SetViewAngles = GetInterfaceFunction<SetViewAngleDlg>(19);
        }
    }
}