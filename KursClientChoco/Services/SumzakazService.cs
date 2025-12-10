using KursClientChoco.Model;
using KursClientChoco.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace KursClientChoco.Services
{
    internal class SumzakazService : BaseService<Sumzakaz>

    {
        private HttpClient httpClient;
        public SumzakazService()
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer" + Regi.access_token);
        }
        public override async Task Add(Sumzakaz obj)
        {
            try
            {
                JsonContent content = JsonContent.Create(obj);
                using var response = await httpClient.PostAsync("https://localhost:7229/api/Chitateli", content);
                string responseText = await response.Content.ReadAsStringAsync();
                if (responseText != null)
                {
                    Sumzakaz resp = JsonSerializer.Deserialize<Sumzakaz>(responseText!)!;
                    if (resp == null) MessageBox.Show(responseText);
                }
            }
            catch { }

        }
        public override async Task Delete(Sumzakaz obj)
        {
            using var response = await httpClient.DeleteAsync($"https://localhost:7229/api/Chitateli/{obj.Idzakaza}");

        }

        public override async Task<List<Sumzakaz>> GetAll()
        {
            return (await httpClient.GetFromJsonAsync<List<Sumzakaz>>("https://localhost:7229/api/Chitateli"))!;
        }


        public override Task<List<Sumzakaz>> Search(string str)
        {
            throw new NotImplementedException();
        }

        public override async Task Update(Sumzakaz obj)
        {
            try
            {
                JsonContent content = JsonContent.Create(obj);
                using var response = await httpClient.PutAsync($"https://localhost:7229/api/Chitateli/{obj.Idzakaza}", content);
                string responseText = await response.Content.ReadAsStringAsync();
                if (responseText != null)
                {
                    Sumzakaz resp = JsonSerializer.Deserialize<Sumzakaz>(responseText!)!;
                    if (resp == null) MessageBox.Show(responseText);
                }

            }
            catch { }
        }

    }
}
