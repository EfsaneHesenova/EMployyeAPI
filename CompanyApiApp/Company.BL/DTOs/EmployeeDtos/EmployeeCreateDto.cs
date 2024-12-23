using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.BL.DTOs.EmployeeDtos
{
    public class EmployeeCreateDto
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int DepartmentId { get; set; }
    }

    public class EmployeeCreateDtoValidation : AbstractValidator<EmployeeCreateDto>
    {
        public EmployeeCreateDtoValidation()
        {
            {
                RuleFor(b => b.Name).NotEmpty()
                .WithMessage("Name cannot be empty")
                .NotNull().WithMessage("Name cannot be null")
                .MaximumLength(128).WithMessage("Maximum length is 128");

                RuleFor(b => b.SurName).NotEmpty()
                .WithMessage("SurName cannot be empty")
                .NotNull().WithMessage("SurName cannot be null")
                .MaximumLength(128).WithMessage("Maximum length is 128");




            }
        }
    }
}
