using Dapper;
using Surgeon__Day_Hospital_.Models;
using System.Data;

namespace Surgeon__Day_Hospital_.DapperLibrary.Repositories.AdmissionRepo
{
    public class AdmissionRepo : IAdmissionRepo
    {
        private readonly IDbConnection _con;

        public AdmissionRepo(IDbConnection con)
        {
            _con = con;
        }
        public Admission_Records GetAdmissionById(string procedureName, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure)
        {
            return _con.QueryFirstOrDefault<Admission_Records>(procedureName, parameters, commandType: commandType);
        }

        public IEnumerable<Admission_Records> GetAdmissions(string procedureName, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure)
        {
            return _con.Query<Admission_Records>(procedureName, parameters, commandType: commandType);
        }

        public void IUDAdmission(string procedureName, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure)
        {
            _con.Execute(procedureName, parameters, commandType: commandType);
        }
    }
}
