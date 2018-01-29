
using System;

namespace CleanCode.DuplicatedCode
{
    class DuplicatedCode
    {
        public void AdmitGuest(string name, string admissionDateTime)
        {
            // Some logic 
            // ...

            var time = Time.Parse(admissionDateTime);

            // Some more logic 
            // ...
            if (time.Hours < 10)
            {

            }
        }

        public void UpdateAdmission(int admissionId, string name, string admissionDateTime)
        {
            // Some logic 
            // ...

            var time = Time.Parse(admissionDateTime);
            // Some more logic 
            // ...
            if (time.Hours < 10)
            {

            }
        }
        //Primer Paso
        /*
        private static Time GetTime(string admissionDateTime)
        {
            int time;
            var hours = 0;
            var minutes = 0;
            if (!string.IsNullOrWhiteSpace(admissionDateTime))
            {
                if (int.TryParse(admissionDateTime.Replace(":", ""), out time))
                {
                    hours = time / 100;
                    minutes = time % 100;
                }
                else
                {
                    throw new ArgumentException("admissionDateTime");
                }
            }
            else
                throw new ArgumentNullException("admissionDateTime");
            return new Time { Hours=hours, Minutes=minutes };
        }
        */

        public class Time
        {
            public int Hours { get; set; }
            public int Minutes { get; set; }
            public static Time Parse(string text)
            {
                int time;
                var hours = 0;
                var minutes = 0;
                if (!string.IsNullOrWhiteSpace(text))
                {
                    if (int.TryParse(text.Replace(":", ""), out time))
                    {
                        hours = time / 100;
                        minutes = time % 100;
                    }
                    else
                    {
                        throw new ArgumentException("admissionDateTime");
                    }
                }
                else
                    throw new ArgumentNullException("admissionDateTime");
                return new Time { Hours = hours, Minutes = minutes };
            }
        }
        //DRY
        //Don't Repeat Yourself
    }
}
