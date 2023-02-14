using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Newtonsoft.Json.Linq;
using System;
using System.Net;
using System.Text.Json;

namespace WebInventario.Code
{
    public static class ApiConsumer<T>
    {
        public static T[] Select_SearchFor(string url, string? searchFor)
        {
            var api = new System.Net.WebClient();
            api.Headers.Add("Content-Type", "application/json");
            api.Headers.Add("Accept", "application/json");
            var json = api.DownloadString(url + "?searchFor=" + searchFor);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T[]>(json);
        }
        
        public static T[] Select(string url)
        {
            var api = new System.Net.WebClient();
            api.Headers.Add("Content-Type", "application/json");
            api.Headers.Add("Accept", "application/json");
            var json = api.DownloadString(url);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T[]>(json);
        }

        public static T Select_One(string url)
        {
            var api = new System.Net.WebClient();
            api.Headers.Add("Content-Type", "application/json");
            api.Headers.Add("Accept", "application/json");
            var json = api.DownloadString(url);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json);
        }

        public static T Insertar(string url, T data)
        {
            var api = new System.Net.WebClient();
            api.Headers.Add("Content-Type", "application/json");
            api.Headers.Add("Accept", "application/json");
            var json = api.UploadString(url, "POST", Newtonsoft.Json.JsonConvert.SerializeObject(data));
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json);
        }

        public static void Actualizar(string url, T data)
        {
            var api = new System.Net.WebClient();
            api.Headers.Add("Content-Type", "application/json");
            api.Headers.Add("Accept", "application/json");
            api.UploadString(url, "PUT", Newtonsoft.Json.JsonConvert.SerializeObject(data));
        }

        public static void Eliminar(string url)
        {
            var api = new System.Net.WebClient();
            api.Headers.Add("Content-Type", "application/json");
            api.Headers.Add("Accept", "application/json");
            api.UploadString(url, "DELETE", "");
        }
    }
}
