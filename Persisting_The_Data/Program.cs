// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;

#region How to add Data ?
//ECommerceContext context = new();
//Product product = new()
//{
//    ProductName = "Product A",
//    Price = 1000
//};

#region context.AddAsync Function
//await context.AddAsync(urun);
#endregion
#region context.DbSet.AddAsync Function
//await context.Products.AddAsync(product);
#endregion

//await context.SaveChangesAsync(); 

#endregion

#region What Is SaveChanges?
//It is a function that creates insert, update and delete queries,
//sends them to the database and executes them with a transaction. If any of the generated queries fail, it rollbacks all transactions.
#endregion

#region How to Tell if Data Needs to be Added in Terms of EF Core?
//ECommerceContext context = new();
//Product product = new()
//{
//    ProductName = "Product B",
//    Price = 2000
//};

//Console.WriteLine(context.Entry(product).State );

//await context.AddAsync(product);

//Console.WriteLine(context.Entry(product).State);

//await context.SaveChangesAsync();

//Console.WriteLine(context.Entry(product).State);
#endregion


#region What Should Be Considered When Adding Multiple Data?
#region Let's Use SaveChanges Efficiently!
//Since the SaveChanges function will create a transaction every time it is triggered, we should avoid using it specifically for each transaction made with EF Core!
//Because it means extra cost for each transaction specific transaction database.
//Therefore, using savechanges at once as below in order to be able to send all our transactions to the database with a single transaction as much as possible will contribute both in terms of cost and manageability.

//ECommerceContext context = new();
//Product product1 = new()
//{
//    ProductName = "Product C",
//    Price = 2000
//};
//Product product2 = new()
//{
//    ProductName = "Product D",
//    Price = 2000
//};
//Product product3 = new()
//{
//    ProductName = "Product E,
//    Price = 2000
//};

//await context.AddAsync(product1);

//await context.AddAsync(product2);

//await context.AddAsync(product3);
//await context.SaveChangesAsync();
#endregion
#region AddRange
//ECommerceContext context = new();
//Product product1 = new()
//{
//    ProductName = "Product C",
//    Price = 2000
//};
//Product product2 = new()
//{
//    ProductName = "Product D",
//    Price = 2000
//};
//Product product3 = new()
//{
//    ProductName = "Product E,
//    Price = 2000
//};
//await context.Products.AddRangeAsync(product1, product2, product3);
//await context.SaveChangesAsync();
#endregion
#endregion


#region Obtaining the Generated Id of the Inserted Data
ECommerceContext context = new();
Product product = new()
{
    ProductName = "Product 0",
    Price = 2000
};
await context.AddAsync(product);
await context.SaveChangesAsync();
Console.WriteLine(product.Id);
#endregion
public class ECommerceContext : DbContext
{
    public DbSet<Product> Products { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost,1544; Database=ECommerce; User=sa; Password=1q2w3e");
    }
}

public class Product
{
    public int Id { get; set; }
    public string ProductName { get; set; }
    public float Price { get; set; }
}