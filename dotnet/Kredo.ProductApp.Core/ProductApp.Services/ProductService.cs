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

            _data.ExecuteNonQuery("dbo.Products_Insert",
                inputParamMapper: delegate (SqlParameterCollection collection)
                {
                    AddCommonParams(model, collection);

                    SqlParameter idOut = new SqlParameter("@id", System.Data.SqlDbType.Int);
                    idOut.Direction = ParameterDirection.Output;

                    collection.Add(idOut);
                },
                returnParameters: delegate (SqlParameterCollection returnCollection)
                {
                    object objectId = returnCollection["@id"].Value;

                    int.TryParse(objectId.ToString(), out id);
                });
            return id;
        }

        public void Update(ProductUpdateRequest model)
        {
            _data.ExecuteNonQuery("dbo.Products_Update",
                inputParamMapper: delegate (SqlParameterCollection collection)
                {
                    AddCommonParams(model, collection);

                    collection.AddWithValue("@id", model.Id);
                },
                returnParameters: null);
        }

        public void Delete(int id)
        {
            _data.ExecuteNonQuery("dbo.Products_Delete",
                inputParamMapper: delegate (SqlParameterCollection collection)
                {
                    collection.AddWithValue("@id", id);
                },
                returnParameters: null);
        }

        public Product GetById(int id)
        {
            Product product = null;

            _data.ExecuteCmd("dbo.Products_SelectById", 
                delegate (SqlParameterCollection paramCollection)
                {
                    paramCollection.AddWithValue("@id", id);
                },
                delegate (IDataReader reader, short set)
                {
                
                    product = MapSingleProduct(reader);

                });
            return product;
        }

        public List<Product> GetByCategoryId(int categoryid)
        {
            List<Product> productList = null;

            _data.ExecuteCmd("dbo.Products_SelectByCategoryId", 
                inputParamMapper: delegate (SqlParameterCollection collection)
                {
                    collection.AddWithValue("@category_id", categoryid);
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

            singleProduct.id = reader.GetSafeInt32(startingIndex++);
            singleProduct.name = reader.GetSafeString(startingIndex++);
            singleProduct.price = reader.GetSafeDecimal(startingIndex++);
            singleProduct.description = reader.GetSafeString(startingIndex++);
            singleProduct.category_id = reader.GetSafeInt32(startingIndex++);

            return singleProduct;
        }

        private static void AddCommonParams(ProductAddRequest model, SqlParameterCollection collection)
        {
            collection.AddWithValue("@name", model.name);
            collection.AddWithValue("@price", model.price);
            collection.AddWithValue("@description", model.description);
            collection.AddWithValue("@category_id", model.category_id);
        }
    }
}

