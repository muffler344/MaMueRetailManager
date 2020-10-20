using MRMDataManager.Library.Internal.DataAccess;
using MRMDataManager.Library.Models;
using System.Collections.Generic;

namespace MRMDataManager.Library.DataAccess
{
    public class UserData : IUserData
    {
        private readonly ISqlDataAccess _sqlDataAccess;
        public UserData(ISqlDataAccess sqlDataAccess)
        {
            _sqlDataAccess = sqlDataAccess;
        }

        public List<UserModel> GetUserById(string Id)
        {
            var output = _sqlDataAccess.LoadData<UserModel, dynamic>("dbo.spUserLookup", new { Id }, "MRMData");

            return output;
        }
    }
}
