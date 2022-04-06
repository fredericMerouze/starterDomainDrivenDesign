﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateDomainDrivenDesign.Application.Contracts
{
    public interface IApplicationDbContext
    {
        DbSet<Domain.Entities.Task> Tasks { get; set; }
    }
}