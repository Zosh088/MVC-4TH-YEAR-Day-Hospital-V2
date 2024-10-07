using Dapper;
using Surgeon__Day_Hospital_.Models;
using System.Data;

namespace Surgeon__Day_Hospital_.DapperLibrary.Repositories.AdmissionRepo
{
    public interface IAdmissionRepo
    {
        IEnumerable<Admission_Records> GetAdmissions(string procedureName, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure);
        Admission_Records GetAdmissionById(string procedureName, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure);
        void IUDAdmission(string procedureName, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure);
    }
}
