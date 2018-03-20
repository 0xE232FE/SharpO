# SharpO
CSGO Internal cheat written in C#

Not a cheat, because it has no cheats coded atm.<br />
For now this is an example of injected C# dll in CSGO, it can print text in console and it hooks PaintTraverse (but does not draw anything)<br /><br />
The next step is to draw something using PaintTraverse hook and re-write Valve SDK, but I don't know when I will continue on this<br /><br />
If you want to run this, you will need to change assembly path in Main.cs at line 32 (path to the Fasm.NET.dll which is located next to SharpO.dll) and change SharpO.dll path in Injector.cs at line 29
