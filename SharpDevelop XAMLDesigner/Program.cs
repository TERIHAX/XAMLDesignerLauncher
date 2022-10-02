using System.Diagnostics;
using System.Runtime.InteropServices;

[DllImport("kernel32.dll")]
static extern IntPtr GetConsoleWindow();

[DllImport("user32.dll")]
static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

Console.Title = "XAMLDesigner Launcher";

Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine("[NOTICE]: The WPFDesigner was made by SharpDevelop (ICSharpCode).\r\nI (unknown) just made this to launch the application, because the application didn't seem to fully close itself after exit.\r\n\r\nThe actual WPFDesigner app is \"bin/net6.0-windows/sharpdevelopxamldesigner.exe\". I also modified the actual WPFDesigner so that it actually has a XAML logo icon with a dropshadow, nothing else.\r\n\r\nThe source code is from this GitHub repo:\r\nhttps://github.com/icsharpcode/WpfDesigner\r\n\r\n.NET 6.0 is required to run.\r\n\r\nFor more info, read the \"NOTICE.txt\" file.\r\n\r\n");

Thread.Sleep(1000);

Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine("Starting XAMLDesigner...");
if (Directory.Exists("./bin"))
{
    if (!File.Exists("NewFileTemplate.xaml"))
    {
        File.WriteAllText("NewFileTemplate.xaml", "<Window xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\"\r\n        xmlns:x=\"http://schemas.microsoft.com/winfx/2006/xaml\" Width=\"640\" Height=\"480\">\r\n    <Grid />\r\n</Window>");
    }

    ShowWindow(GetConsoleWindow(), 0);

    Process.Start("./bin/net6.0-windows/sharpdevelop xamldesigner.exe").WaitForExit();

    ShowWindow(GetConsoleWindow(), 5);

    Console.WriteLine("XAMLDesigner \"closed\".");

    Thread.Sleep(1000);
    foreach (Process process in Process.GetProcesses())
    {
        if (process.ProcessName.ToLower() == "xamldesigner")
        {
            process.Kill();
        }
    }

    Process.Start("KillDesigner.exe");

    Console.WriteLine("XAMLDesigner *actually* fully closed.\r\n\r\nClosing in 2 seconds.");

    Thread.Sleep(2000);

    Environment.Exit(0);
}
else
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("\"bin\" folder is missing!\r\n\r\n");

    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("Press any key to exit.");

    Console.ReadKey();

    return;
}
