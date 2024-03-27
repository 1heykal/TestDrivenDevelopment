using Moq;

namespace TicketBookingCore.Tests
{
    public class TicketBookingRequestProcessorTests
    {
        private readonly TicketBookingRequest _request;
        private readonly TicketBookingRequestProcessor _processor;
        private readonly Mock<ITicketBookingRepository> _ticketBookingRepositoryMock;

        public TicketBookingRequestProcessorTests()
        {
            _request = new TicketBookingRequest
            {
                FirstName = "Osama",
                LastName = "Heykal",
                Email = "oneheykal@gmail.com"
            };
            _ticketBookingRepositoryMock = new Mock<ITicketBookingRepository>();
            _processor = new TicketBookingRequestProcessor(_ticketBookingRepositoryMock.Object);

        }

        [Fact]
        public void ShouldReturnTicketBookingResultWithRequestValues()
        {

            TicketBookingResponse response = _processor.Book(_request);

            Assert.NotNull(response);
            Assert.Equal(_request.FirstName, response.FirstName);
            Assert.Equal(_request.LastName, response.LastName);
            Assert.Equal(_request.Email, response.Email);

        }

        [Fact]
        public void ShouldThrowExceptionIfRequestIsNull()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => _processor.Book(null));

            Assert.Equal("request", exception.ParamName);
        }

        [Fact]
        public void ShouldSaveToDatabase()
        {
            TicketBooking savedTicketBooking = null;

            _ticketBookingRepositoryMock.Setup(x => x.Save(It.IsAny<TicketBooking>()))
                .Callback<TicketBooking>((ticketBooking) =>
                {
                    savedTicketBooking = ticketBooking;
                });

            var response = _processor.Book(_request);

            _ticketBookingRepositoryMock.Verify(x => x.Save(It.IsAny<TicketBooking>()), Times.Once);

            Assert.NotNull(savedTicketBooking);
            Assert.Equal(_request.FirstName, savedTicketBooking.FirstName);
            Assert.Equal(_request.LastName, savedTicketBooking.LastName);
            Assert.Equal(_request.Email, savedTicketBooking.Email);

        }
    }
}