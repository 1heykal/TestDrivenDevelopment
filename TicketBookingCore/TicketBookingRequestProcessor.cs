
namespace TicketBookingCore
{
    public class TicketBookingRequestProcessor
    {
        private readonly ITicketBookingRepository _ticketBookingRepository;
        public TicketBookingRequestProcessor(ITicketBookingRepository bookingRepository)
        {
            _ticketBookingRepository = bookingRepository;
        }

        public TicketBookingResponse Book(TicketBookingRequest request)
        {
            ArgumentNullException.ThrowIfNull(request, nameof(request));

            _ticketBookingRepository.Save(Create<TicketBooking>(request));

            return Create<TicketBookingResponse>(request);

        }

        private static T Create<T>(TicketBookingRequest request) where T : TicketBookingBase, new()
        {
            return new T
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email
            };
        }
    }
}