using Xunit;

namespace Sparky
{
    public class GradingCalculatorXUnitTests
    {
        private GradingCalculator grading;
       
        public GradingCalculatorXUnitTests()
        {
            grading = new GradingCalculator();
        }

        [Fact]
        public void GetGrade_InputAttendance90Score95_ReturnAGrade()
        {
            grading.Score = 95;
            grading.AttendancePercentage = 90;
            string result = grading.GetGrade();
            Assert.Equal("A", result);
        } 

        [Fact]
        public void GetGrade_InputAttendance90Score85_ReturnBGrade()
        {
            grading.Score = 85;
            grading.AttendancePercentage = 90;
            string result = grading.GetGrade();
            Assert.Equal("B", result);
        } 

        [Fact]
        public void GetGrade_InputAttendance90Score65_ReturnCGrade()
        {
            grading.Score = 65;
            grading.AttendancePercentage = 90;
            string result = grading.GetGrade();
            Assert.Equal("C", result);
        } 

        [Fact]
        public void GetGrade_InputAttendance65Score95_ReturnBGrade()
        {
            grading.Score = 95;
            grading.AttendancePercentage = 65;
            string result = grading.GetGrade();
            Assert.Equal("B", result);
        } 

        [Theory]
        [InlineData(95, 55)]
        [InlineData(65, 55)]
        [InlineData(50, 90)]
        public void GradeCalc_FailsureScenarios_GetFGrade(int score, int attendance)
        {
            grading.Score = score;
            grading.AttendancePercentage = attendance;
            string result = grading.GetGrade();
            Assert.Equal("F", result);
        }

        [Theory]
        [InlineData(95, 90, "A")]
        [InlineData(85, 90, "B")]
        [InlineData(65, 90, "C")]
        [InlineData(95, 65, "B")]
        [InlineData(95, 55, "F")]
        [InlineData(65, 55, "F")]
        [InlineData(50, 90, "F")]
        public void GetGrade_AllLogicalScenarios_ReturnExpectedGrade(int score, int attendance, string expectedResult)//combine all tests in 1 unit test
        {
            grading.Score=score;
            grading.AttendancePercentage=attendance;
            var res = grading.GetGrade();
            Assert.Equal(expectedResult, res);
        }
    }
}