using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using RegisteredDoctors.Data.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace RegisteredDoctors.Data.DataBase
{
    public static class Preseeder
    {
        private static readonly string path =  Path.GetFullPath(@"Data/Json-Data/");

        public static async Task Seed(IApplicationBuilder applicationBuilder)
        {

                using var serviceScope = applicationBuilder.ApplicationServices.CreateScope();
                var context = serviceScope.ServiceProvider.GetService<RegisteredDoctorsContext>();
                context.Database.EnsureCreated();

                if (!context.registeredDoctors.Any())
                {
                    var userData = GetSeedData<RegisteredDoctor>(File.ReadAllText(path + "RegisteredDoctors.json"));
                    await context.registeredDoctors.AddRangeAsync(userData);
                    await context.SaveChangesAsync();
                }
         }

            private static List<T> GetSeedData<T>(string location)
            {
                var output = JsonSerializer.Deserialize<List<T>>(location, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return output;
            }
        }
    }
