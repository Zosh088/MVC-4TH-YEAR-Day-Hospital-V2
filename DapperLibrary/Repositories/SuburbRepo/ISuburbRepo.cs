using Dapper;
using Surgeon__Day_Hospital_.Models;
using System.Data;

namespace Surgeon__Day_Hospital_.DapperLibrary.Repositories.SuburbRepo
{
    public interface ISuburbRepo
    {
        IEnumerable<Suburb_Records> GetSuburbs(string procedureName, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure);
        Suburb_Records GetSuburbById(string procedureName, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure);
        void IUDSuburb(string procedureName, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure);
    }
}
