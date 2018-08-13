using System;
using System.Globalization;
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
    public class DictionaryHandler
    {
        //Sets up TextInfo to allow conversion ToTitleCase
        TextInfo textinfo = new CultureInfo("en-US", false).TextInfo;

        //Displays song data on console for all current dictionary entries.
        public void Print(Dictionary<string, Song> songs)
        {
            foreach(KeyValuePair<string, Song> song in songs)
            {

                SongDuration newDuration = SongDuration.ConvertDuration(song.Value.Duration);

                Console.WriteLine("title: {0}, artist: {1}, songwriter: {2}, year: {3}, duration: {4}",
                    song.Value.Title, song.Value.Singer, song.Value.SongWriter, song.Value.Year, newDuration.ToString());

            }

        }

        //overloaded Print() function to print LINQ matches
        public void Print(KeyValuePair<string, Song> match)
        {

            SongDuration newDuration = SongDuration.ConvertDuration(match.Value.Duration);

            Console.WriteLine("title: {0}, artist: {1}, songwriter: {2}, year: {3}, duration: {4}",
                    match.Value.Title, match.Value.Singer, match.Value.SongWriter, match.Value.Year, newDuration.ToString());

        }

        //Deletes a dictionary entry by title
        public void DeleteByTitle(Dictionary<string, Song> songs, string title)
        {

            int matchCounter = 0;

            Console.WriteLine();

            var matches =
                from song in songs
                let lowerCase = song.Key.ToLower()
                where lowerCase.Equals(title)
                select lowerCase;

            var songsToRemove = new List<string>();

            foreach (string match in matches)
            {

                songsToRemove.Add(match);
                matchCounter++;

            }

            foreach (string song in songsToRemove)
            {
                songs.Remove(textinfo.ToTitleCase(song));
            }

            Console.WriteLine("{0} songs found and deleted.", matchCounter);
            matchCounter = 0;

        }

        //Prints all song titles that match user input string, and number of match results.
        public void GetSongByTitle(Dictionary<string, Song> songs, string title)
        {

            var matches =
            from song in songs
            let lowerCase = song.Key.ToLower()
            where lowerCase.Equals(title)
            orderby lowerCase
            select lowerCase;

            List<string> songlist = new List<string>();
            int songindex = 0;

            //Create a new list for the matches, increment successful matches
            foreach (string match in matches)
            {
                songlist.Add(textinfo.ToTitleCase(match));
                songindex++;

            }

            //print number of matches, reset counter.
            Console.WriteLine("{0} songs found:",songindex);
            songindex = 0;

            //print results.
            foreach(string song in songlist)
            {

                    Console.WriteLine("{0} by {1}", song, songs[song].Singer);

            }

        }

        //prints all  song data by title in ascending order
        public void PrintByTitle(Dictionary<string, Song> songs)
        {

            var matches =
            from song in songs
            orderby song.Key
            select song;

            //Print LINQ matches
            foreach (KeyValuePair<string, Song> match in matches)
            {
                Print(match);

            }

        }

        //Prints all song data by year in ascending order
        public void PrintByYear(Dictionary<string, Song> songs)
        {

            var matches =
            from song in songs
            orderby song.Value.Year
            select song;

            //Print LINQ matches
            foreach (KeyValuePair<string, Song> match in matches)
            {

                Print(match);

            }

        }

        //Prints all matches in a user-defined range of duration values, in ascending order
        public void PrintByDuration(Dictionary<string, Song> songs, int startDuration, int endDuration)
        {

            var matches =
            from song in songs
            
            where song.Value.Duration >= startDuration && song.Value.Duration <= endDuration
            orderby song.Value.Duration
            select song;


            //Print LINQ matches
            foreach (KeyValuePair<string, Song> match in matches)
            {

                Print(match);

            }

        }

        //Prints all song data by year in descending order
        public void PrintByYearDesc(Dictionary<string, Song> songs)
        {

            var matches =
            from song in songs
            orderby song.Value.Year descending
            select song;

            //Print LINQ matches
            foreach (KeyValuePair<string, Song> match in matches)
            {

                Print(match);

            }

        }
    }
}
