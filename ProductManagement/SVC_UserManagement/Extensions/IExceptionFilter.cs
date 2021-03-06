﻿using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagement.Extensions
{
    interface IExceptionFilter: IFilterMetadata
    {
        void OnException(ExceptionContext context);
    }
}
