using System;
using System.Runtime.InteropServices;
using System.Threading;

using SharpO.CSGO;
using SharpO.Hooks;

using System.Collections.Generic;
using System.Reflection;

namespace SharpO
{
    // Should NOT be obfuscated
    public static class Main
    {
        /// <summary>
        /// Actually never called, need for injector to see exports
        /// </summary>
        public static void DllMain(IntPtr dllInstance, int reason, IntPtr reserved) { }

        /// <summary>
        /// Fake entry point, must be called after injection
        /// </summary>
        [DllExport("Init")]
        public static void Init()
        {
            AppDomain.CurrentDomain.AssemblyResolve += (object sender, ResolveEventArgs args) =>
            {
                if(args.Name.Contains("Fasm.NET"))
                {
                    return Assembly.LoadFrom(@"C:\Users\Admin\Source\Repos\SharpO\SharpO\bin\Release\Fasm.NET.dll");
                }

                return null;
            };

            DebugHelper.ShowConsoleWindow();

            SDK.Init();
            
            

            EngineHook.Init();

            while(true)
            {
                Console.ReadKey();
            }
        }
    }

    public static class EngineHook
    {
        static PaintTraverseHook HookPT;

        public delegate void PaintTraverseDlg();
        public delegate void Test();

        public static void Init()
        {
            HookPT = new PaintTraverseHook(SDK.Panel.GetInterfaceFunctionAddress<PaintTraverseDlg>(41), (PaintTraverseDlg)PaintTraverseHooked);
            HookPT.Hook();
        }

        static unsafe void PaintTraverseHooked()
        {
            SDK.Surface.DrawFilledRect(10, 10, 50, 50);
        }
    }
}