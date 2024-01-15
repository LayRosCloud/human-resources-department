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
    internal class SessionRepository
    {
        private string endpoint = "sessions";

        public async Task<List<SessionEntity>> FindAll()
        {
            var client = new HttpClient();
            var list = await client.GetFromJsonAsync<List<SessionEntity>>(AppConnect.Host + endpoint);
            return list;
        }

        public async Task<SessionEntity> Find(int id)
        {
            var client = new HttpClient();
            var item = await client.GetFromJsonAsync<SessionEntity>(AppConnect.Host + endpoint + "/" + id);
            return item;
        }

        public async Task<SessionEntity> Create(SessionEntity item)
        {
            var client = new HttpClient();
            var response = await client.PostAsJsonAsync(AppConnect.Host + endpoint, item);
            return await response.Content.ReadFromJsonAsync<SessionEntity>();
        }

        public async Task<SessionEntity> Update(SessionEntity item)
        {
            var client = new HttpClient();
            var response = await client.PutAsJsonAsync(AppConnect.Host + endpoint, item);
            return await response.Content.ReadFromJsonAsync<SessionEntity>();
        }

        public async Task Delete(int id)
        {
            var client = new HttpClient();
            await client.DeleteAsync(AppConnect.Host + endpoint + "/" + id);
        }
    }
}
