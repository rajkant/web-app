using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Text;
using System.Web;
using System.Web.UI;
using HtmlAgilityPack;


namespace WebApp
{
    public partial class Downloader : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                TextBox1.Text = "http://www.sayka.com/downloads/front_view.jpg";
            }
        }
        
        protected void btnDownload_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TextBox1.Text))
                DownloadVideo(TextBox1.Text);
            //DownloadVideo("https://www.sample-videos.com/video/mp4/720/big_buck_bunny_720p_1mb.mp4");
        }
                                
        protected void btnGetLinks_Click(object sender, EventArgs e)
        {
            HtmlWeb web = new HtmlWeb();
            HtmlDocument document = web.Load("https://www.sam.gov/SAM/pages/public/extracts/samPublicAccessData.jsf");
            HtmlNode[] nodes = document.DocumentNode.SelectNodes("//a").ToArray();
            
            StringBuilder str = new StringBuilder();
            HtmlNode node = nodes.FirstOrDefault(k => k.XPath == "/html[1]/body[1]/div[1]/div[1]/div[1]/div[4]/div[1]/table[1]/tbody[1]/tr[1]/td[2]/div[4]/div[4]/div[1]/table[1]/tr[3]/td[1]/a[7]");
            str.Append(node.OuterHtml);
            //foreach (HtmlNode item in nodes)
            //{
            //    str.Append(item.InnerHtml);
            //}
            LiteralText.Text = str.ToString();
            string hrefValue = node.Attributes["href"].Value;
       
            //HtmlNode node = document.DocumentNode.SelectNodes("//div[@id='div1']").First();
            //HtmlNode[] aNodes = node.SelectNodes(".//a").ToArray();
            //HtmlNode[] nodes2 = document.DocumentNode.SelectNodes("//a").Where(x => x.InnerHtml.Contains("div2")).ToArray();
            //foreach (HtmlNode item in nodes)
            //{
            //    Console.WriteLine(item.InnerHtml);
            //}

            //ServicePointManager.Expect100Continue = true;
            //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            //ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

            string[] filePaths = Directory.GetFiles(@"c:\test\");
            foreach (string filePath in filePaths)
            {
                if (filePath.Substring(filePath.LastIndexOf('.')).ToUpper() == ".ZIP" || filePath.Substring(filePath.LastIndexOf('.')).ToUpper() == ".CSV")
                    File.Delete(filePath);
            }

            string remoteUri = "https://www.sam.gov/";
            string fileName = Server.HtmlDecode(hrefValue), myStringWebResource = null;
            using (WebClient myWebClient = new WebClient())
            {
                myStringWebResource = remoteUri + fileName;
                myWebClient.DownloadFile(myStringWebResource, @"C:\test\" + fileName.Substring(hrefValue.LastIndexOf('=') + 1));
            };

        }

        #region utility

        private void DownloadVideo(string hreflink)
        {
            using (WebClient webClient = new WebClientWithTimeout())
            {
                try
                {
                    webClient.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/60.0.3112.78 Safari/537.36");
                    webClient.Headers["Accept"] = "application/x-ms-application, image/jpeg, application/xaml+xml, image/gif, image/pjpeg, application/x-ms-xbap, application/x-shockwave-flash, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, */*";
                    webClient.Headers.Add("user-agent", "ASP.NET WebClient");

                    //webClient.DownloadFile(new Uri("http://desilouisville.com/images/header-images/header_img_4.jpg"), @"c:\Doc\myfile.jpg");
                    Uri uri = new Uri(hreflink);
                    webClient.DownloadFile(uri, HttpContext.Current.Server.MapPath("~") + @"\" + GetFileNameFromUrl(hreflink));
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
            }
        }

        public static string GetFileNameFromUrl(string url)
        {
            Uri uri = null;
            string fileName = "";
            if (Uri.TryCreate(url, UriKind.Absolute, out uri))
            {
                fileName = GetFileNameValidChar(Path.GetFileName(uri.AbsolutePath));
            }
            string ext = "";
            if (!string.IsNullOrEmpty(fileName))
            {
                ext = Path.GetExtension(fileName);
                if (string.IsNullOrEmpty(ext))
                    ext = ".html";
                else
                    ext = "";
                return GetFileNameValidChar(fileName + ext);
            }

            fileName = Path.GetFileName(url);
            if (string.IsNullOrEmpty(fileName))
            {
                fileName = "noName";
            }
            ext = Path.GetExtension(fileName);
            if (string.IsNullOrEmpty(ext))
                ext = ".html";
            else
                ext = "";
            fileName = fileName + ext;
            if (!fileName.StartsWith("?"))
                fileName = fileName.Split('?').FirstOrDefault();
            fileName = fileName.Split('&').LastOrDefault().Split('=').LastOrDefault();
            return GetFileNameValidChar(fileName);
        }

        public static string GetFileNameValidChar(string fileName)
        {
            foreach (var item in System.IO.Path.GetInvalidFileNameChars())
            {
                fileName = fileName.Replace(item.ToString(), "");
            }
            return fileName;
        }

        private string DownloadFile(string url)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            string filename = "";
            string destinationpath = @"c:\Doc\";
            if (!Directory.Exists(destinationpath))
            {
                Directory.CreateDirectory(destinationpath);
            }
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponseAsync().Result)
            {
                string path = response.Headers["Content-Disposition"];
                if (string.IsNullOrWhiteSpace(path))
                {
                    var uri = new Uri(url);
                    filename = Path.GetFileName(uri.LocalPath);
                }
                else
                {
                    ContentDisposition contentDisposition = new ContentDisposition(path);
                    filename = contentDisposition.FileName;
                }

                var responseStream = response.GetResponseStream();
                using (var fileStream = File.Create(System.IO.Path.Combine(destinationpath, filename)))
                {
                    responseStream.CopyTo(fileStream);
                }
            }

            return Path.Combine(destinationpath, filename);
        }
        #endregion utility

    }
}