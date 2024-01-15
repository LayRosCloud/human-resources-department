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
    internal class RegionRepository
    {
        private string endpoint = "regions";

        public async Task<List<RegionEntity>> FindAll()
        {
            var client = new HttpClient();
            var list = await client.GetFromJsonAsync<List<RegionEntity>>(AppConnect.Host + endpoint);
            return list;
        }

        public async Task<RegionEntity> Find(int id)
        {
            var client = new HttpClient();
            var item = await client.GetFromJsonAsync<RegionEntity>(AppConnect.Host + endpoint + "/" + id);
            return item;
        }

        public async Task<RegionEntity> Create(AddressEntity item)
        {
            var client = new HttpClient();
            var response = await client.PostAsJsonAsync(AppConnect.Host + endpoint, item);
            return await response.Content.ReadFromJsonAsync<RegionEntity>();
        }

        public async Task<RegionEntity> Update(RegionEntity item)
        {
            var client = new HttpClient();
            var response = await client.PutAsJsonAsync(AppConnect.Host + endpoint, item);
            return await response.Content.ReadFromJsonAsync<RegionEntity>();
        }

        public async Task Delete(int id)
        {
            var client = new HttpClient();
            await client.DeleteAsync(AppConnect.Host + endpoint + "/" + id);
        }
    }
}
