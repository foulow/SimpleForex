using System;
using FluentValidation;
using SimpleForex.Application.Collections;
using SimpleForex.Application.DTOs;

namespace SimpleForex.API.Validations
{
    public class CurrencyPurchaseDTOValidation : AbstractValidator<CurrencyPurchaseDTO>
    {
        public CurrencyPurchaseDTOValidation()
        {
            RuleFor(cp => cp.Amount)
                .NotNull()
                .WithErrorCode("BR-1001");

            RuleFor(cp => cp.MadeOn)
                .NotNull()
                .NotEmpty()
                .InclusiveBetween(DateTime.MinValue, DateTime.MaxValue)
                .WithErrorCode("BR-1002");

            RuleFor(cp => cp.UserId)
                .NotNull()
                .NotEmpty()
                .MinimumLength(5)
                .MaximumLength(25)
                .Matches(Regexs.UserIdRegex)
                .WithErrorCode("BR-1003");

            RuleFor(cp => cp.CurrencyId)
                .NotNull()
                .GreaterThan(0)
                .WithErrorCode("BR-1004");
        }
    }
}
