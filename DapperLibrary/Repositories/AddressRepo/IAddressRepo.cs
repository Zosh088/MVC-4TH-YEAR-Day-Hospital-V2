using Dapper;
using System.Data;
using Surgeon__Day_Hospital_.DapperLibrary.ViewModels;

namespace Surgeon__Day_Hospital_.DapperLibrary.Repositories.AddressRepo
{
    public interface IAddressRepo
    {
        IEnumerable<ViewAddress> GetAddress(string procedureName, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure);
        ViewAddress GetAddressById(string procedureName, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure);
        void IUDAddress(string procedureName, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure);
    }
}
