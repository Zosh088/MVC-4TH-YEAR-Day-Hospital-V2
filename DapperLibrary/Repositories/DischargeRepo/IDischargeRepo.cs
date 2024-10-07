using Dapper;
using Surgeon__Day_Hospital_.Models;
using System.Data;

namespace Surgeon__Day_Hospital_.DapperLibrary.Repositories.DischargeRepo
{
    public interface IDischargeRepo
    {
        IEnumerable<Discharge_Records> GetDischarges(string procedureName, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure);
        Discharge_Records GetDischargeById(string procedureName, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure);
        void IUDDischarge(string procedureName, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure);
    }
}
