﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekatASP.Application.UseCases
{
    public interface ICommand<TRequest> : IUseCase
    {
        void Execute(TRequest sentRequest);
    }
}
