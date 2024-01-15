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
    internal class CountryRepository
    {
        private string endpoint = "countries";

        public async Task<List<CountryEntity>> FindAll()
        {
            var client = new HttpClient();
            var list = await client.GetFromJsonAsync<List<CountryEntity>>(AppConnect.Host + endpoint);
            return list;
        }

        public async Task<CountryEntity> Find(int id)
        {
            var client = new HttpClient();
            var item = await client.GetFromJsonAsync<CountryEntity>(AppConnect.Host + endpoint + "/" + id);
            return item;
        }

        public async Task<CountryEntity> Create(CountryEntity item)
        {
            var client = new HttpClient();
            var response = await client.PostAsJsonAsync(AppConnect.Host + endpoint, item);
            return await response.Content.ReadFromJsonAsync<CountryEntity>();
        }

        public async Task<CountryEntity> Update(CountryEntity item)
        {
            var client = new HttpClient();
            var response = await client.PutAsJsonAsync(AppConnect.Host + endpoint, item);
            return await response.Content.ReadFromJsonAsync<CountryEntity>();
        }

        public async Task Delete(int id)
        {
            var client = new HttpClient();
            await client.DeleteAsync(AppConnect.Host + endpoint + "/" + id);
        }
    }
}
