using HumanResourcesDesktop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Json;

namespace HumanResourcesDesktop.Repositories
{
    internal class AddressRepository
    {
        private string endpoint = "addresses";

        public async Task<List<AddressEntity>> FindAll()
        {
            var client = new HttpClient();
            var list = await client.GetFromJsonAsync<List<AddressEntity>>(AppConnect.Host+ endpoint);
            return list;
        }

        public async Task<AddressEntity> Find(int id)
        {
            var client = new HttpClient();
            var item = await client.GetFromJsonAsync<AddressEntity>(AppConnect.Host + endpoint + "/" + id);
            return item;
        }

        public async Task<AddressEntity> Create(AddressEntity item)
        {
            var client = new HttpClient();
            var response = await client.PostAsJsonAsync(AppConnect.Host +endpoint, item);
            return await response.Content.ReadFromJsonAsync<AddressEntity>();
        }

        public async Task<AddressEntity> Update(AddressEntity item)
        {
            var client = new HttpClient();
            var response = await client.PutAsJsonAsync(AppConnect.Host + endpoint, item);
            return await response.Content.ReadFromJsonAsync<AddressEntity>();
        }

        public async Task Delete(int id)
        {
            var client = new HttpClient();
            await client.DeleteAsync(AppConnect.Host + endpoint +"/"+id);
        }
    }
}
