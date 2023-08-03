using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Develhope.BusinessLogic.Interfaces;
using Develhope.DataAccess.Interfaces;
using Develhope.Models;
using Develhope.Models.DTOs;

namespace Develhope.BusinessLogic
{
    public class ProjectService : IProjectService
    {
        private readonly IRepository<Project> _projectRepository;

        public ProjectService(IRepository<Project> repository)
        {
            _projectRepository = repository;
        }

        public async Task CreateAsync(Project project)
        {
            await _projectRepository.CreateAsync(project);
        }

        public async Task<List<ProjectListDto>> GetAllAsync()
        {
            return (await _projectRepository.GetAllAsync())
                .ConvertAll(x => new ProjectListDto
                {
                    Id = x.Id,
                    Title = x.Title,
                    DeliveryDate = x.DeliveryDate
                });
        }

        public Task<Project> GetByIdAsync(int id)
        {
            return _projectRepository.GetByIdAsync(id);
        }

        public async Task DeleteByIdAsync(int id)
        {
            await _projectRepository.DeleteByIdAsync(id);
        }

        public async Task<List<ProjectListDto>> GetNotExpiredAsync()
        {
            return (await _projectRepository.GetNotExpiredAsync())
                .ConvertAll(x => new ProjectListDto
                {
                    Id = x.Id,
                    Title = x.Title,
                    DeliveryDate = x.DeliveryDate
                });
        }

    }
}