using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using TeamlanceAPI.Data;
using TeamlanceAPI.Filter;
using TeamlanceAPI.Models;
using WebApi.Helpers;

namespace TeamlanceAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectsController : Controller
    {
        private readonly ProjectsAPIDbContext dbContext;

        public ProjectsController(ProjectsAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        //[Authorize]
        [HttpGet]
        public async Task<IActionResult> GetProjects([FromQuery] PaginationFilter filter)
        {
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            var pagedData = await dbContext.Projects.OrderBy(x => x.seriNo).Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
                .Take(validFilter.PageSize).ToListAsync();
            var totalRecord = await dbContext.Projects.CountAsync();
            //var response = await dbContext.Projects.ToListAsync();

            return Ok(new PagedResponse<List<Project>>(pagedData, totalRecord));
        }
        //[Authorize]
        [HttpPost]
        public async Task<IActionResult> AddProject(AddProjectRequest addProjectRequest)
        {
            var project = new Project()
            {
                id = Guid.NewGuid(),
                seriNo = addProjectRequest.seriNo,
                projectName = addProjectRequest.projectName,
                clientName = addProjectRequest.clientName,
                startDate = addProjectRequest.startDate,
                projectAmount = addProjectRequest.projectAmount,
                headCount = addProjectRequest.headCount,
                currentStatus = addProjectRequest.currentStatus
            };

            await dbContext.Projects.AddAsync(project);
            await dbContext.SaveChangesAsync();

            return Ok();
        }
        //[Authorize]
        [HttpGet]
        [Route("count")]
        public async Task<IActionResult> GetCountList()
        {
             
            var query = dbContext.Projects.GroupBy(pj => pj.currentStatus)
            .Select(group => new { Category = group.Key, Count = group.Count() });

            return Ok(query);
        }
        //[Authorize]
        [HttpGet]
        [Route("new-hire")]
        public async Task<IActionResult> GetNewHireCount()
        {

            var query = new {Count = 5};

            return Ok(query);
        }

    }
}
