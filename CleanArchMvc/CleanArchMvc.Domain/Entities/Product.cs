using System;

public sealed class Product : Entity
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public decimal Price { get; private set; }
    public int Stock { get; private set; }
    public string Image { get; private set; }

    public Product(string name, string description, decimal price, int stock, string image)
    {
        ValidateDomain(name, description, price, stock, image);
    }

    public Product(int id, string name, string description, decimal price, int stock, string image)
    {
        DomainExceptionCalidation.When(id < 0, "Invalid Id value.");
        Id = id;
        ValidateDomain(name, description, price, stock, image);
    }

    public void Upadte(string name, string description, decimal price, int stock, string image, int categoryId)
    {
        ValidateDomain(name, description, price, stock, image);
        CategoryId = categoryId;
    }

    private void ValidateDomain(string name, string description, decimal price, int stock, string image)
    {
        DomainExceptionCalidation.When(string.IsNullOrEmpty(name),
            "Invalid name. Name is required");

        DomainExceptionCalidation.When(name.Lenght < 3),
            "Invalid name. too short, mininum 3 characteres");

        DomainExceptionCalidation.When(string.IsNullOrEmpty(description),
            "Invalid name. Description is required");

        DomainExceptionCalidation.When(description.Length < 5,
            "Invalid description. too short, mininum 5 characteres");

        DomainExceptionCalidation.When(price < 0,
            "Invalid price value");

        DomainExceptionCalidation.When(stock < 0,
            "Invalid price stock");

        DomainExceptionCalidation.When(image.Length > 250,
            "Invalid image name,  too long, maximum 250 characteres");

        Name = name;
        Description = description;
        Price = price;
        Stock = stock;
        Image = image;
    }

    public int CategoryId { get; set; }

    public Category Category { get; set; }
}
