namespace TicketBookingCore.Tests
{
    public class TicketBookingRequestProcessorTests
    {
        private readonly TicketBookingRequestProcessor processor;

        public TicketBookingRequestProcessorTests()
        {
            processor = new TicketBookingRequestProcessor();
        }

        [Fact]
        public void ShouldReturnTicketBookingResultWithRequestValues()
        {
            var request = new TicketBookingRequest
            {
                FirstName = "Osama",
                LastName = "Heykal",
                Email = "oneheykal@gmail.com"
            };

            TicketBookingResponse response = processor.Book(request);

            Assert.NotNull(response);
            Assert.Equal(request.FirstName, response.FirstName);
            Assert.Equal(request.LastName, response.LastName);
            Assert.Equal(request.Email, response.Email);

        }

        [Fact]
        public void ShouldThrowExceptionIfRequestIsNull()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => processor.Book(null));

            Assert.Equal("request", exception.ParamName);
        }

        [Fact]
        public void ShouldSaveToDatabase()
        {
            var request = new TicketBookingRequest
            {
                FirstName = "Ahmed",
                LastName = "Salamn",
                Email = "AhmedSalman2001@gmail.com"
            };

            var response = processor.Book(request);
        }
    }
}