using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FarpostWebScrapper.Loaders;

namespace FarpostWebScrapper
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void log(string message)
        {
            logBox.AppendText(DateTime.Now.ToShortDateString() + ": " + message);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void onLoaderDataRecieved(object sender, EventArgs e)
        {
            HtmlDataEventArgs ed = (HtmlDataEventArgs)e;
            log(ed.HtmlData);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            log("Форма загружена");
            PagesLoader loader = new PagesLoader(ExportFormats.FormatJSON);
            loader.onDataRecieved += onLoaderDataRecieved;
            loader.LoadPage("http://farpost.ru/");
        }
    }
}
