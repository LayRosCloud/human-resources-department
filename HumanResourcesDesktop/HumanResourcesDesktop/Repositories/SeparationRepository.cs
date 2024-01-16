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
    internal class SeparationRepository
    {
        private string endpoint = "separations";

        public async Task<List<SeparationEntity>> FindAll()
        {
            var client = new HttpClient();
            var list = await client.GetFromJsonAsync<List<SeparationEntity>>(AppConnect.Host + endpoint);
            return list;
        }

        public async Task<SeparationEntity> Find(int id)
        {
            var client = new HttpClient();
            var item = await client.GetFromJsonAsync<SeparationEntity>(AppConnect.Host + endpoint + "/" + id);
            return item;
        }

        public async Task<SeparationEntity> Create(SeparationEntity item)
        {
            var client = new HttpClient();
            var response = await client.PostAsJsonAsync(AppConnect.Host + endpoint, item);
            return await response.Content.ReadFromJsonAsync<SeparationEntity>();
        }

        public async Task<SeparationEntity> Update(SeparationEntity item)
        {
            var client = new HttpClient();
            var response = await client.PutAsJsonAsync(AppConnect.Host + endpoint, item);
            return await response.Content.ReadFromJsonAsync<SeparationEntity>();
        }

        public async Task Delete(int id)
        {
            var client = new HttpClient();
            await client.DeleteAsync(AppConnect.Host + endpoint + "/" + id);
        }
    }
}
