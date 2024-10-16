namespace Web_api_1.ViewModel
{
    public class EmployeeViewModel
    {
        public required string Name { get; set; }
        public required int Age { get; set; }
        public IFormFile Photo { get; set; }

    }
}
