using System.Diagnostics;

foreach (Process process in Process.GetProcesses())
{
    switch (process.ProcessName.ToLower())
    {
        case "xamldesigner":
            process.Kill();
            break;

        case "xamldesigner launcher":
            process.Kill();
            break;
    }
}

foreach (Process process in Process.GetProcessesByName("XamlDesigner"))
{
    process.Kill();
}

Console.WriteLine("XAMLDesigner tasks killed.");
Environment.Exit(0);