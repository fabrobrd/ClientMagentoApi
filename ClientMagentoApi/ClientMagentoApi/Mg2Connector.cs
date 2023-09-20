using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ClientMagentoApi
{
    public class Mg2Connector
    {
        private RestClient _client { get; set; }
        private Uri _magentoUrl { get; set; }
        private string _token { get; set; }

        public Mg2Connector(string magentoUrl)
        {
            _client = new RestClient(magentoUrl);
        }
        public Mg2Connector(string magentoUrl, string token)
        {
            _client = new RestClient(magentoUrl);
        }

        public string GetAdminToken(string userName, string passWord)
        {
            var request = CreateRequest("/rest/all/async/V1/integration/admin/token", Method.Post);
            var user = new Credentials();
            user.username = userName;
            user.password = passWord;
            string json = JsonConvert.SerializeObject(user, Newtonsoft.Json.Formatting.Indented);

            request.AddParameter("application/json", json, ParameterType.RequestBody);

            var response = _client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return response.Content;
            }
            else
            {
                return "";
            }

        }
        private RestRequest CreateRequest(string endPoint, Method method)
        {
            var request = new RestRequest(endPoint, method);
            request.RequestFormat = DataFormat.Json;
            return request;
        }

    }
}
