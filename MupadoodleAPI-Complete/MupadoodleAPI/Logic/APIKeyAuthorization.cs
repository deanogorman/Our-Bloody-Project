using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Web;
using System.Collections.Specialized;
using System.Collections.Generic;
using System;
using System.Xml.Linq;
using System.Net;
using System.IO;
using System.Configuration;
using System.Runtime.Serialization;
using System.Xml;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;

namespace MupadoodleAPI.Logic
{
    public class ApiKeyHandler : DelegatingHandler
    {
        public string Key { get; set; }

        public ApiKeyHandler(string key)
        {
            this.Key = key;
        }

        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (!ValidateKey(request))
            {
                return Task<HttpResponseMessage>.Factory.StartNew(() =>
                {
                    return new HttpResponseMessage(HttpStatusCode.Forbidden);
                });
            }
            return base.SendAsync(request, cancellationToken);
        }

        private bool ValidateKey(HttpRequestMessage message)
        {
            var query = message.RequestUri.ParseQueryString();
            string key = query["key"];
            return (key == Key);
        }
    }
}

    
