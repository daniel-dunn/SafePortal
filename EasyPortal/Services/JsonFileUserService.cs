using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using EasyPortal.Models;
using Microsoft.AspNetCore.Hosting;

namespace EasyPortal.Services
{
    public class JsonFileUserService
    {

        public JsonFileUserService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public IWebHostEnvironment WebHostEnvironment { get; }

        private string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "users.json"); }
        }

        public User GetUser()
        {
            using (var jsonFileReader = File.OpenText(JsonFileName))
            {
#pragma warning disable CS8603 // Possible null reference return.
                return JsonSerializer.Deserialize<User>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
#pragma warning restore CS8603 // Possible null reference return.
            }
        }
    }
}
