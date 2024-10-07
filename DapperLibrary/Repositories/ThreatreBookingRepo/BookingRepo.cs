using Dapper;
using Surgeon__Day_Hospital_.DapperLibrary.ViewModels;
using Surgeon__Day_Hospital_.Models;
using System.Data;

namespace Surgeon__Day_Hospital_.DapperLibrary.Repositories.ThreatreBookingRepo
{
    public class BookingRepo : IBookingRepo
    {
        private readonly IDbConnection _con;

        public BookingRepo(IDbConnection con)
        {
            _con = con;
        }

        public ViewBooking GetBookingById(string procedureName, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure)
        {
            return _con.QueryFirstOrDefault<ViewBooking>(procedureName, parameters, commandType: commandType);
        }

        public IEnumerable<ViewBooking> GetBookings(string procedureName, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure)
        {
            return _con.Query<ViewBooking>(procedureName, parameters, commandType: commandType);
        }

        public void IUDBooking(string procedureName, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure)
        {
            _con.Execute(procedureName, parameters, commandType: commandType);
        }
    }
}
