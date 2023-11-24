using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ForbiddenWordsSearchApp
{
    public partial class MainForm : Form
    {
        private readonly List<string> forbiddenWords = new List<string>();
        private readonly string destinationFolder = "ForbiddenFiles";
        private readonly object lockObject = new object();

        public MainForm()
        {
            InitializeComponent();
        }

        private void btnLoadWords_Click(object sender, EventArgs e)
        {
            // Implement loading of forbidden words from file or user input
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = false;
            btnCancel.Enabled = true;

            progressBar.Value = 0;

            await Task.Run(() => SearchAndCopyFiles());

            btnStart.Enabled = true;
            btnCancel.Enabled = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Implement logic to cancel the operation
        }

        private void SearchAndCopyFiles()
        {
            // Implement the search and copy logic using multithreading
            // Update the progress bar and UI elements accordingly
        }
    }

    public class FileSearcher
    {
        private readonly List<string> forbiddenWords;
        private readonly string destinationFolder;
        private readonly object lockObject;

        public FileSearcher(List<string> forbiddenWords, string destinationFolder, object lockObject)
        {
            this.forbiddenWords = forbiddenWords;
            this.destinationFolder = destinationFolder;
            this.lockObject = lockObject;
        }

        public void SearchAndCopyFiles()
        {
            // Implement the search and copy logic using multithreading
            // Update the progress bar and UI elements accordingly
        }
    }

    static class Program
    {
        private static Mutex mutex = new Mutex(true, "{F16A2E17-39D5-4D74-8F5A-994AEBD409F9}");

        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }
            else if (args.Length == 1 && args[0] == "13K")
            {
                RunCommandLineVersion();
            }
            else
            {
                Console.WriteLine("Invalid command line arguments.");
            }
        }

        private static void RunCommandLineVersion()
        {
            if (mutex.WaitOne(TimeSpan.Zero, true))
            {
                try
                {
                    Console.WriteLine("Command Line Version Running...");

                    // Implement the command-line version logic here
                }
                finally
                {
                    mutex.ReleaseMutex();
                }
            }
            else
            {
                Console.WriteLine("Another instance of the application is already running.");
            }
        }
    }
}