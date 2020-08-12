using PaymentGateway;
using Xunit;

namespace UnitTests
{
    public class UtilTests
    {
        // Quick little check. The idea is the validator will ensure no card numbers supplied contain letters
        // or under the incorrect length. 
        [Fact]
        public void GivenACardNumberToHash_ShouldHashIt()
        {
            // arrange
            var cardNumber = "testHashing";
            
            // act
            var hashedCardNumber = Utils.HashCardNumber(cardNumber);

            // assert
            Assert.Equal("*******hing", hashedCardNumber);

        }
    }
}