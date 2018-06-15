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
                if (args.Name.Contains("Fasm.NET"))
                {
                    return Assembly.LoadFrom(@"C:\Users\Admin\Source\Repos\SharpO\SharpO\bin\Release\Fasm.NET.dll");
                }

                return null;
            };

            DebugHelper.ShowConsoleWindow();

            SDK.Init();
            EngineHook.Init();

            //SDK.Surface.DrawLine(0, 0, 100, 100);

            while (true)
            {
                Console.ReadKey();
            }
        }
    }

    public static class EngineHook
    {
        public delegate void PaintTraverseDlg(uint vguiPanel, bool forceRepaint, bool allowForce);

        static PaintTraverseDlg PaintTraverse;
        static PaintTraverseDlg hkPaintTraverse;

        public static void Init()
        {
            PaintTraverse = SDK.Panel.GetInterfaceFunction<PaintTraverseDlg>(41);
            hkPaintTraverse = PaintTraverseHooked;
            SDK.Panel.SetInterfacePointer(41, Marshal.GetFunctionPointerForDelegate(hkPaintTraverse));
        }
        // shit is not working bror fuick
        static void PaintTraverseHooked(uint vguiPanel, bool forceRepaint, bool allowForce)
        {
            Console.WriteLine($"Im here {vguiPanel} {forceRepaint} {allowForce}");
            Console.ReadLine();
            Console.WriteLine("Kalling PPT");
            PaintTraverse(vguiPanel, forceRepaint, allowForce);
            Console.WriteLine("Kalled pt");
            Console.ReadLine();
        }
    }
}