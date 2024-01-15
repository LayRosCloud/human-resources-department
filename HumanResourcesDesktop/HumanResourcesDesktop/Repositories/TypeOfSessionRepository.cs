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
    internal class TypeOfSessionRepository
    {
        private string endpoint = "typeOfSessions";

        public async Task<List<TypeOfSessionEntity>> FindAll()
        {
            var client = new HttpClient();
            var list = await client.GetFromJsonAsync<List<TypeOfSessionEntity>>(AppConnect.Host + endpoint);
            return list;
        }

        public async Task<TypeOfSessionEntity> Find(int id)
        {
            var client = new HttpClient();
            var item = await client.GetFromJsonAsync<TypeOfSessionEntity>(AppConnect.Host + endpoint + "/" + id);
            return item;
        }

        public async Task<TypeOfSessionEntity> Create(TypeOfSessionEntity item)
        {
            var client = new HttpClient();
            var response = await client.PostAsJsonAsync(AppConnect.Host + endpoint, item);
            return await response.Content.ReadFromJsonAsync<TypeOfSessionEntity>();
        }

        public async Task<TypeOfSessionEntity> Update(TypeOfSessionEntity item)
        {
            var client = new HttpClient();
            var response = await client.PutAsJsonAsync(AppConnect.Host + endpoint, item);
            return await response.Content.ReadFromJsonAsync<TypeOfSessionEntity>();
        }

        public async Task Delete(int id)
        {
            var client = new HttpClient();
            await client.DeleteAsync(AppConnect.Host + endpoint + "/" + id);
        }
    }
}
