using System;
using System.Windows.Forms;
using FarpostWebScrapper.Loaders;
using System.ComponentModel;

namespace FarpostWebScrapper
{
    public partial class MainForm : Form
    {
        PagesLoader loader = new PagesLoader(ExportFormats.FormatJSON);
        BackgroundWorker locationsLoader = new BackgroundWorker();
        BackgroundWorker sectionsLoader = new BackgroundWorker();


        public MainForm()
        {
            InitializeComponent();
            locationsLoader.WorkerSupportsCancellation = true;
            locationsLoader.DoWork += loader.DoLoadLocations;

            sectionsLoader.WorkerSupportsCancellation = true;
            sectionsLoader.DoWork += loader.DoLoadSections;

            loader.onDataRecieved += onLoaderDataRecieved;
        }

        private void log(string message)
        {
            logBox.Invoke((MethodInvoker) delegate { logBox.AppendText(DateTime.Now.ToShortTimeString() + ": " + message + "\r\n"); });
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
            log("[form] Форма загружена");
            if (locationsLoader.IsBusy == false)
            {
                log("[form] Запускаю загрузку городов...");
                locationsLoader.RunWorkerAsync();
            }
            if (sectionsLoader.IsBusy == false)
            {
                log("[form] Запускаю загрузку разделов...");
                sectionsLoader.RunWorkerAsync();
            }
        }

        private void downloadButton_Click(object sender, EventArgs e)
        {

        }
    }
}
