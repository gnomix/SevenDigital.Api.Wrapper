using System;
using System.Collections.Generic;
using System.Net;

namespace SevenDigital.Api.Wrapper.Utility.Http
{
	public class HttpClient : IHttpClient
	{
		public IResponse Get(IRequest request)
		{
			throw new NotSupportedException("Need to use async in windows mobile");

		}

		public void GetAsync(IRequest request, Action<IResponse> callback)
		{
			var client = new WebClient();
			client.DownloadStringCompleted += (s, e) =>
			{
				var response = new Response()
				{
					Body = e.Result,
					Headers = MapHeaders(client.ResponseHeaders)
				};
				callback(response);
			};

			client.DownloadStringAsync(new Uri(request.Url));
		}

		public IResponse Post(IRequest request)
		{
			throw new NotSupportedException("Need to use async in windows mobile");
		}

		public void PostAsync(IRequest request, Action<IResponse> callback)
		{
			throw new NotImplementedException();
		}

		public Dictionary<string, string> MapHeaders(WebHeaderCollection headerCollection)
		{
			var headers = new Dictionary<string, string>();

			for (var i = 0; i < headerCollection.Count; i++)
			{
				headers.Add(headerCollection.AllKeys[i], string.Join(",", headerCollection[headerCollection.AllKeys[i]]));
			}

			return headers;
		}
	}
}