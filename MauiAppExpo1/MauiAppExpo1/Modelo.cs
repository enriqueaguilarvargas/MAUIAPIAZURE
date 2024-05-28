using Microsoft.Maui.Maps;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;
using Maps = Microsoft.Maui.Controls.Maps.Map;

namespace MauiAppExpo1.ViewModels
{
    public class Modelo : INotifyPropertyChanged
    {
        private string _imagen;
        private string _imagenFondo;
        private string _nombre;
        private string _apellido;
        private string _conferencia;
        private string _fecha;
        private string _pais;
        private string _semblanza;
        private double _latitud;
        private double _longitud;
        private string _id;
        private Maps _map;
        public event PropertyChangedEventHandler PropertyChanged;
        public Modelo()
        {
            // Inicializa las propiedades con valores predeterminados o vacíos
            Imagen = "default_image.jpg"; // Ruta a una imagen predeterminada
            ImagenFondo = "default_background.jpg"; // Ruta a una imagen de fondo predeterminada
        }

        public string Imagen
        {
            get => _imagen;
            set => SetProperty(ref _imagen, value);
        }

        public string ImagenFondo
        {
            get => _imagenFondo;
            set => SetProperty(ref _imagenFondo, value);
        }

        public string Nombre
        {
            get => _nombre;
            set => SetProperty(ref _nombre, value);
        }

        public string Apellido
        {
            get => _apellido;
            set => SetProperty(ref _apellido, value);
        }

        public string Conferencia
        {
            get => _conferencia;
            set => SetProperty(ref _conferencia, value);
        }

        public string Fecha
        {
            get => _fecha;
            set => SetProperty(ref _fecha, value);
        }

        public string Pais
        {
            get => _pais;
            set => SetProperty(ref _pais, value);
        }

        public string Semblanza
        {
            get => _semblanza;
            set => SetProperty(ref _semblanza, value);
        }

        public double Latitud
        {
            get => _latitud;
            set => SetProperty(ref _latitud, value);
        }

        public double Longitud
        {
            get => _longitud;
            set => SetProperty(ref _longitud, value);
        }

        public string ID
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        public Maps Mapa
        {
            get => _map;
            set => SetProperty(ref _map, value);
        }

        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
                return false;

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public async Task ConsultarRegistroAsync()
        {
            if (string.IsNullOrWhiteSpace(ID))
                return;
            string url = $"https://apiexpo.azurewebsites.net/Principal/ConsultarRegistro?ID={ID}";
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    var response = await client.GetStringAsync(url);
                    var registros = JsonSerializer.Deserialize<List<Registro>>(response);

                    if (registros != null && registros.Count > 0)
                    {
                        var registro = registros[0];

                        Nombre = registro.Nombre;
                        Apellido = registro.Apellido;
                        Conferencia = registro.Conferencia;
                        Fecha = registro.Fecha;
                        Imagen = registro.Imagen;
                        ImagenFondo = registro.ImagenFondo;
                        Pais = registro.Pais;
                        Semblanza = registro.Semblanza;
                        Latitud = double.Parse(registro.Latitud);
                        Longitud = double.Parse(registro.Longitud);
                        Location location = new Location(Latitud, Longitud);
                        MapSpan mapSpan = new MapSpan(location, 0.01, 0.01);
                        Mapa.MoveToRegion(mapSpan);
                        Mapa.MapType = MapType.Satellite;
                    }
                }
                catch (JsonException jsonEx)
                {
                    // Captura y muestra el JSON recibido en caso de error de deserialización
                    Console.WriteLine($"Error deserializando JSON: {jsonEx.Message}");
                    Console.WriteLine(await client.GetStringAsync(url));
                }
                catch (Exception ex)
                {
                    // Manejo de otros errores
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }

    public class Registro
    {
        [JsonPropertyName("nombre")]
        public string Nombre { get; set; }

        [JsonPropertyName("apellido")]
        public string Apellido { get; set; }

        [JsonPropertyName("conferencia")]
        public string Conferencia { get; set; }

        [JsonPropertyName("fecha")]
        public string Fecha { get; set; }

        [JsonPropertyName("imagen")]
        public string Imagen { get; set; }

        [JsonPropertyName("imagenFondo")]
        public string ImagenFondo { get; set; }

        [JsonPropertyName("pais")]
        public string Pais { get; set; }

        [JsonPropertyName("semblanza")]
        public string Semblanza { get; set; }

        [JsonPropertyName("latitud")]
        public string Latitud { get; set; }

        [JsonPropertyName("longitud")]
        public string Longitud { get; set; }
    }
}
