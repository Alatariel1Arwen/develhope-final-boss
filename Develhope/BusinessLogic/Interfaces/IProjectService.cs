using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Develhope.Models;
using Develhope.Models.DTOs;

namespace Develhope.BusinessLogic.Interfaces
{
    public interface IProjectService
    {
        Task<List<ProjectListDto>> GetAllAsync();
        Task<List<ProjectListDto>> GetNotExpiredAsync();
        Task CreateAsync(Project project);
        Task <Project> GetByIdAsync(int id);
        Task DeleteByIdAsync(int id);

    }
}