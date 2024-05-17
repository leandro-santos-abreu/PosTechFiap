﻿using Application.Mediator.Command;
using Azure.Core;
using FluentValidation;
using System.Text.RegularExpressions;

namespace Application.Validator;
public partial class UpdateContactValidator : AbstractValidator<UpdateContactCommand>
{
    public UpdateContactValidator()
    {
        RuleFor(x => x.Telephone).Must(x => x.Length != 9);
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Telephone).NotEmpty();
        RuleFor(x => x.DDD).Must(x => x < 1);
        RuleFor(x => x.Name).Must(x => Regex.IsMatch(x, @"/^[A-ZÀ-Ÿ][A-zÀ-ÿ']+\s([A-zÀ-ÿ']\s?)*[A-ZÀ-Ÿ][A-zÀ-ÿ']+$/"));
        RuleFor(x => x.Email).Must(x => Regex.IsMatch(x, @"^[\w.-]+@[a-zA-Z\d.-]+.[a-zA-Z]{2,}$"));     

    }
}