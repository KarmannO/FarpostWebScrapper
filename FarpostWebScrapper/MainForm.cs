using System;
using System.Windows.Forms;
using FarpostWebScrapper.Loaders;
using System.ComponentModel;

namespace FarpostWebScrapper
{
    public partial class MainForm : Form
    {
        PagesLoader loader = new PagesLoader(ExportFormats.FormatJSON);
        BackgroundWorker backgroundTaskManager = new BackgroundWorker();

        public MainForm()
        {
            InitializeComponent();
            backgroundTaskManager.WorkerSupportsCancellation = true;
            backgroundTaskManager.WorkerReportsProgress = true;
            backgroundTaskManager.DoWork += loader.DoLoad;
            loader.onDataRecieved += onLoaderDataRecieved;
        }

        private void log(string message)
        {
            logBox.Invoke((MethodInvoker) delegate { logBox.AppendText(DateTime.Now.ToShortTimeString() + ": " + message + "\n"); });
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void onLoaderDataRecieved(object sender, EventArgs e)
        {
            HtmlDataEventArgs ed = (HtmlDataEventArgs)e;
            log("[loader] " + ed.HtmlData);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            log("Форма загружена");
        }

        private void downloadButton_Click(object sender, EventArgs e)
        {
            if (backgroundTaskManager.IsBusy == false)
            {
                backgroundTaskManager.RunWorkerAsync();
            }
        }
    }
}
