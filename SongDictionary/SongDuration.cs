using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Course: CSC10210 - Object Oriented Program Development
 * Project: Store Tracker (assignment 2, Part 2 & 3)
 * Author: Harry Robinson (22787039)
 * Date: 03/01/2018 
 */
namespace SongDictionary
{
    class SongDuration
    {

        public int Minutes { get; set; }
        public int Seconds { get; set; }

        //indicates if a duration has a negative value (<0 minutes or seconds)
        public bool negative = false;

        //constructor for a new SongDuration object. Tests for negative values and
        //for values outside allowable rage for positive durations.
        public SongDuration(int m, int s, bool n)
        {
            if (n == false)
            {
                try
                {

                    //test if minutes will be between 0 and 20 before constructing duration
                    if (m > 20 || m < 0)
                    {
                        throw new ArgumentOutOfRangeException("Minutes. Please enter a valid minutes value");
                    }
                    else
                    {
                        Minutes = m;
                    }

                    //test if seconds will be < 59 before constructing duration
                    if (s > 59)
                    {
                        throw new ArgumentOutOfRangeException("Seconds. Please enter a valid seconds value");
                    }
                    else
                    {
                        Seconds = s;
                    }

                    negative = n;

                }
                catch (ArgumentOutOfRangeException ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Minutes = m;
                Seconds = s;
                negative = true;
            }            

        }

        //Converts a song's duration into a SongDuration object (minutes : seconds)
        //Converts negative duration's into positive (only for the purpose of subtraction)
        public static SongDuration ConvertDuration(int duration)
        {

            int minutes = duration / 60;
            int seconds = duration % 60;

            if(minutes <= 0 && seconds < 0)
            {
                minutes = -minutes;
                seconds = -seconds;

                return new SongDuration(minutes, seconds, true);
            }
            else
            {
                return new SongDuration(minutes, seconds, false);
            }

        }

        //converts the SongDuration.ToString() conversion method to display in the minutes : seconds format.
        public override string ToString()
        {

            return string.Format("{0}:{1:D2}", Minutes, Seconds);

        }

        //overloads the 'equal to' operator to allow comparison of two SongDuration objects.
        public static bool operator ==(SongDuration sd1, SongDuration sd2)
        {

            bool status = false;
            if(sd1.Minutes == sd2.Minutes && sd1.Seconds == sd2.Seconds)
            {
                status = true;
            }

            return status;

        }

        //overloads the 'not equal to' operator to allow comparison of two SongDuration objects.
        public static bool operator !=(SongDuration sd1, SongDuration sd2)
        {

            bool status = false;
            if (sd1.Minutes != sd2.Minutes && sd1.Seconds != sd2.Seconds)
            {
                status = true;
            }

            return status;

        }

        //overloads the 'less than' operator to allow comparison of two SongDuration objects.
        public static bool operator <(SongDuration sd1, SongDuration sd2)
        {

            bool status = false;

            //convert song durations back to seconds for comparison.
            int csd1 = (sd1.Minutes * 60) + sd1.Seconds;
            int csd2 = (sd2.Minutes * 60) + sd2.Seconds;


            if (csd1 < csd2)
            {
                status = true;
            }

            return status;

        }

        //overloads the 'greater than' operator to allow comparison of two SongDuration objects.
        public static bool operator >(SongDuration sd1, SongDuration sd2)
        {

            bool status = false;

            //convert song durations back to seconds for comparison.
            int csd1 = (sd1.Minutes * 60) + sd1.Seconds;
            int csd2 = (sd2.Minutes * 60) + sd2.Seconds;


            if (csd1 > csd2)
            {
                status = true;
            }

            return status;

        }

        //overloads the 'less than or equal to' operator to allow comparison of two SongDuration objects.
        public static bool operator <=(SongDuration sd1, SongDuration sd2)
        {

            bool status = false;

            //convert song durations back to seconds for comparison.
            int csd1 = (sd1.Minutes * 60) + sd1.Seconds;
            int csd2 = (sd2.Minutes * 60) + sd2.Seconds;


            if (csd1 <= csd2)
            {
                status = true;
            }

            return status;

        }

        //overloads the 'greater than or equal to' operator to allow comparison of two SongDuration objects.
        public static bool operator >=(SongDuration sd1, SongDuration sd2)
        {

            bool status = false;

            //convert song durations back to seconds for comparison.
            int csd1 = (sd1.Minutes * 60) + sd1.Seconds;
            int csd2 = (sd2.Minutes * 60) + sd2.Seconds;


            if (csd1 >= csd2)
            {
                status = true;
            }

            return status;

        }
        //overloads the addition operator to allow addition of two SongDuration objects.
        public static SongDuration operator +(SongDuration sd1, SongDuration sd2)
        {

            //convert song durations back to seconds for addition.
            int csd1 = (sd1.Minutes * 60) + sd1.Seconds;
            int csd2 = (sd2.Minutes * 60) + sd2.Seconds;

            //add both convereted song duration to form a new duration.
            int newcsd = csd1 + csd2;

            //Use the ConvertDuration() method to convert back into a SongDuration object.
            return ConvertDuration(newcsd);

        }

        //overloads the subtraction operator to allow subtraction of two SongDuration objects.
        public static SongDuration operator -(SongDuration sd1, SongDuration sd2)
        {

            //convert song durations back to seconds for addition.
            int csd1 = (sd1.Minutes * 60) + sd1.Seconds;
            int csd2 = (sd2.Minutes * 60) + sd2.Seconds;

            //subtract both convereted song duration to form a new duration.
            int newcsd = csd1 - csd2;

            //Use the ConvertDuration() method to convert back into a SongDuration object.
            return ConvertDuration(newcsd);

        }
    }
}
