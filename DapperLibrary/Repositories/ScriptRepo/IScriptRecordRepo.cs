using Dapper;
using Surgeon__Day_Hospital_.Models;
using System.Data;

namespace Surgeon__Day_Hospital_.DapperLibrary.Repositories.ScriptRepo
{
    public interface IScriptRecordRepo
    {
        IEnumerable<Script_Records> GetScriptRecords(string procedureName, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure);
        Script_Records GetScriptRecordById(string procedureName, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure);
        void IUDScriptRecord(string procedureName, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure);
    }
}
