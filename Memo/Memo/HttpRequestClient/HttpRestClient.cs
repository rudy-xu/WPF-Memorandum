using Memo.HttpRequestClient;
using Memo.Interfaces;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Memo.Services
{
    /**
     * 封装一个客户端请求库
     * - 用于向后台发送请求
     * - 包含传参，基本路径(Url)，请求模式，请求体等
     */
    public class HttpRestClient
    {
        private readonly string _url;
        protected readonly RestClient _client;
        public HttpRestClient(string url)
        {
            _url = url;
            _client = new RestClient();
        }

        public async Task<ApiRespones> ExecuteAsync(BaseRequest baseRequest)
        {
            var request = new RestRequest(_url+baseRequest.Route, baseRequest.Method);
            request.AddHeader("Content-Type", baseRequest.ContentType);

            if (baseRequest.Parameter != null)
            {
                request.AddParameter("param", JsonConvert.SerializeObject(baseRequest.Parameter), ParameterType.RequestBody);
            }
            
            var response = await _client.ExecuteAsync(request);
            return JsonConvert.DeserializeObject<ApiRespones>(response.Content);
        }

        public async Task<ApiRespones<T>> ExecuteAsync<T>(BaseRequest baseRequest)
        {
            var request = new RestRequest(_url + baseRequest.Route, baseRequest.Method);
            request.AddHeader("Content-Type", baseRequest.ContentType);

            if (baseRequest.Parameter != null)
            {
                request.AddParameter("param", JsonConvert.SerializeObject(baseRequest.Parameter), ParameterType.RequestBody);
            }

            var response = await _client.ExecuteAsync(request);
            return JsonConvert.DeserializeObject<ApiRespones<T>>(response.Content);
        }
    }
}
