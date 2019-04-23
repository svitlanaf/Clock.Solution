using Microsoft.VisualStudio.TestTools.UnitTesting;
using Clock;

namespace Clock.Tests
{
  [TestClass]
  public class ClockTest
  {
    [TestMethod]
    public void CheckTime_UserInputsTime_ReturnTrue()
    {
      Clock testClock = new Clock("6", "00");
      Assert.AreEqual(true, testClock.CheckTime());
    }

    [TestMethod]
    public void CheckTime_UserInputsNonTime_ReturnFalse()
    {
      Clock testClock = new Clock("hello", "there");
      Assert.AreEqual(false, testClock.CheckTime());
    }

    [TestMethod]
    public void ClockConstructor_UserInputsHours12_CalculateMinutesHoursPosition()
    {
      Clock testClock = new Clock("12", "30");
      testClock.SetClockPositions();
      Assert.AreEqual(30, testClock.GetMinutesPosition());
      Assert.AreEqual(2.5, testClock.GetHoursPosition());
    }

    [TestMethod]
    public void ClockConstructor_UserInputsHoursOver12_CalculateMinutesHoursPosition()
    {
      Clock testClock = new Clock("23", "00");
      testClock.SetClockPositions();
      Assert.AreEqual(0, testClock.GetMinutesPosition());
      Assert.AreEqual(55, testClock.GetHoursPosition());
    }

    [TestMethod]
    public void ClockConstructor_UserInputsHoursUnder12_CalculateMinutesHoursPosition()
    {
      Clock testClock = new Clock("3", "15");
      testClock.SetClockPositions();
      Assert.AreEqual(15, testClock.GetMinutesPosition());
      Assert.AreEqual(16.25, testClock.GetHoursPosition());
    }

    [TestMethod]
    public void CalculateAngle_UserInputsTimeUnder12_CalculateDegrees()
    {
      Clock testClock = new Clock("6", "30");
      testClock.SetClockPositions();
      Assert.AreEqual(15, testClock.CalculateAngle());
    }

    [TestMethod]
    public void CalculateAngle_UserInputsTimeOver12_CalculateDegrees()
    {
      Clock testClock = new Clock("23", "00");
      testClock.SetClockPositions();
      Assert.AreEqual(30, testClock.CalculateAngle());
    }

    [TestMethod]
    public void CalculateAngle_UserInputsTime12_CalculateDegrees()
    {
      Clock testClock = new Clock("12", "00");
      testClock.SetClockPositions();
      Assert.AreEqual(0, testClock.CalculateAngle());
    }
  }
}
