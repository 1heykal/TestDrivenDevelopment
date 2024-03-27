using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBookingCore
{
    public interface ITicketBookingRepository
    {
        void Save(TicketBooking booking);
    }
}
