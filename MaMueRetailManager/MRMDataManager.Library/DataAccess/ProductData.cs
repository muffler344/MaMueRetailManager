using MRMDataManager.Library.Internal.DataAccess;
using MRMDataManager.Library.Models;
using System.Collections.Generic;
using System.Linq;

namespace MRMDataManager.Library.DataAccess
{
    public class ProductData : IProductData
    {
        private readonly ISqlDataAccess _sqlDataAccess;

        public ProductData(ISqlDataAccess sqlDataAccess)
        {
            _sqlDataAccess = sqlDataAccess;
        }

        public List<ProductModel> GetProducts()
        {
            var output = _sqlDataAccess.LoadData<ProductModel, dynamic>("dbo.spProduct_GetAll", new { }, "MRMData");

            return output;
        }

        public ProductModel GetProductById(int productId)
        {
            var output = _sqlDataAccess
                .LoadData<ProductModel, dynamic>("dbo.spProduct_GetById", new { Id = productId }, "MRMData")
                .FirstOrDefault();

            return output;
        }
    }
}
