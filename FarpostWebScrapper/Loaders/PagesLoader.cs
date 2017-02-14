using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Text;

namespace FarpostWebScrapper.Loaders
{
    class PagesLoader
    {
        protected ExportFormats formatToExport;
        private string prefix = "http://farpost.ru/";
        private string citiesUrlPostfix = "geo/nav/city";

        public event EventHandler onDataRecieved;

        public static string LoadHtmlByUrl(string url)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Stream recieveStream = response.GetResponseStream();
                    StreamReader readStream = null;
                    if (response.CharacterSet == null)
                    {
                        readStream = new StreamReader(recieveStream);
                    }
                    else
                    {
                        readStream = new StreamReader(recieveStream, Encoding.GetEncoding(response.CharacterSet));
                    }
                    string data = readStream.ReadToEnd();
                    response.Close();
                    readStream.Close();
                    return data;
                }
                else
                    throw new Exception("Запрос не выполнен. Статус: " + response.StatusCode.ToString());
            }
            catch (Exception e)
            {
                throw new Exception("При загрузке страницы произошла ошибка: " + e.Message);
            }
        }
        

        public PagesLoader(ExportFormats formatToExport)
        {
            this.formatToExport = formatToExport;
        }

        public void DoLoad(object sender, DoWorkEventArgs e)
        {
            onDataRecieved(this, new HtmlDataEventArgs("Поток загрузки инициализирован"));

            onDataRecieved(this, new HtmlDataEventArgs("Поток загрузки окончен"));
        }
    }
}
