﻿// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");

public class ECommerceDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Customer> Customers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost; 1455; Database=ECommerceDb; User Id=sa; Password=1q2w3e");
    }
}

//Entity

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
    public float Price { get; set; }
}

//Entity

public class Customer
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}