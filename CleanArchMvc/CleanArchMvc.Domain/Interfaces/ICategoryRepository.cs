using System;
using System.Threading.Tasks;


public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetCategories();

    Task<Category> GetById(int? id);

    Task<Category> Create(Category category);
    Task<Category> Update(Category category);
    Task<Category> Remove(Category category);
   
}
