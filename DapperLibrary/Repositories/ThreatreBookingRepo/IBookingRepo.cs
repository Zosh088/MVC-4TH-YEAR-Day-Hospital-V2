using Dapper;
using Surgeon__Day_Hospital_.DapperLibrary.ViewModels;
using Surgeon__Day_Hospital_.Models;
using System.Data;

namespace Surgeon__Day_Hospital_.DapperLibrary.Repositories.ThreatreBookingRepo
{
    public interface IBookingRepo
    {
        IEnumerable<ViewBooking> GetBookings(string procedureName, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure);
        ViewBooking GetBookingById(string procedureName, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure);
        void IUDBooking(string procedureName, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure);
    }
}
