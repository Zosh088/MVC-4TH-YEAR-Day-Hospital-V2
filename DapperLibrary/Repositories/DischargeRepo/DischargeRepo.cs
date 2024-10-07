using Dapper;
using Surgeon__Day_Hospital_.Models;
using System.Data;

namespace Surgeon__Day_Hospital_.DapperLibrary.Repositories.DischargeRepo
{
    public class DischargeRepo : IDischargeRepo
    {
        private readonly IDbConnection _con;

        public DischargeRepo(IDbConnection con)
        {
            _con = con;
        }

        public Discharge_Records GetDischargeById(string procedureName, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure)
        {
            return _con.QueryFirstOrDefault<Discharge_Records>(procedureName, parameters, commandType: commandType);
        }

        public IEnumerable<Discharge_Records> GetDischarges(string procedureName, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure)
        {
            return _con.Query<Discharge_Records>(procedureName, parameters, commandType: commandType);
        }

        public void IUDDischarge(string procedureName, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure)
        {
            _con.Execute(procedureName, parameters, commandType: commandType);
        }
    }
}
