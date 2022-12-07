using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ProductApp.Data.Providers;
using ProductApp.Models.Requests.Category;
using ProductApp.Models.Domain;
using ProductApp.Data;
using ProductApp.Services.Interfaces;

namespace ProductApp.Services
{
    public class CategoryService : ICategoryService
    {
        IDataProvider _data = null;

        public CategoryService(IDataProvider data)
        {
            _data = data;
        }

        public int Add(CategoryAddRequest model)
        {
            int id = 0;

            _data.ExecuteNonQuery("dbo.Cars_Categories_Insert",
               inputParamMapper: delegate (SqlParameterCollection collection)
               {
                   collection.AddWithValue("@Name", model.Name);

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

        public void Update(CategoryUpdateRequest model)
        {
            _data.ExecuteNonQuery("dbo.Cars_Categories_Update",
                inputParamMapper: delegate (SqlParameterCollection collection)
                {
                    collection.AddWithValue("@Id", model.Id);
                    collection.AddWithValue("@Name", model.Name);
                },
                returnParameters: null);
        }

        public void Delete(int id)
        {
            _data.ExecuteNonQuery("dbo.Cars_Categories_Delete",
                inputParamMapper: delegate (SqlParameterCollection collection)
                {
                    collection.AddWithValue("@Id", id);
                },
                returnParameters: null);
        }

        public Category GetById(int id)
        {
            Category category = null;

            _data.ExecuteCmd("dbo.Cars_Categories_SelectById", 
                delegate (SqlParameterCollection paramCollection)
                {
                    paramCollection.AddWithValue("@Id", id);
                },
                delegate (IDataReader reader, short set)
                {
                    category = MapSingleCategory(reader);

                });
            return category;
        }

        public Category GetByName(string name)
        {
            Category category = null;

            _data.ExecuteCmd("dbo.Cars_Categories_SelectByName",
                delegate (SqlParameterCollection paramCollection)
                {
                    paramCollection.AddWithValue("@Name", name);
                },
                delegate (IDataReader reader, short set)
                {
                    category = MapSingleCategory(reader);

                });
            return category;
        }

        public List<Category> GetAll()
        {
            List<Category> categoryList = null;

            _data.ExecuteCmd("dbo.Cars_Categories_SelectAll", 
                inputParamMapper: null,
                singleRecordMapper: delegate (IDataReader reader, short set)
                {
                    Category singleCategory = MapSingleCategory(reader);

                    if (categoryList == null)
                    {
                        categoryList = new List<Category>();
                    }

                    categoryList.Add(singleCategory);
                });
            return categoryList;
        }

        private static Category MapSingleCategory(IDataReader reader)
        {
            Category singleCategory = new Category();

            int startingIndex = 0;

            singleCategory.Id = reader.GetSafeInt32(startingIndex++);
            singleCategory.Name = reader.GetSafeString(startingIndex++);

            string productsAsString = reader.GetString(startingIndex++);
            if (!string.IsNullOrEmpty(productsAsString))
            {
                singleCategory.Products = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Product>>(productsAsString);
            }

            return singleCategory;
        }

    }
}
