using Dapper;
using Surgeon__Day_Hospital_.DapperLibrary.ViewModels;
using Surgeon__Day_Hospital_.Models;
using System.Data;

namespace Surgeon__Day_Hospital_.DapperLibrary.Repositories.PatientRepo
{
    public class PatientRepo : IPatientRepo
    {
        private readonly IDbConnection _con;

        public PatientRepo(IDbConnection con)
        {
            _con = con;
        }

        public ViewPatient GetPatientById(string procedureName, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure)
        {
            return _con.QueryFirstOrDefault<ViewPatient>(procedureName, parameters, commandType: commandType);
        }

        public IEnumerable<ViewPatient> GetPatients(string procedureName, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure)
        {
            return _con.Query<ViewPatient>(procedureName, parameters, commandType: commandType);
        }

        public void IUDPatient(string procedureName, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure)
        {
            _con.Execute(procedureName, parameters, commandType: commandType);
        }
    }
}
