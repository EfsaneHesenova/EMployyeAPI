using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.BL.DTOs.DepartmentDtos;

public class DepartmentUpdateDto
{
    public string Title { get; set; }
    public string Description { get; set; }
}
public class DepartmentUpdateDtoValidation : AbstractValidator<DepartmentUpdateDto>
{
    public DepartmentUpdateDtoValidation()
    {
        RuleFor(b => b.Title).NotEmpty()
        .WithMessage("Title cannot be empty")
        .NotNull().WithMessage("Title cannot be null")
        .MaximumLength(128).WithMessage("Maximum length is 128");

        RuleFor(b => b.Description).NotEmpty().NotNull()
            .WithMessage("Description cannot be null or empty")
            //.ExclusiveBetween(0,1000).WithMessage("Book price can not be below 0 or above 1000")
            .NotNull().WithMessage("Title cannot be null");




    }
}

