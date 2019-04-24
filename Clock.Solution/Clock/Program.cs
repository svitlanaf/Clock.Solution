using System;

namespace Clock
{
  public class Program
  {
    public static bool CheckHourInput(string hour)
    {
      int checkHour = int.Parse(hour);
      return (checkHour >= 0 && checkHour < 24);
    }
    public static bool CheckMinuteInput(string minute)
    {
      int checkMinute = int.Parse(minute);
      return (checkMinute >= 0 && checkMinute < 60);
    }

    public static string PromptHour()
    {
      Console.WriteLine("Enter the hour");
      string hour = Console.ReadLine();
      if(CheckHourInput(hour))
      {
        return hour;
      }
      else
      {
        Console.WriteLine("Hey, that's not a valid hour value.");
        return PromptHour();
      }
    }

    public static string PromptMinutes()
    {
      Console.WriteLine("Enter the minutes");
      string minutes = Console.ReadLine();
      if(CheckMinuteInput(minutes))
      {
        return minutes;
      }
      else
      {
        Console.WriteLine("Hey, that's not a valid minute value.");
        return PromptMinutes();
      }
    }

    public static void Main()
    {
      string inputHour = PromptHour();
      string inputMinutes = PromptMinutes();
      Clock newClock = new Clock(inputHour, inputMinutes);
      newClock.SetClockPositions();
      Console.WriteLine("At " + newClock.GetHoursInput() + ":" + newClock.GetMinutesInput() +", the hands on the clock are " + newClock.CalculateAngle() + " degrees apart!");
    }
  }

}
