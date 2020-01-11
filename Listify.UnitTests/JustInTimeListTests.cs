using Listify.Models;
using Xunit;


namespace Listify.UnitTests
{
    public class JustInTimeListTests
    {
        [Theory]
        [InlineData(100, 200, 50, 150)]
        [InlineData(110, 120, 5, 115)]
        [InlineData(1, 1, 0, 1)]
        [InlineData(100,200,100,200)]
        public void PostiveIndexValuesWithinRangeReturnsCorrect(
            int start,
            int end,
            int index,
            int expected)
        {
            //Arrange
            var list = new JustInTimeList(start, end);
            //Act
            var actual = list[index];
            //Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(100, 200, -50, 151)]
        [InlineData(110, 120, -5, 116)]
        [InlineData(1, 1, -1, 1)]
        [InlineData(100, 200, -101, 100)]
        public void NegativeIndexValuesWithinRangeReturnsCorrect(
            int start,
            int end,
            int index,
            int expected)
        {
            //Arrange
            var list = new JustInTimeList(start, end);
            //Act
            var actual = list[index];
            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
