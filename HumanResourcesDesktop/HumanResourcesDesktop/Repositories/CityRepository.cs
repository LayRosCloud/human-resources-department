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
    internal class CityRepository
    {
        private string endpoint = "cities";

        public async Task<List<CityEntity>> FindAll()
        {
            var client = new HttpClient();
            var list = await client.GetFromJsonAsync<List<CityEntity>>(AppConnect.Host + endpoint);
            return list;
        }

        public async Task<CityEntity> Find(int id)
        {
            var client = new HttpClient();
            var item = await client.GetFromJsonAsync<CityEntity>(AppConnect.Host + endpoint + "/" + id);
            return item;
        }

        public async Task<CityEntity> Create(CityEntity item)
        {
            var client = new HttpClient();
            var response = await client.PostAsJsonAsync(AppConnect.Host + endpoint, item);
            return await response.Content.ReadFromJsonAsync<CityEntity>();
        }

        public async Task<CityEntity> Update(CityEntity item)
        {
            var client = new HttpClient();
            var response = await client.PutAsJsonAsync(AppConnect.Host + endpoint, item);
            return await response.Content.ReadFromJsonAsync<CityEntity>();
        }

        public async Task Delete(int id)
        {
            var client = new HttpClient();
            await client.DeleteAsync(AppConnect.Host + endpoint + "/" + id);
        }
    }
}
