using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TMS.Services.Models;

namespace TMS.Services.Repositories
{
    public class TagClient : ITagClient
    {
        private string _clientURL { get; set; }

        private HttpClient _client { get; set; }

        private string _authToken { get; set; }

        public TagClient(string authToken, string clientURL)
        {
            this._clientURL = clientURL;
            this._authToken = authToken;
            this._client = new HttpClient();
        }

        BaseResponse<List<Tag>> ITagClient.GetAttendanceByTagId(string tagId, string startTime, string endTime, string startCounter)
        {
            var tagList = new BaseResponse<List<Tag>>();
            this._client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            this._client.DefaultRequestHeaders.Add("Authorization", this._authToken);

            HttpResponseMessage response = this._client.GetAsync(
                string.Format(this._clientURL + EndPoint.GetAttendanceByTag, tagId, startTime, endTime, startCounter)).Result;

            if (response.IsSuccessStatusCode)
            {
                string userResponse = response.Content.ReadAsStringAsync().Result;
                tagList = JsonConvert.DeserializeObject<BaseResponse<List<Tag>>>(userResponse);
            }

            return tagList;
        }
    }
}
