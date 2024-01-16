using Domain.ApiDTO.Complaints;
using Domain.ApiDTO.Demands;
using Domain.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    //todo auth
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ComplaintsController : ControllerBase
    {
        private readonly IComplaintService _complaintService;
        private readonly IFileService _fileService;

        public ComplaintsController(IComplaintService complaintService, IFileService fileService)
        {
            _complaintService = complaintService;
            _fileService = fileService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(ComplaintCreateDto complaintCreateDto)
        {
            //todo get user claims to get email 
            var filePath = await _fileService.SaveFile(complaintCreateDto.File);
            complaintCreateDto.SetFilePath(filePath);

            return Ok();
        }


        private void SaveFile()
        {
            // try catch with api response 
        }
    }
}
