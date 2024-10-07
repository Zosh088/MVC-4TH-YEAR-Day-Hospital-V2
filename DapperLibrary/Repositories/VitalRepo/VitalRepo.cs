using Dapper;
using Surgeon__Day_Hospital_.Models;
using System.Data;

namespace Surgeon__Day_Hospital_.DapperLibrary.Repositories.VitalRepo
{
    public class VitalRepo : IVitalRepo
    {
        private readonly IDbConnection _con;

        public VitalRepo(IDbConnection con)
        {
            _con = con;
        }

        public Vital_Records GetVitalById(string procedureName, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure)
        {
            return _con.QuerySingle<Vital_Records>(procedureName, parameters, commandType: commandType);
        }

        public IEnumerable<Vital_Records> GetVitals(string procedureName, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure)
        {
            return _con.Query<Vital_Records>(procedureName, parameters, commandType: commandType);  
        }

        public void IUDVital(string procedureName, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure)
        {
            _con.Execute(procedureName, parameters, commandType: commandType);
        }
    }
}
