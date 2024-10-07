using Dapper;
using Surgeon__Day_Hospital_.Models;
using System.Data;

namespace Surgeon__Day_Hospital_.DapperLibrary.Repositories.ScriptRepo
{
    public class ScriptRecordRepo : IScriptRecordRepo
    {
        private readonly IDbConnection _con;

        public ScriptRecordRepo(IDbConnection con)
        {
            _con = con;
        }
        public Script_Records GetScriptRecordById(string procedureName, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure)
        {
            return _con.QueryFirstOrDefault<Script_Records>(procedureName, parameters, commandType: commandType);
        }

        public IEnumerable<Script_Records> GetScriptRecords(string procedureName, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure)
        {
            return _con.Query<Script_Records>(procedureName, parameters, commandType: commandType);
        }

        public void IUDScriptRecord(string procedureName, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure)
        {
            _con.Execute(procedureName, parameters, commandType: commandType);
        }
    }
}
