using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Context
{
    public partial class AnalystChallangeContext : DbContext
    {
        public AnalystChallangeContext(DbContextOptions<AnalystChallangeContext> options) : base(options)
        {
        }

        public virtual DbSet<SensorEvent> Evento { get; set; }
    }
}
