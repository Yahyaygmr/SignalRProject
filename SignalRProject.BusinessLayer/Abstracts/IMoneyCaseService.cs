﻿using SignalRProject.BusinessLayer.Abstracts.Generics;
using SignalRProject.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRProject.BusinessLayer.Abstracts
{
    public interface IMoneyCaseService : IGenericService<MoneyCase>
    {
        decimal TotalMoneyCaseAmount();
    }
}
