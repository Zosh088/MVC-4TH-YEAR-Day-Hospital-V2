using Dapper;
using Surgeon__Day_Hospital_.Models;
using System.Data;

namespace Surgeon__Day_Hospital_.DapperLibrary.Repositories.VitalRepo
{
    public interface IVitalRepo
    {
        IEnumerable<Vital_Records> GetVitals(string procedureName, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure);
        Vital_Records GetVitalById(string procedureName, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure);
        void IUDVital(string procedureName, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure);
    }
}
