using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarpostWebScrapper.Loaders
{
    class HtmlDataEventArgs : EventArgs
    {
        private string htmlData;

        public HtmlDataEventArgs(string data)
        {
            htmlData = data;
        }

        public string HtmlData { get { return htmlData; } }
    }
}
