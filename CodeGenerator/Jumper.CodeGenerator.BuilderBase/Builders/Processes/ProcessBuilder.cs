using System.Diagnostics;
using System.Management;

namespace Jumper.CodeGenerator.BuilderBase.Builders.Processes;


public class ProcessBuilder
{
    private Process _process;
    public ProcessBuilder()
    {
        _process = new Process();
    }

    public ProcessBuilder SetFileName(string fileName = "dotnet")
    {
        _process.StartInfo.FileName = fileName;
        return this;
    }

    public ProcessBuilder SetUseShellExecute(bool useShellExecute = false)
    {
        _process.StartInfo.UseShellExecute = useShellExecute;
        return this;
    }

    public ProcessBuilder SetRedirectStandardOutput(bool redirectStandardOutput = true)
    {
        _process.StartInfo.RedirectStandardOutput = redirectStandardOutput;
        return this;
    }

    public ProcessBuilder SetRedirectStandardError(bool redirectStandardError = true)
    {
        _process.StartInfo.RedirectStandardError = redirectStandardError;
        return this;
    }

    public ProcessBuilder SetCreateNoWindow(bool createNoWindow = true)
    {
        _process.StartInfo.CreateNoWindow = createNoWindow;
        return this;
    }

    public ProcessBuilder SetArguments(string arguments)
    {
        _process.StartInfo.Arguments = arguments;
        return this;
    }

    public ProcessBuilder SetWorkingDirectory(string workingDirectory)
    {
        _process.StartInfo.WorkingDirectory = workingDirectory;
        return this;
    }


    public void Execute()
    {
        _process.Start();
        _process.WaitForExit();
    }

    public void Exit()
    {

        KillProcessAndChildrens(_process.Id);
    }

    private static void KillProcessAndChildrens(int pid)
    {
#pragma warning disable CA1416 // Validate platform compatibility
        ManagementObjectSearcher processSearcher = new ManagementObjectSearcher
          ("Select * From Win32_Process Where ParentProcessID=" + pid);
#pragma warning restore CA1416 // Validate platform compatibility
        ManagementObjectCollection processCollection = processSearcher.Get();

        // We must kill child processes first!
        if (processCollection != null)
        {
            foreach (ManagementObject mo in processCollection)
            {
                KillProcessAndChildrens(Convert.ToInt32(mo["ProcessID"])); //kill child processes(also kills childrens of childrens etc.)
            }
        }

        // Then kill parents.
        try
        {
            Process proc = Process.GetProcessById(pid);
            if (!proc.HasExited) proc.Kill();
        }
        catch (ArgumentException)
        {
            // Process already exited.
        }
    }






}

