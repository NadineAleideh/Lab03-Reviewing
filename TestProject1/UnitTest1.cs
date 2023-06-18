using Lab03_review;
namespace TestProject1
{
    public class UnitTest1
    {
        //Challenge 1
        [Theory]
        [InlineData("5 2 3", 30)] //Input a string of numbers and it returns a product of all numbers
        [InlineData("5 6 7 8", 210)] //Input more than 3 numbers
        [InlineData("2 7", 0)] //Input of less than 3 numbers
        [InlineData("-2 -3 -4", -24)] //Can it handle negative numbers
        [InlineData("1 2 n", 2)]   //Can it handle not numbers elements
        public void ProbuctOf3Nums_Test(string input, int expected)
        {
            int result = Program.ProbuctOf3Nums(input);

            Assert.Equal(expected, result);
        }

        //Challenge 2
        [Theory]
        [InlineData(new[] { 4, 8, 15, 16 }, 10.75)]//Input different ranges of numbers and confirm averages
        [InlineData(new[] { 10, 20, 30, 40, 50 }, 30)]
        [InlineData(new[] { 0, 0, 0 }, 0)] //All numbers are 0s
        public void AvgOfRandomSetOfNums_Test(int[] inputNumbers, double expectedAverage)
        {
            double average = Program.AvgOfRandomSetOfNums(inputNumbers);

            Assert.Equal(expectedAverage, average);
        }

        //Challenge 3 there is no test

        //Challenge 4
        [Theory]
        [InlineData(new[] { 1, 1, 2, 2, 3, 3, 3, 1, 1, 5, 5, 6, 7, 8, 2, 1, 1 }, 1)]
        [InlineData(new[] { 8, 8, 8, 8, 8, 8 }, 8)]
        [InlineData(new[] { 3, 4, 5, 6, 7, 8 }, 3)]
        [InlineData(new[] { 12, 1, 5, 5, 10, 9, 9, 1 }, 1)]
        public void MostAppearsNumberInArray_Test(int[] numbers, int expectedMostAppearsNumber)
        {
            int MostAppearsNumber = Program.MostAppearsNumberInArray(numbers);

            Assert.Equal(expectedMostAppearsNumber, MostAppearsNumber);
        }

        //Challenge 5

        [Theory]
        [InlineData(new[] { 5, 25, 99, 123, 78, 96, 555, 108, 4 }, 555)]
        [InlineData(new[] { 3, 1, -2, 2, 3, 5, -3, -7 }, 5)] //Negative numbers
        [InlineData(new[] { 8, 8, 8, 8, 8, 8 }, 8)] //All values are the same
        public void MaxValueInArrayValidAndNegatives_Test(int[] numbers, int expectedMaxValue)
        {

            int maxValue = Program.MaxValueInArray(numbers);

            Assert.Equal(expectedMaxValue, maxValue);
        }

        [Fact]
        public void MaxValueInArray_ThrowsException_WhenArrayIsEmpty()
        {
            int[] numbers = new int[0];

            Assert.Throws<Exception>(() => Program.MaxValueInArray(numbers));
        }

        //Challenge 9
        [Theory]
        [InlineData("This is a sentence about important things", new string[] { "This: 4", "is: 2", "a: 1", "sentence: 8", "about: 5", "important: 9", "things: 6" })]
        [InlineData("Hello World", new string[] { "Hello: 5", "World: 5" })]
        [InlineData("Nadine is 23 years old !", new string[] { "Nadine: 6", "is: 2", "23: 2", "years: 5", "old: 3", "!: 1" })]
        public void GetWordLengthsValid_Test(string sentence, string[] expectedOutput)
        {
            // Act
            string[] output = Program.SentenceWordsLengths(sentence);

            // Assert
            Assert.Equal(expectedOutput, output);
        }

        [Fact]
        public void GetWordLengths_ReturnsArray()
        {
            string sentence = "Hello World";
            string[] output = Program.SentenceWordsLengths(sentence);

            Assert.NotNull(output);
            Assert.NotEmpty(output);
        }
    }
}