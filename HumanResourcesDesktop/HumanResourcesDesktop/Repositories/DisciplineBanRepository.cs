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
    internal class DisciplineBanRepository
    {
        private string endpoint = "disciplinebans";

        public async Task<List<DisciplineBanEntity>> FindAll()
        {
            var client = new HttpClient();
            var list = await client.GetFromJsonAsync<List<DisciplineBanEntity>>(AppConnect.Host + endpoint);
            return list;
        }

        public async Task<DisciplineBanEntity> Find(int id)
        {
            var client = new HttpClient();
            var item = await client.GetFromJsonAsync<DisciplineBanEntity>(AppConnect.Host + endpoint + "/" + id);
            return item;
        }

        public async Task<DisciplineBanEntity> Create(DisciplineBanEntity item)
        {
            var client = new HttpClient();
            var response = await client.PostAsJsonAsync(AppConnect.Host + endpoint, item);
            return await response.Content.ReadFromJsonAsync<DisciplineBanEntity>();
        }

        public async Task<DisciplineBanEntity> Update(DisciplineBanEntity item)
        {
            var client = new HttpClient();
            var response = await client.PutAsJsonAsync(AppConnect.Host + endpoint, item);
            return await response.Content.ReadFromJsonAsync<DisciplineBanEntity>();
        }

        public async Task Delete(int id)
        {
            var client = new HttpClient();
            await client.DeleteAsync(AppConnect.Host + endpoint + "/" + id);
        }
    }
}
