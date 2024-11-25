using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;


namespace DBFIRSTAPP;

public partial class MyDataBaseContext : DbContext
{
    public MyDataBaseContext()
    {
    }

    public MyDataBaseContext(DbContextOptions<MyDataBaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("Data Source=D:\\MyDataBase.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
