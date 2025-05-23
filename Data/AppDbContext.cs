﻿using LGS_Tracking_Application.Service;
using LGS_Tracking_Application.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IO;

public class AppDbContext : DbContext
{

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<User> Users { get; set; }
    public DbSet<Result> Results { get; set; }
    public DbSet<Admin> admins { get; set; }

    private readonly string _connectionString;

    // Constructor that accepts a connection string
    public AppDbContext(string connectionString)
    {
        _connectionString = connectionString;
    }

    // Override OnConfiguring to set up the database connection
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!_connectionString.IsNullOrEmpty())
        {
            optionsBuilder.UseSqlServer(_connectionString);

        }
    }



}
