using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Web_api_1.Application.ViewModel;
using Web_api_1.Domain.DTOS;
using Web_api_1.Domain.Model.EmployeeAggregate;

namespace Web_api_1.Controllers
{
    [ApiController]
    [Route("api/v1/employee")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ILogger<EmployeeController> _logger;
        private readonly IMapper _mappper;

        public EmployeeController(IEmployeeRepository employeeRepository, ILogger<EmployeeController> logger, IMapper mappper)
        {
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mappper = mappper ?? throw new ArgumentNullException(nameof(mappper));
        }

        [Authorize]
        [HttpPost]
        public IActionResult Add([FromForm] EmployeeViewModel employeeView)
        {
            var filepath = Path.Combine("Storage", employeeView.Photo.FileName);

            using Stream fileStream = new FileStream(filepath, FileMode.Create);

            employeeView.Photo.CopyTo(fileStream);

            var employee = new Employee(employeeView.Name, employeeView.Age, filepath);
            _employeeRepository.Add(employee);
            return Ok("Funcionário adicionado com sucesso.");
        }

        [Authorize]
        [HttpPost]
        [Route("{id}/download")]
        public IActionResult DownloadPhoto(int id)
        {
            var employee = _employeeRepository.Get(id);

            var dataBytes = System.IO.File.ReadAllBytes(employee.photo);

            return File(dataBytes, "image/png");
        }

        
        [HttpGet]
        public IActionResult Get(int pageNumber, int pageQuantity)
        {
            _logger.Log(LogLevel.Error, "Erro!");
            var employees = _employeeRepository.Get(pageNumber, pageQuantity);

            //throw new Exception("Erro de teste"); -> Erro criado propositadamente.

            _logger.LogInformation("Teste");

            return Ok(employees);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Search(int id)
        {
            var employees = _employeeRepository.Get(id);
            var employeesDTOS = _mappper.Map<EmployeeDTO>(employees);

            return Ok(employeesDTOS);
        }
    }
}
