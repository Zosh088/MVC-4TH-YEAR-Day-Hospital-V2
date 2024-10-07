using Dapper;
using Surgeon__Day_Hospital_.DapperLibrary.ViewModels;
using Surgeon__Day_Hospital_.Models;
using System.Data;

namespace Surgeon__Day_Hospital_.DapperLibrary.Repositories.PatientRepo
{
    public interface IPatientRepo
    {
        IEnumerable<ViewPatient> GetPatients(string procedureName, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure);
        ViewPatient GetPatientById(string procedureName, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure);
        void IUDPatient(string procedureName, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure);
    }
}
