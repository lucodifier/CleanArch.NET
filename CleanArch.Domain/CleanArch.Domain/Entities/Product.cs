namespace CleanArch.Domain.Entities;

public class Product
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Name { get; private set; }
    public decimal Price { get; private set; }

    public Product(string name, decimal price)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Nome inválido");

        if (price <= 0)
            throw new ArgumentException("Preço deve ser maior que zero");

        Name = name;
        Price = price;
    }

    public void UpdateName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Nome inválido");

        Name = name;
    }

    public void UpdatePrice(decimal price)
    {
        if (price <= 0)
            throw new ArgumentException("Preço deve ser maior que zero");

        Price = price;
    }

    public void Update(string name, decimal price)
    {
        UpdateName(name);
        UpdatePrice(price);
    }
}
