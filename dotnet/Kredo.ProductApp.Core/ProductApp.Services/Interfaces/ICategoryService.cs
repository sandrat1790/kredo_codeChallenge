using ProductApp.Models.Domain;
using ProductApp.Models.Requests.Category;
using System.Collections.Generic;

namespace ProductApp.Services.Interfaces
{
    public interface ICategoryService
    {
        int Add(CategoryAddRequest model);
        void Delete(int id);
        List<Category> GetAll();
        Category GetById(int id);
        void Update(CategoryUpdateRequest model);
    }
}