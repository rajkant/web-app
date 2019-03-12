using System;
using System.Net;

public class WebClientWithTimeout:WebClient
{
    protected override WebRequest GetWebRequest(Uri address)
    {
        WebRequest wr = base.GetWebRequest(address);
        wr.Timeout = 18000000; // timeout in milliseconds (ms)
        return wr;
    }

}