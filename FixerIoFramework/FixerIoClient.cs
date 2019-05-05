using RestSharp;
using System;

namespace FixerIoFramework
{
    public class FixerIoClient
    {
        public FixerIoClient(string accessKey)
        {
            _accessKey = accessKey;
            _client = new RestClient("http://data.fixer.io/api/");
        }

        private readonly string _accessKey;
        private readonly RestClient _client;

        public Currency GetLatest()
        {
            return OnGet("latest");
            //var request = new RestRequest("latest", Method.GET);
            //request.AddParameter("access_key", _accessKey);

            //IRestResponse<Currency> response = _client.Execute<Currency>(request);
            //return response.Data;
        }

        //public Currency GetLatest(string @base, params string[] symbols)
        //{
        //    var par1 = new Parameter("base", @base, ParameterType.GetOrPost);
        //    var par2 = new Parameter("symbols", string.Join(",", symbols), ParameterType.GetOrPost);
        //    return OnGet("latest", par1, par2);
        //}

        public Currency GetLatest(params RateTypes[] symbols)
        {
            var par = new Parameter("symbols", string.Join(",", symbols), ParameterType.GetOrPost);
            return OnGet("latest", par);
        }

        //symbols = GBP,JPY,EUR
        public Currency GetLatest(params string[] symbols)
        {
            var par = new Parameter("symbols", string.Join(",", symbols), ParameterType.GetOrPost);
            return OnGet("latest", par);
            //var request = new RestRequest("latest", Method.GET);
            //request.AddParameter("access_key", _accessKey);
            //request.AddParameter("symbols", string.Join(",", symbols));

            //IRestResponse<Currency> response = _client.Execute<Currency>(request);
            //return response.Data;
        }

        //2013-12-24
        public Currency Get(DateTime date)
        {
            return OnGet(date.ToString("yyyy-MM-dd"));
        }
        private Currency OnGet(string actionName, params Parameter[] parameters)
        {
            var request = new RestRequest(actionName, Method.GET);
            request.AddParameter("access_key", _accessKey);
            if (parameters != null)
            {
                foreach (Parameter parameter in parameters)
                {
                    request.AddParameter(parameter);
                }
            }

            IRestResponse<Currency> response = _client.Execute<Currency>(request);
            return response.Data;
        }
    }
}
