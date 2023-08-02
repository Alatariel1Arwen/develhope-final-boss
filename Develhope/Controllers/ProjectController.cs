using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Develhope.BusinessLogic.Interfaces;
using Develhope.Models;
using Develhope.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Develhope.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        [Route("All")]
        public async Task<List<ProjectListDto>> GetAllAsync()
        {
            return await _projectService.GetAllAsync();
        }

        [HttpPost]
        public async Task CretateAsync([FromBody] Project project)
        {
            await _projectService.CreateAsync(project);
        }
    }
}