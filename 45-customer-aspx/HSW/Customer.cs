using Microsoft.EntityFrameworkCore;

namespace HSW;

public class ApplicationDbContext : DbContext
{
    public DbSet<Customer> Customers => Set<Customer>();

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
}

public class Customer
{
    public Customer(string name, string address, string iban)
    {
        this.Name = name;
        this.Address = address;
        this.Iban = iban;
    }

    public long Id { get; set; }

    public string Name { get; set; }

    public string Address { get; set; }

    public string Iban { get; set; }
}