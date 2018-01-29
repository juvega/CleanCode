
using System;
using System.Collections.Generic;

namespace CleanCode.LongParameterList
{
    public class LongParameterList
    {
        public class DateRange
        {
            public DateTime dateFrom { get; set; }
            public DateTime dateTo { get; set; }
        }

        public class ReservationQuery
        {
            public DateRange DateRange { get; set; }
            public User User { get; set; }
            public int LocationId { get; set; }
            public LocationType LocationType { get; set; }
            public int? CustomerId { get; set; }
        }

        public IEnumerable<Reservation> GetReservations(ReservationQuery reservationQuery)
        {
            if (reservationQuery.DateRange.dateFrom >= DateTime.Now)
                throw new ArgumentNullException("dateFrom");
            if (reservationQuery.DateRange.dateTo <= DateTime.Now)
                throw new ArgumentNullException("dateTo");

            throw new NotImplementedException();
        }

        public IEnumerable<Reservation> GetUpcomingReservations(ReservationQuery reservationQuery)
        {
            if (reservationQuery.DateRange.dateFrom >= DateTime.Now)
                throw new ArgumentNullException("dateFrom");
            if (reservationQuery.DateRange.dateTo <= DateTime.Now)
                throw new ArgumentNullException("dateTo");

            throw new NotImplementedException();
        }

        private static Tuple<DateTime, DateTime> GetReservationDateRange(DateRange dateRange, ReservationDefinition sd)
        {
            if (dateRange.dateFrom >= DateTime.Now)
                throw new ArgumentNullException("dateFrom");
            if (dateRange.dateTo <= DateTime.Now)
                throw new ArgumentNullException("dateTo");

            throw new NotImplementedException();
        }

        public void CreateReservation(DateRange dateRange, int locationId)
        {
            if (dateRange.dateFrom >= DateTime.Now)
                throw new ArgumentNullException("dateFrom");
            if (dateRange.dateTo <= DateTime.Now)
                throw new ArgumentNullException("dateTo");

            throw new NotImplementedException();
        }
    }

    internal class ReservationDefinition
    {
    }

    public class LocationType
    {
    }

    public class User
    {
        public object Id { get; set; }
    }

    public class Reservation
    {
    }
}
