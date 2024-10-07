using Dapper;
using System.Data;
using Surgeon__Day_Hospital_.Data;
using Surgeon__Day_Hospital_.DapperLibrary.ViewModels;

namespace Surgeon__Day_Hospital_.DapperLibrary.Repositories.AddressRepo
{
    public class AddressRepo : IAddressRepo
    {
        //private readonly ApplicationDbContext _con;
        private readonly IDbConnection _con;

        public AddressRepo(IDbConnection con)
        {
            _con = con;
        }

        public IEnumerable<ViewAddress> GetAddress(string procedureName, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure)
        {
            return _con.Query<ViewAddress>(procedureName, parameters, commandType: commandType);
        }

        public ViewAddress GetAddressById(string procedureName, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure)
        {
            return _con.QueryFirstOrDefault<ViewAddress>(procedureName, parameters, commandType: commandType);
        }

        public void IUDAddress(string procedureName, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure)
        {
            _con.Execute(procedureName, parameters, commandType: commandType);
        }
    }
}
