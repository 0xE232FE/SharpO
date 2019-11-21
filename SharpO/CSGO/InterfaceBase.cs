using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SharpO.CSGO
{
    public abstract class InterfaceBase
    {
        public IntPtr BaseAdr;

        public InterfaceBase(IntPtr baseAdr)
        {
            this.BaseAdr = baseAdr;
        }

        internal T GetInterfaceFunction<T>(int index)
        {
            return Memory.GetFunction<T>(Memory.ReadPointer(Memory.ReadPointer(BaseAdr) + index * 4));
        }

        internal IntPtr GetInterfaceFunctionAddress(int index)
        {
            return Memory.ReadPointer(Memory.ReadPointer(BaseAdr) + index * 4);
        }

        internal IntPtr GetInterfaceAddress(int index)
        {
            return Memory.ReadPointer(BaseAdr) + index * 4;
        }

        public void SetInterfacePointer(int index, IntPtr newPtr)
        {
            IntPtr adr = GetInterfaceAddress(index);
            WinAPI.VirtualProtect(adr, 4, (int)WinAPI.Protection.PAGE_EXECUTE_READWRITE, out int kek);
            Marshal.WriteIntPtr(adr, newPtr);
        }
    }
}