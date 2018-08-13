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
    public class Song
    {
        private string title;
        private string singer;
        private string songwriter;
        private int year;
        private int duration;
        //in minutes
        public Song(string _title, string _singer, string _songwriter, int _year, int _duration)
        {
            title = _title;
            singer = _singer;
            songwriter = _songwriter;
            year = _year;
            duration = _duration;
        }
        public string Title
        // Title is immutable
        {
            get
            {
                return title;
            }
        }
        public string Singer
        // Singer is immutable
        {
            get
            {
                return singer;
            }
        }
        public string SongWriter
        // Songwriter is immutable
        {
            get
            {
                return songwriter;
            }
        }
        public int Year
        {
            get
            {
                return year;
            }
            set
            {
                year = value;
            }
        }
        public int Duration
        {
            get
            {
                return duration;
            }
            set
            {
                duration = value;
            }
        }
        public override string ToString()
        {
            return string.Format("{0} ({1}). Written by {2}. Released in \"{3}\" {4}mins."
                , title, singer, songwriter, year, duration);
            }
    }
}
