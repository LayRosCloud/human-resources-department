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
    internal class CityStreetRepository
    {
        private string endpoint = "citiesstreets";

        public async Task<List<CityStreetEntity>> FindAll()
        {
            var client = new HttpClient();
            var list = await client.GetFromJsonAsync<List<CityStreetEntity>>(AppConnect.Host + endpoint);
            return list;
        }

        public async Task<CityStreetEntity> Find(int id)
        {
            var client = new HttpClient();
            var item = await client.GetFromJsonAsync<CityStreetEntity>(AppConnect.Host + endpoint + "/" + id);
            return item;
        }

        public async Task<CityStreetEntity> Create(CityStreetEntity item)
        {
            var client = new HttpClient();
            var response = await client.PostAsJsonAsync(AppConnect.Host + endpoint, item);
            return await response.Content.ReadFromJsonAsync<CityStreetEntity>();
        }

        public async Task<CityStreetEntity> Update(CityStreetEntity item)
        {
            var client = new HttpClient();
            var response = await client.PutAsJsonAsync(AppConnect.Host + endpoint, item);
            return await response.Content.ReadFromJsonAsync<CityStreetEntity>();
        }

        public async Task Delete(int id)
        {
            var client = new HttpClient();
            await client.DeleteAsync(AppConnect.Host + endpoint + "/" + id);
        }
    }
}
