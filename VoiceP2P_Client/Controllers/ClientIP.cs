using System.Web;
using System;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace VoiceP2P_Client.Controllers
{
    public class ClientIP
    {
        public static string GetUserHTTPAdress(HttpContext context)
        {
            return context.Connection.RemoteIpAddress.ToString();
        }
    }
}
