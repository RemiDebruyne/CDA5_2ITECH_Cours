using DashboardApi.Application.Dto;
using DashboardApi.Application.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DashboardApi.Api.Controller;
[Route("api/dashboards")]
[ApiController]
public class DashboardController(IDashboardService service) : ControllerBase
{
    [HttpGet]

    public async Task<ActionResult<DashboardResponseDto>> Get()
    {
        return Ok(await service.GetDashboard());
    }
}
