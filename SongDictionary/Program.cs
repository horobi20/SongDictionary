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
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Song> songs = new Dictionary<string, Song>();
            DictionaryHandler handler = new DictionaryHandler();

            //Sets up TextInfo to allow conversion ToTitleCase
            TextInfo textinfo = new CultureInfo("en-US", false).TextInfo;

            Console.SetWindowSize(150, 32);

            CreateSongs();
            handler.Print(songs);
            PromptMenu();
            Console.WriteLine();

            Console.ReadLine();

            //Initializes the original song data for the dictionary of Song objects.
            void CreateSongs()
            {

                Song song1 = new Song("Narcolepsy", "Ben Folds Five", "Ben Folds", 1999, 324); // 5:24
                songs.Add(song1.Title, song1);

                Song song2 = new Song("Catalyst", "Kyla la Grange", "Kyla La Grange", 2012, 246); // 4:06
                songs.Add(song2.Title, song2);

                Song song3 = new Song("Take Me To Church", "Hozier", "Andrew Hozier-Byrne", 2014, 242); // 4:02
                songs.Add(song3.Title, song3);

                Song song4 = new Song("Family", "Dry The River", "Peter Liddle", 2011, 280); // 4:40
                songs.Add(song4.Title, song4);

                Song song5 = new Song("Obedear", "Purity Ring", "Megan James", 2012, 210); // 3:30
                songs.Add(song5.Title, song5);

                Song song6 = new Song("We're All Thieves", "Circa Survive", "Anthony Green", 2005, 294); // 4:54
                songs.Add(song6.Title, song6);

                Song song7 = new Song("Blue Lips", "Regina Spektor", "Regina Spektor", 2009, 212); // 3:32
                songs.Add(song7.Title, song7);

                Song song8 = new Song("Jungle", "Tash Sultana", "Tash Sultana", 2017, 316); // 5:16
                songs.Add(song8.Title, song8);

                Song song9 = new Song("Young", "Vallis Alps", "Parissa Tosif", 2015, 324); // 5:24
                songs.Add(song9.Title, song9);

                Song song10 = new Song("One More Cup Of Coffee", "Frazey Ford", "Bob Dylan", 2010, 259); // 4:19
                songs.Add(song10.Title, song10);

            }

            //Handle user key input for menu selection.
            int MenuHandler(ConsoleKey keypress)
            {

                switch (keypress)
                {
                    case ConsoleKey.D1:
                        return 1;

                    case ConsoleKey.D2:
                        return 2;

                    case ConsoleKey.D3:
                        return 3;

                    case ConsoleKey.D4:
                        return 4;

                    case ConsoleKey.D5:
                        return 5;

                    case ConsoleKey.D6:
                        return 6;

                    case ConsoleKey.D7:
                        return 7;

                    case ConsoleKey.D8:
                        return 8;

                    case ConsoleKey.D9:
                        return 9;

                    case ConsoleKey.D0:
                        return 0;

                    default:
                        Console.WriteLine("Invalid entry, try again.");
                        return 11;
                }

            }

            //Display menu options on console, run methods per user input. Return to menu afterwards.
            void PromptMenu()
            {

                Console.WriteLine();
                Console.WriteLine("Select an action by pressing a corresponding key." + Environment.NewLine +
                    "1. Display all saved song data on screen." + Environment.NewLine +
                    "2. Delete saved song data by title." + Environment.NewLine +
                    "3. Search specific saved song data by title." + Environment.NewLine +
                    "4. Display all saved song data on screen, by title (ascending)." + Environment.NewLine +
                    "5. Display all saved song data on screen, by year (ascending)." + Environment.NewLine +
                    "6. Display a range of song data on screen, by duration (ascending)." + Environment.NewLine +
                    "7. Display all saved song data on screen, by year (descending)." + Environment.NewLine +
                    "8. Run song duration comparison demos (one equal, one unequal comparison)." + Environment.NewLine +
                    "9. Run song duration addition demo." + Environment.NewLine +
                    "0. Run song duration subtraction demo.");

                Console.WriteLine();

                switch (MenuHandler(Console.ReadKey(true).Key))
                {

                    case (1):
                        handler.Print(songs);

                        PromptMenu();
                        break;

                    case (2):

                        Console.WriteLine("Type a song title below and hit enter to delete.");
                        handler.DeleteByTitle(songs, Console.ReadLine());

                        PromptMenu();
                        break;

                    case (3):

                        Console.WriteLine("Type a song title below and hit enter to search.");
                        handler.GetSongByTitle(songs, Console.ReadLine());

                        PromptMenu();
                        break;

                    case (4):

                        handler.PrintByTitle(songs);

                        PromptMenu();
                        break;

                    case (5):

                        handler.PrintByYear(songs);

                        PromptMenu();
                        break;


                    case (6):

                        Console.WriteLine("Type a minimum song duration in minutes below and hit enter.");
                        int min = (Convert.ToInt32(Console.ReadLine()) * 60);
                        Console.WriteLine("Now, type a maximum song duration in minutes below and hit enter.");
                        int max = (Convert.ToInt32(Console.ReadLine()) * 60);
                        handler.PrintByDuration(songs, min, max);

                        PromptMenu();
                        break;


                    case (7):


                        handler.PrintByYearDesc(songs);

                        PromptMenu();
                        break;

                    case (8):

                        DurationComparison(songs["Narcolepsy"], songs["Young"]);
                        DurationComparison(songs["Blue Lips"], songs["Family"]);

                        PromptMenu();
                        break;


                    case (9):

                        CombineDurations(songs["Narcolepsy"], songs["Young"]);

                        PromptMenu();
                        break;


                    case (0):

                        SubtractDurations(songs["Blue Lips"], songs["Family"]);

                        PromptMenu();
                        break;

                    case (11):

                        PromptMenu();
                        break;
                }
                Console.WriteLine();
                Console.ReadLine();

            }

            //Compares two song durations using '==', '!=', '<', '>', '>=' and '<='.
            //Prints statements that are 'true' to demonstrate results.
            void DurationComparison(Song s1, Song s2)
            {

                SongDuration s1Duration = SongDuration.ConvertDuration(s1.Duration);
                SongDuration s2Duration = SongDuration.ConvertDuration(s2.Duration);
                Console.WriteLine("True statements:");
                Console.WriteLine();
                try
                {
                    if (s1Duration == s2Duration)
                    {
                        Console.WriteLine("Songs are the same length!");
                    }
                    else if (s1Duration != s2Duration)
                        {
                            Console.WriteLine("Songs are NOT the same length!");
                        if (s1Duration < s2Duration)
                        {

                            Console.WriteLine("Song 1 is shorter than song 2.");
                        }
                        if (s1Duration <= s2Duration)
                        {

                            Console.WriteLine("Song 1 is shorter than or equal to song 2.");
                        }
                        if (s1Duration > s2Duration)
                        {

                            Console.WriteLine("Song 1 is longer than song 2.");
                        }
                        if (s1Duration >= s2Duration)
                        {

                            Console.WriteLine("Song 1 is longer than or equal to song 2.");
                        }

                    }

                    else
                    {
                        throw new Exception("Could not compare those two song durations, check input and try again.");
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }

            }

            //Adds two song duration. Prints the combined duration.
            void CombineDurations(Song s1, Song s2)
            {

                SongDuration newDuration = SongDuration.ConvertDuration(s1.Duration + s2.Duration);

                Console.WriteLine("Combined play time for songs '{0}' and '{1}' is: {2}"
                    , s1.Title, s2.Title,  newDuration.ToString());

            }

            //Subtracts two song durations. Prints the duration difference (positive or negative)
            void SubtractDurations(Song s1, Song s2)
            {

                SongDuration newDuration = SongDuration.ConvertDuration(s1.Duration - s2.Duration);

                //tests for negative values
                if(newDuration.negative == false)
                {
                    Console.WriteLine("'{0}' is longer than '{1}' by: {2}"
                    , s1.Title, s2.Title, newDuration.ToString());
                }
                else if (newDuration.negative == true)
                {
                    Console.WriteLine("'{0}' is shorter than '{1}' by: {2}"
                    , s1.Title, s2.Title, newDuration.ToString());
                }
                else
                {
                    Console.WriteLine("Songs are the same length!");
                }

            }
        }
    }
}
