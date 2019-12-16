using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using Curse.Entities;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace Curse
{
    /// <summary>
    /// Represents curse addon service implementation class.
    /// </summary>
    [DebuggerDisplay("Curse Addon Service")]
    public class AddonService
    {
        private RestClient _client;

        /// <summary>
        /// Constructor
        /// </summary>
        public AddonService()
        {
            this._client = new RestClient("https://addons-ecs.forgesvc.net/api/v2");
        }

        Task<string> GetStringAsync(string path)
        {
            var request = new RestRequest(path, DataFormat.Json);
            var tsc = new TaskCompletionSource<string>();

            this._client.ExecuteAsync(request, response =>
            {
                if (response.StatusCode == HttpStatusCode.OK)
                    tsc.TrySetResult(response.Content);
                else
                    tsc.TrySetResult("{}");
            });

            return tsc.Task;
        }

        public async Task<Addon> GetAddonAsync(long id)
        {
            var json = await this.GetStringAsync($"addon/{id}");
            var addon = JObject.Parse(json)
                .ToObject<Addon>();

            addon.Service = this;

            return addon;
        }

        public async Task<IReadOnlyList<Addon>> SearchAddonsAsync(GameType game, int section = 6, int category = 0, int maxResults = 50, string sort = "popularity", bool sortDescending = true, int index = 0, string search = default)
        {
            var kvp = new Dictionary<string, object>();
            kvp["gameId"] = (int)game;
            kvp["sectionId"] = section;
            kvp["categoryId"] = category;
            kvp["pageSize"] = maxResults;
            kvp["sort"] = sort;
            kvp["isSortDescending"] = sortDescending ? 1 : 0;
            kvp["index"] = index;

            if(!string.IsNullOrEmpty(search))
                kvp["searchFilter"] = search;

            var query = string.Join("&", kvp.Select(x => HttpUtility.UrlEncode(x.Key) + '=' + HttpUtility.UrlEncode(x.Value.ToString())));
            var json = await this.GetStringAsync($"addon/search?{query}");

            var rawAddons = JArray.Parse(json)
                .ToObject<List<Addon>>();

            foreach(var addon in rawAddons)
                addon.Service = this;

            return rawAddons
                .AsReadOnly();
        }

        public void Dispose()
        {
            if(this._client != null)
                this._client = null;
        }
    }
}
