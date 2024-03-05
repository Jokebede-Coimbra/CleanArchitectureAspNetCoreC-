using System;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    // Uma categoria pode ter um ou mais produtos
    public ICollection<Product> Products { get; set; }
}
