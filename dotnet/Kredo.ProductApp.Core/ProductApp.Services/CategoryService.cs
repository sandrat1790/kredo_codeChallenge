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

            _data.ExecuteNonQuery("dbo.Categories_Insert",
               inputParamMapper: delegate (SqlParameterCollection collection)
               {
                   collection.AddWithValue("@name", model.name);

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

        public void Update(CategoryUpdateRequest model)
        {
            _data.ExecuteNonQuery("dbo.Categories_Update",
                inputParamMapper: delegate (SqlParameterCollection collection)
                {
                    collection.AddWithValue("@id", model.Id);
                    collection.AddWithValue("@name", model.name);
                },
                returnParameters: null);
        }

        public void Delete(int id)
        {
            _data.ExecuteNonQuery("dbo.Categories_Delete",
                inputParamMapper: delegate (SqlParameterCollection collection)
                {
                    collection.AddWithValue("@id", id);
                },
                returnParameters: null);
        }

        public Category GetById(int id)
        {
            Category category = null;

            _data.ExecuteCmd("dbo.Categories_SelectById", 
                delegate (SqlParameterCollection paramCollection)
                {
                    paramCollection.AddWithValue("@id", id);
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

            _data.ExecuteCmd("dbo.Categories_SelectAll", 
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

            singleCategory.id = reader.GetSafeInt32(startingIndex++);
            singleCategory.name = reader.GetSafeString(startingIndex++);

            return singleCategory;
        }

    }
}
