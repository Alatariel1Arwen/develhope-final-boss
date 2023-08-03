using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Develhope.BusinessLogic.Interfaces;
using Develhope.Models;
using Develhope.Models.DTOs;
using Develhope.DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace Develhope.Controllers
{
    [ApiController]
    [Route("api/")]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        [Route("all")]
        public async Task<List<ProjectListDto>> GetAllAsync()
        {

            return await _projectService.GetAllAsync();
        }

        [HttpGet]
        [Route("expired")]
        public async Task<List<ProjectListDto>> GetNotExpiredAsync()
        { 
            return await _projectService.GetNotExpiredAsync();
        }

        [HttpGet]
        [Route("{id}")]
        public Task<Project> GetByIdAsync(int id)
        {
            return _projectService.GetByIdAsync(id);
        }

        [HttpPost]
        public async Task CretateAsync([FromBody] Project project)
        {
            await _projectService.CreateAsync(project);
        }

        [HttpPut]
        public Task UpdateAsync([FromBody] Project project)
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task DeleteAsync(int id)
        {
            await _projectService.DeleteByIdAsync(id);
        }
    }
}