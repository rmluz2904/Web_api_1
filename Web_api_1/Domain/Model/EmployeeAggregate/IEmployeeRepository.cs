﻿using Web_api_1.Domain.DTOS;

namespace Web_api_1.Domain.Model.EmployeeAggregate;
public interface IEmployeeRepository
{
    void Add(Employee employee);
    List<EmployeeDTO> Get(int pageNumber, int pageQuantity);
    Employee? Get(int id);

}

