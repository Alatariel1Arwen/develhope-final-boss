using System;
using System.Collections.Generic;
using System.Linq;
using Develhope.DataAccess.Interfaces;
using Develhope.Models;
using Develhope.Shared;
using System.Text.Json;

namespace Develhope.DataAccess
{
    public class ProjectRepository : IRepository<Project>
    {
        private static readonly string _PROJECT_DATA_PATH = Constants.DATA_PATH + "projects.json";
        private JsonSerializerOptions Options = new ()
        {
            PropertyNameCaseInsensitive = true,
        };

        public async Task CreateAsync(Project item)
        {
            var allProjects = await GetAllAsync();
            allProjects.Add(item);

            await File.WriteAllTextAsync(_PROJECT_DATA_PATH, JsonSerializer.Serialize(allProjects, Options));
        }

        //public async Task CreateAsyncJob(Job job)
        //{
        //    var allProjects = await GetAllAsync();
        //   allProjects.Add(job);
        //    await File.WriteAllTextAsync(_PROJECT_DATA_PATH, JsonSerializer.Serialize(allProjects, Options));
        //}

        public async Task DeleteByIdAsync(int id)
        {
            var allProjects = await GetAllAsync();
            foreach (var item in allProjects)
            {
                if (item.Id == id)
                {
                    allProjects.Remove(item);
                }
            }
        }

        public async Task<List<Project>> GetAllAsync()
        {
            if (!File.Exists(_PROJECT_DATA_PATH))
            {
                return new List<Project>();
            }
            var file = await File.ReadAllTextAsync(_PROJECT_DATA_PATH);

            return JsonSerializer.Deserialize<List<Project>>(file, Options) ?? new List<Project>();
        }

        public async Task<List<Project>> GetNotExpiredAsync()
        {
            var notExpired = new List<Project>();
            var allProjects = await GetAllAsync();
            var currentDate = DateTime.Now;
            foreach (var item in allProjects)
            {
                if (item.DeliveryDate < currentDate)
                {
                    notExpired.Add(item);
                }
            }
            return notExpired;
        }

        public async Task<Project> GetByIdAsync(int id)
        {
            var allProjects = await GetAllAsync();
            var getID = new Project();
            foreach (var item in allProjects) {
                if  (item.Id == id) {
                    allProjects.Remove(item);
                    getID = item;
                    return item;
                }
            }
            return getID;
        }

        public async Task UpdateAsync(Project item)
        {
            var allProjects = await GetAllAsync();
            var getID = new Project();
            foreach (var foo in allProjects)
            {
                if (foo.Id == item.Id)
                {
                    foo.Id = item.Id;
                    foo.Title = item.Title;
                    foo.Description = item.Description;
                    foo.DeliveryDate = item.DeliveryDate;
                }
            }
        }
    }
}