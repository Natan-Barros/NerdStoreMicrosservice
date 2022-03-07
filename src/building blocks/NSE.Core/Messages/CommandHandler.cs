﻿using FluentValidation.Results;
using NSE.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSE.Core.Messages
{
    public abstract class CommandHandler
    {
        protected ValidationResult ValidationResult;

        public CommandHandler()
        {
            ValidationResult = new ValidationResult();
        }

        protected void AdicionarError(string mensagem)
        {
            ValidationResult.Errors.Add(new ValidationFailure(string.Empty, mensagem));
        }

        protected async Task<ValidationResult> PersistirDados(IUnitOfWork uow)
        {
            if (!await uow.CommitAsync())
                AdicionarError("Houve um erro ao persistir os dados");

            return ValidationResult;
        }
    }
}
