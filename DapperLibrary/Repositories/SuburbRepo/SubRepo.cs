using Dapper;
using Surgeon__Day_Hospital_.Models;
using System.Data;

namespace Surgeon__Day_Hospital_.DapperLibrary.Repositories.SuburbRepo
{
    public class SubRepo : ISuburbRepo
    {
        private readonly IDbConnection _con;

        public SubRepo(IDbConnection con)
        {
            _con = con;
        }

        public Suburb_Records GetSuburbById(string procedureName, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure)
        {
            return _con.QueryFirstOrDefault<Suburb_Records>(procedureName, parameters, commandType: commandType);
        }

        public IEnumerable<Suburb_Records> GetSuburbs(string procedureName, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure)
        {
            return _con.Query<Suburb_Records>(procedureName, parameters, commandType: commandType);
        }

        public void IUDSuburb(string procedureName, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure)
        {
            _con.Execute(procedureName, parameters, commandType: commandType);
        }
    }
}
