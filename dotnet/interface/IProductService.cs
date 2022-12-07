using ProductApp.Models.Domain;
using ProductApp.Models.Requests.Product;
using System.Collections.Generic;

namespace ProductApp.Services.Interfaces
{
    public interface IProductService
    {
        int Add(ProductAddRequest model);
        void Delete(int id);
        Product GetById(int id);
        List<Product> GetByMake(string make);
        void Update(ProductUpdateRequest model);
    }
}