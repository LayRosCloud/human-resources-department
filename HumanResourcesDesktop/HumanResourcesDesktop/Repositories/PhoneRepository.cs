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
    internal class PhoneRepository
    {
        private string endpoint = "phones";

        public async Task<List<PhoneEntity>> FindAll()
        {
            var client = new HttpClient();
            var list = await client.GetFromJsonAsync<List<PhoneEntity>>(AppConnect.Host + endpoint);
            return list;
        }

        public async Task<PhoneEntity> Find(int id)
        {
            var client = new HttpClient();
            var item = await client.GetFromJsonAsync<PhoneEntity>(AppConnect.Host + endpoint + "/" + id);
            return item;
        }

        public async Task<PhoneEntity> Create(PhoneEntity item)
        {
            var client = new HttpClient();
            var response = await client.PostAsJsonAsync(AppConnect.Host + endpoint, item);
            return await response.Content.ReadFromJsonAsync<PhoneEntity>();
        }

        public async Task<PhoneEntity> Update(PhoneEntity item)
        {
            var client = new HttpClient();
            var response = await client.PutAsJsonAsync(AppConnect.Host + endpoint, item);
            return await response.Content.ReadFromJsonAsync<PhoneEntity>();
        }

        public async Task Delete(int id)
        {
            var client = new HttpClient();
            await client.DeleteAsync(AppConnect.Host + endpoint + "/" + id);
        }
    }
}
