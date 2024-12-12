using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using WeatherAPP.Models;
using WeatherAPP.Services;

namespace WeatherAPP.ViewModels
{
    partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        public String cidade;

        [ObservableProperty]
        public String descricao;

        [ObservableProperty]
        public String temperatura;

        [ObservableProperty]
        public String temperaturaMin;

        [ObservableProperty]
        public String temperaturaMax;

        [ObservableProperty]
        public String sensacao;

        [ObservableProperty]
        public String umidade;

        [ObservableProperty]
        public string imagem;


        private ResponseService responseService = new ResponseService();

        public ICommand BuscarCommand { get; set; }


        public MainViewModel()
        {
            BuscarCommand = new Command(Buscar);
            GetaLatLongAsync();
        }

        public async void Buscar()
        {
            if (Cidade == null)
            {
                Debug.WriteLine("Cidade nulo");
                return;
            }
            FullResponse fullResponse = await responseService.GetResponseByCidadeAsync(Cidade);

            AtualizarTela(fullResponse);
        }

        public async Task<(double Latitude, double Longitude)> GetaLatLongAsync()
        {
            try
            {
                
                var location = await Geolocation.GetLocationAsync(new GeolocationRequest
                {
                    DesiredAccuracy = GeolocationAccuracy.Medium,
                    Timeout = TimeSpan.FromSeconds(10)
                });

                if (location != null)
                {
                    Debug.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}");
                    FullResponse fullResponse = await responseService.GetResponseByCoordAsync(location.Latitude.ToString(),location.Longitude.ToString());
                    AtualizarTela(fullResponse);
                    return (location.Latitude, location.Longitude);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Erro ao obter localização: {ex.Message}");
            }
            return (0, 0);
        }

        public void AtualizarTela(FullResponse fullResponse)
        {
            Descricao = fullResponse.Weather[0].Description;
            Temperatura = fullResponse.Main.Temp.ToString() + " °C";
            TemperaturaMax = fullResponse.Main.TempMax.ToString() + " °C";
            TemperaturaMin = fullResponse.Main.TempMin.ToString() + " °C";
            Sensacao = fullResponse.Main.FeelsLike.ToString() + " °C";
            Umidade = fullResponse.Main.Humidity.ToString() + "%";
            Imagem = fullResponse.Weather[0].Main.ToLower() + ".png";
            Debug.WriteLine(Imagem);
        }
    }
}