using System.Collections.Generic;
using MRMDataManager.Library.Models;
using MRMDataManager.Library.Internal.DataAccess;
using Microsoft.Extensions.Configuration;

namespace MRMDataManager.Library.DataAccess
{
    public class InventoryData : IInventoryData
    {
        private readonly ISqlDataAccess _sqlDataAccess;
        public InventoryData(ISqlDataAccess sqlDataAccess) 
        {
            _sqlDataAccess = sqlDataAccess;
        }

        public List<InventoryModel> GetInventory()
        {
            var output = _sqlDataAccess.LoadData<InventoryModel, dynamic>("dbo.spInventory_GetAll", new { }, "MRMData");
            return output;
        }

        public void SaveInventoryRecord(InventoryModel item)
        {
            _sqlDataAccess.SaveData("dbo.spInventory_Insert", item, "MRMData");
        }
    }
}
