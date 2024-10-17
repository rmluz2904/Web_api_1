﻿namespace Web_api_1.Model
{
    public interface IEmployeeRepository
    {
        void Add(Employee employee);
        List<Employee> Get(int pageNumber, int pageQuantity); 
        Employee? Get(int id);

    }
}
