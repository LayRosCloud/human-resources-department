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
    internal class PersonRepository
    {
        private string endpoint = "people";

        public async Task<List<PersonEntity>> FindAll()
        {
            var client = new HttpClient();
            var list = await client.GetFromJsonAsync<List<PersonEntity>>(AppConnect.Host + endpoint);
            return list;
        }

        public async Task<PersonEntity> Find(int id)
        {
            var client = new HttpClient();
            var item = await client.GetFromJsonAsync<PersonEntity>(AppConnect.Host + endpoint + "/" + id);
            return item;
        }

        public async Task<PersonEntity> Create(PersonEntity item)
        {
            var client = new HttpClient();
            var response = await client.PostAsJsonAsync(AppConnect.Host + endpoint, item);
            return await response.Content.ReadFromJsonAsync<PersonEntity>();
        }

        public async Task<PersonEntity> Update(AddressEntity item)
        {
            var client = new HttpClient();
            var response = await client.PutAsJsonAsync(AppConnect.Host + endpoint, item);
            return await response.Content.ReadFromJsonAsync<PersonEntity>();
        }

        public async Task Delete(int id)
        {
            var client = new HttpClient();
            await client.DeleteAsync(AppConnect.Host + endpoint + "/" + id);
        }
    }
}
