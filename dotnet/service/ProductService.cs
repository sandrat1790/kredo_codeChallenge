using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ProductApp.Data.Providers;
using ProductApp.Models.Domain;
using ProductApp.Data;
using ProductApp.Models.Requests.Product;
using ProductApp.Services.Interfaces;

namespace ProductApp.Services
{
    public class ProductService : IProductService
    {
        IDataProvider _data = null;

        public ProductService(IDataProvider data)
        {
            _data = data;
        }

        public int Add(ProductAddRequest model)
        {
            int id = 0;

            _data.ExecuteNonQuery("dbo.Cars_Products_Insert",
                inputParamMapper: delegate (SqlParameterCollection collection)
                {
                    AddCommonParams(model, collection);

                    SqlParameter idOut = new SqlParameter("@Id", System.Data.SqlDbType.Int);
                    idOut.Direction = ParameterDirection.Output;

                    collection.Add(idOut);
                },
                returnParameters: delegate (SqlParameterCollection returnCollection)
                {
                    object objectId = returnCollection["@Id"].Value;

                    int.TryParse(objectId.ToString(), out id);
                });
            return id;
        }

        public void Update(ProductUpdateRequest model)
        {
            _data.ExecuteNonQuery("dbo.Cars_Products_Update",
                inputParamMapper: delegate (SqlParameterCollection collection)
                {
                    AddCommonParams(model, collection);

                    collection.AddWithValue("@Id", model.Id);
                },
                returnParameters: null);
        }

        public void Delete(int id)
        {
            _data.ExecuteNonQuery("dbo.Cars_Products_Delete",
                inputParamMapper: delegate (SqlParameterCollection collection)
                {
                    collection.AddWithValue("@Id", id);
                },
                returnParameters: null);
        }

        public Product GetById(int id)
        {
            Product product = null;

            _data.ExecuteCmd("dbo.Cars_Products_SelectById", 
                delegate (SqlParameterCollection paramCollection)
                {
                    paramCollection.AddWithValue("@Id", id);
                },
                delegate (IDataReader reader, short set)
                {
                
                    product = MapSingleProduct(reader);

                });
            return product;
        }

        public List<Product> GetByMake(string make)
        {
            List<Product> productList = null;

            _data.ExecuteCmd("dbo.Cars_Products_SelectByMake", 
                inputParamMapper: delegate (SqlParameterCollection collection)
                {
                    collection.AddWithValue("@Make", make);
                },
                singleRecordMapper: delegate (IDataReader reader, short set)
                {
                    
                    Product product = MapSingleProduct(reader);

                    if (productList == null)
                    {
                        productList = new List<Product>();
                    }
                    productList.Add(product);
                });
            return productList;
        }

        private static Product MapSingleProduct(IDataReader reader)
        {
            Product singleProduct = new Product();

            int startingIndex = 0;

            singleProduct.Id = reader.GetSafeInt32(startingIndex++);
            singleProduct.Make = reader.GetSafeString(startingIndex++);
            singleProduct.Name = reader.GetSafeString(startingIndex++);
            singleProduct.Price = reader.GetSafeDecimal(startingIndex++);
            singleProduct.Description = reader.GetSafeString(startingIndex++);
            singleProduct.ImageUrl = reader.GetSafeString(startingIndex++);

            return singleProduct;
        }

        private static void AddCommonParams(ProductAddRequest model, SqlParameterCollection collection)
        {
            collection.AddWithValue("@Make", model.Make);
            collection.AddWithValue("@Name", model.Name);
            collection.AddWithValue("@Price", model.Price);
            collection.AddWithValue("@Description", model.Description);
            collection.AddWithValue("@ImageUrl", model.ImageUrl);
        }
    }
}

