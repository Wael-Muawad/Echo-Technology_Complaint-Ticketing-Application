using Application.Services;
using Domain.ApiDTO.Demands;
using Domain.ApiDTO.Users;
using Domain.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    //[Authorize(Roles = "USER")]
    public class DemandsController : ControllerBase
    {
        private readonly IDemandService _demandService;
        private readonly IAuthService _authService;

        public DemandsController(IDemandService demandService, IAuthService authService)
        {
            _demandService = demandService;
            _authService = authService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(DemandCreateDto demandCreateDto)
        {
            var result = await _demandService.Create(demandCreateDto);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetByID(int id)
        {
            var result = await _demandService.GetByID(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllByComplaint(int complaintID)
        {
            var result = await _demandService.GetAllByComplaint(complaintID);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        //[HttpPut]
        //public async Task<IActionResult> Update(DemandUpdateDto demandUpdateDto)
        //{
        //    //var result = await _demandService.Create(demandCreateDto);
        //    return result.Success ? Ok(result) : BadRequest(result);
        //}
    }
}
