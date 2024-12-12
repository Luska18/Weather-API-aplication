using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WeatherAPP.Models;

namespace WeatherAPP.Services
{
    internal class ResponseService
    {
        private HttpClient httpClient;
        private FullResponse fullResponse;
        private JsonSerializerOptions jsonSerializerOptions;
        Uri uri = new Uri("http://api.openweathermap.org/data/2.5/weather?");
        String key = "appid=ab73f17bcbdd1656c1518494388ce6e8";
        String options = "lang=pt_br&units=metric";
        public ResponseService()
        {

            httpClient = new HttpClient();
            jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true,
            };


        }



        public async Task<FullResponse> GetResponseByCidadeAsync(String cidade)
        {
            Debug.WriteLine("Chamou o GetResponseByIdAsync");

            try
            {
                HttpResponseMessage response = await httpClient.GetAsync($"{uri}q={cidade}&{options}&{key}");
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();

                    Debug.WriteLine($"Resposta JSON: {content}");

                    fullResponse = JsonSerializer.Deserialize<FullResponse>(content, jsonSerializerOptions);
                }
                else
                {
                    Debug.WriteLine($"Erro na chamada à API: {response.StatusCode}");
                }
            }
            catch (JsonException ex)
            {
                Debug.WriteLine($"Exceção ocorrida: {ex.Message}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exceção ocorrida: {ex.Message}");
            }
            
            return fullResponse;
        }


        public async Task<FullResponse> GetResponseByCoordAsync(String lat, String lon) // TASK: usado no await
        {
            Debug.WriteLine("Chamou o GetResponseByCoordAsync");

            try
            {
                HttpResponseMessage response = await httpClient.GetAsync($"{uri}lat={lat}&lon={lon}&{options}&{key}");
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();

                    Debug.WriteLine($"Resposta JSON: {content}");

                    fullResponse = JsonSerializer.Deserialize<FullResponse>(content, jsonSerializerOptions);
                }
                else
                {
                    Debug.WriteLine($"Erro na chamada à API: {response.StatusCode}");
                }
            }
            catch (JsonException ex)
            {
                Debug.WriteLine($"Exceção ocorrida: {ex.Message}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exceção ocorrida: {ex.Message}");
            }

            return fullResponse;
        }
    }
}
