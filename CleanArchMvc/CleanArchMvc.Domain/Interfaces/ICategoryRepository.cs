using System;
using System.Threading.Tasks;
using CleanArchMvc.Domain.Entities;

public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetCategories();

    Task<Category> GetById(int? id);

    Task<Category> Create(Categoty categoty);
    Task<Category> Update(Categoty categoty);
    Task<Category> Remove(Categoty categoty);
   
}
