﻿using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace OrderBacklogApi.Data
{
    public class OrderContext : DbContext
    {

        public OrderContext(DbContextOptions<OrderContext> options)
        : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; } = null!;

    }
}
