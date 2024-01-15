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
    internal class PassportRepository
    {
        private string endpoint = "passports";

        public async Task<List<PassportEntity>> FindAll()
        {
            var client = new HttpClient();
            var list = await client.GetFromJsonAsync<List<PassportEntity>>(AppConnect.Host + endpoint);
            return list;
        }

        public async Task<PassportEntity> Find(int id)
        {
            var client = new HttpClient();
            var item = await client.GetFromJsonAsync<PassportEntity>(AppConnect.Host + endpoint + "/" + id);
            return item;
        }

        public async Task<PassportEntity> Create(PassportEntity item)
        {
            var client = new HttpClient();
            var response = await client.PostAsJsonAsync(AppConnect.Host + endpoint, item);
            return await response.Content.ReadFromJsonAsync<PassportEntity>();
        }

        public async Task<PassportEntity> Update(PassportEntity item)
        {
            var client = new HttpClient();
            var response = await client.PutAsJsonAsync(AppConnect.Host + endpoint, item);
            return await response.Content.ReadFromJsonAsync<PassportEntity>();
        }

        public async Task Delete(int id)
        {
            var client = new HttpClient();
            await client.DeleteAsync(AppConnect.Host + endpoint + "/" + id);
        }
    }
}
