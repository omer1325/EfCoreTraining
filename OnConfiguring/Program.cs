// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");

public class ECommerceContext : DbContext
{
    public DbSet<Product> Products{ get; set;}


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost,1544; Database=ECommerce; User=sa; Password=1q2w3e");
        //Provider
        //ConnectionString
        //Lazy Loading
        //vb.
    }
}

public class Product
{

}

//OnConfiguring İle Konfigürasyon Ayarlarını Gerçekleştirmek
#region Basit  Düzeyde Entity Tanımlama kuralları
//Ef Core toool'unu yapılandırmak için kullandığımız bir metottur.
//Context nesnesinde override edilerek kullanılmaktadır.
#endregion