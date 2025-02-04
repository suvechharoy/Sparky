using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace Sparky
{
    [TestFixture]
    public class GradingCalculatorNUnitTests
    {
        private GradingCalculator grading;
        [SetUp]
        public void Setup()
        {
            grading = new GradingCalculator();
        }
        [Test]
        public void GetGrade_InputAttendance90Score95_ReturnAGrade()
        {
            grading.Score = 95;
            grading.AttendancePercentage = 90;
            string result = grading.GetGrade();
            Assert.AreEqual(result,"A");
        } 
        [Test]
        public void GetGrade_InputAttendance90Score85_ReturnBGrade()
        {
            grading.Score = 85;
            grading.AttendancePercentage = 90;
            string result = grading.GetGrade();
            Assert.That(result, Is.EqualTo("B"));
        } 
        [Test]
        public void GetGrade_InputAttendance90Score65_ReturnCGrade()
        {
            grading.Score = 65;
            grading.AttendancePercentage = 90;
            string result = grading.GetGrade();
            Assert.AreEqual(result,"C");
        } 
        [Test]
        public void GetGrade_InputAttendance65Score95_ReturnBGrade()
        {
            grading.Score = 95;
            grading.AttendancePercentage = 65;
            string result = grading.GetGrade();
            Assert.That(result, Is.EqualTo("B"));
        } 
        [Test]
        [TestCase(95, 55)]
        [TestCase(65, 55)]
        [TestCase(50, 90)]
        public void GradeCalc_FailsureScenarios_GetFGrade(int score, int attendance)
        {
            grading.Score = score;
            grading.AttendancePercentage = attendance;
            string result = grading.GetGrade();
            Assert.That(result, Is.EqualTo("F"));
        }
        [Test]
        [TestCase(95, 90, ExpectedResult = "A")]
        [TestCase(85, 90, ExpectedResult = "B")]
        [TestCase(65, 90, ExpectedResult = "C")]
        [TestCase(95, 65, ExpectedResult = "B")]
        [TestCase(95, 55, ExpectedResult = "F")]
        [TestCase(65, 55, ExpectedResult = "F")]
        [TestCase(50, 90, ExpectedResult = "F")]
        public string GetGrade_AllLogicalScenarios_ReturnExpectedGrade(int score, int attendance)//combine all tests in 1 unit test
        {
            grading.Score=score;
            grading.AttendancePercentage=attendance;
            return grading.GetGrade();
        }
    }
}