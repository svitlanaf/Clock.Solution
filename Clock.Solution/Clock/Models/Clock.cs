using System;

namespace Clock
{
  public class Clock
  {
    private string HoursInput;
    private string MinutesInput;
    private float HoursPosition;
    private float MinutesPosition;

    public float GetMinutesPosition()
    {
      return MinutesPosition;
    }

    public float GetHoursPosition()
    {
      return HoursPosition;
    }

    public Clock(string hours, string minutes)
    {
      HoursInput = hours;
      MinutesInput = minutes;
    }

    public void SetClockPositions()
    {
      if (CheckTime())
      {
        MinutesPosition = float.Parse(MinutesInput);
        if(float.Parse(HoursInput) == 12)
        {
          HoursPosition = (MinutesPosition/60) * 5;
        }
        else if(float.Parse(HoursInput) > 12)
        {
          HoursPosition = ((float.Parse(HoursInput) - 12) * 5) + ((MinutesPosition/60) * 5);
        }
        else if(float.Parse(HoursInput) < 12)
        {
          HoursPosition = (float.Parse(HoursInput) * 5) + ((MinutesPosition/60) * 5);
        }
      }
    }

    public string GetHoursInput()
    {
      return HoursInput;
    }

    public string GetMinutesInput()
    {
      return MinutesInput;
    }

    public bool CheckTime()
    {
      if (int.TryParse(HoursInput, out int hoursResult) && int.TryParse(MinutesInput, out int minutesResult))
      {
        if ((hoursResult >= 0 && hoursResult <= 24) && (minutesResult >= 0 && minutesResult <= 60))
        {
          return true;
        }
        return false;
      }
      return false;
    }

    public float CalculateAngle()
    {
      Console.WriteLine(MinutesPosition.ToString());
      Console.WriteLine(HoursPosition.ToString());
      float difference = Math.Abs(MinutesPosition - HoursPosition);
      float degrees = difference * 6;
      if (360 - degrees < degrees)
      {
        degrees = 360 - degrees;
      }
      return degrees;
    }
  }
}
