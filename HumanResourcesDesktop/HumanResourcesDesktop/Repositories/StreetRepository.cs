using HumanResourcesDesktop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourcesDesktop.Repositories
{
    internal class StreetRepository
    {
        private string endpoint = "streets";

        public async Task<List<StreetEntity>> FindAll()
        {
            var client = new HttpClient();
            var list = await client.GetFromJsonAsync<List<StreetEntity>>(AppConnect.Host + endpoint);
            return list;
        }

        public async Task<StreetEntity> Find(int id)
        {
            var client = new HttpClient();
            var item = await client.GetFromJsonAsync<StreetEntity>(AppConnect.Host + endpoint + "/" + id);
            return item;
        }

        public async Task<StreetEntity> Create(StreetEntity item)
        {
            var client = new HttpClient();
            var response = await client.PostAsJsonAsync(AppConnect.Host + endpoint, item);
            return await response.Content.ReadFromJsonAsync<StreetEntity>();
        }

        public async Task<StreetEntity> Update(StreetEntity item)
        {
            var client = new HttpClient();
            var response = await client.PutAsJsonAsync(AppConnect.Host + endpoint, item);
            return await response.Content.ReadFromJsonAsync<StreetEntity>();
        }

        public async Task Delete(int id)
        {
            var client = new HttpClient();
            await client.DeleteAsync(AppConnect.Host + endpoint + "/" + id);
        }
    }
}
