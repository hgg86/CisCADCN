using System;
using System.Threading;
using System.Windows.Forms;

namespace Test1
{
    static class Program
  {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        Mutex MiMutex = null;
        const string mutexName = "CISCADCNX";
        try
        {
            MiMutex = Mutex.OpenExisting(mutexName);
            MessageBox.Show("CisCADCNX ya se está ejecutando.");
            return;
        }
        catch (WaitHandleCannotBeOpenedException)
        {
            MiMutex = new Mutex(true, mutexName);
        }
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new Form1());
    }
  }
}
