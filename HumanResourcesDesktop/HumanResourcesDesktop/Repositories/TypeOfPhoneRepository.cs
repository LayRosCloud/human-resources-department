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
    internal class TypeOfPhoneRepository
    {
        private string endpoint = "typeOfPhones";

        public async Task<List<TypeOfPhoneEntity>> FindAll()
        {
            var client = new HttpClient();
            var list = await client.GetFromJsonAsync<List<TypeOfPhoneEntity>>(AppConnect.Host + endpoint);
            return list;
        }

        public async Task<TypeOfPhoneEntity> Find(int id)
        {
            var client = new HttpClient();
            var item = await client.GetFromJsonAsync<TypeOfPhoneEntity>(AppConnect.Host + endpoint + "/" + id);
            return item;
        }

        public async Task<TypeOfPhoneEntity> Create(TypeOfPhoneEntity item)
        {
            var client = new HttpClient();
            var response = await client.PostAsJsonAsync(AppConnect.Host + endpoint, item);
            return await response.Content.ReadFromJsonAsync<TypeOfPhoneEntity>();
        }

        public async Task<TypeOfPhoneEntity> Update(TypeOfPhoneEntity item)
        {
            var client = new HttpClient();
            var response = await client.PutAsJsonAsync(AppConnect.Host + endpoint, item);
            return await response.Content.ReadFromJsonAsync<TypeOfPhoneEntity>();
        }

        public async Task Delete(int id)
        {
            var client = new HttpClient();
            await client.DeleteAsync(AppConnect.Host + endpoint + "/" + id);
        }
    }
}
