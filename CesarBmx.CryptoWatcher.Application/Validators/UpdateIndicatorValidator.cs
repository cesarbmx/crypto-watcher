﻿using CesarBmx.CryptoWatcher.Application.Requests;
using CesarBmx.CryptoWatcher.Application.Messages;
using FluentValidation;

namespace CesarBmx.CryptoWatcher.Application.Validators
{
    public class UpdateIndicatorValidator : AbstractValidator<UpdateIndicator>
    {
        public UpdateIndicatorValidator()
        {
            RuleFor(x => x.Dependencies)
                .NotNull()
                .WithMessage(nameof(IndicatorMessage.DependenciesMustBeProvided) + " " + IndicatorMessage.DependenciesMustBeProvided);
        }
    }
}
