﻿using CryptoWatcher.Application.Requests;
using CryptoWatcher.Domain.Messages;
using FluentValidation;

namespace CryptoWatcher.Application.Validators
{
    public class AddIndicatorValidator : AbstractValidator<AddIndicatorRequest>
    {
        public AddIndicatorValidator()
        {
            RuleFor(x => x.IndicatorId)
                .Matches("^[a-z\\d-]+$")
                .WithMessage(nameof(IndicatorMessage.IndicatorIdHasInvalidFormat) + " " + IndicatorMessage.IndicatorIdHasInvalidFormat);
        }
    }
}
