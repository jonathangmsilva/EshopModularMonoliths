﻿using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace Ordering.Data;

public class OrderingDbContext : DbContext
{

    public OrderingDbContext(DbContextOptions<OrderingDbContext> options):base(options){}

    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("ordering");
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}
