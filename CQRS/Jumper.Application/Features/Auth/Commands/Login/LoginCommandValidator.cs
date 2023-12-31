﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jumper.Application.Features.Auth.Commands.Login
{
    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(w => w.UserName).NotNull().NotEmpty().WithMessage("Lütfen Kullanıcı Adınızı Girin.");
            RuleFor(w => w.Password).NotNull().NotEmpty().WithMessage("Lütfen Şifrenizi Girin.");
        }
    }
}
