using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReportTestWebApi.Models;
using ReportTestWebApi.Repositories.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ReportTestWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DeviceController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWOrk;

        public DeviceController(IUnitOfWork unitOfWOrk)
        {
            this.unitOfWOrk = unitOfWOrk;
        }
        [HttpPost]
        public IActionResult GetAllDevices(Credential credential)
        {
            try
            {
                if (!unitOfWOrk.ApiRepository.Auntheticate(credential.API))
                    return Unauthorized();
                else
                {
                    List<string> groups = unitOfWOrk.ApiRepository.GetListFromCommaSeparatedString(credential.GroupFilter);
                    var device = unitOfWOrk.ApiRepository.GetActiveVehicle(groups);
                    var selectedVehicle = device.Select(x => new
                    {
                        Id = x.Id.ToString(),
                        Name = x.Name
                    }).ToList();
                    return Ok(selectedVehicle);
                }

            }
            catch (Exception ex)
            {
                var errorObjectResult = new ObjectResult(new
                {
                    Message = "Error retrieving data from the database",
                    Status = "Error",
                    Exception = ex.Message

                });
                errorObjectResult.StatusCode = StatusCodes.Status500InternalServerError;
                return errorObjectResult;

            }

        }
    }
}
