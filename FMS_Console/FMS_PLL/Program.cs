using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using static System.Convert;

using FMS_BLL;
using FMS_Entity;
using FMS_Exception;
using ConsoleTables;

namespace FMS_PLL
{
    class Program
    {
        static Operation ops = new Operation();

        private static short Menu()
        {
            ForegroundColor = ConsoleColor.Yellow;
            WriteLine("\n=======FILM MANAGEMENT SYSTEM=======\n");
            WriteLine("1. Add Film");
            WriteLine("2. Search Film");
            WriteLine("3. Modify Film");
            WriteLine("4. Remove Film");
            WriteLine("5. View All");
            WriteLine("6. Exit");

            ForegroundColor = ConsoleColor.DarkGray;
            Write("\nEnter Choice : ");
            ForegroundColor = ConsoleColor.White;
            return ToInt16(ReadLine());
        }

        private static void Display(List<Film> filmList)
        {
            ForegroundColor = ConsoleColor.DarkGreen;
            ConsoleTable.From<Film>(filmList).Write();
        }

        static void Main(string[] args)
        {
            while (true)
            {
                short choice = Menu();
                WriteLine();

                ForegroundColor = ConsoleColor.DarkCyan;
                switch (choice)
                {
                    #region CREATE
                    case 1:
                        Film newFilm;
                        WriteLine("ENTER FILM DETAILS\n");
                        
                        Write("Film Title : ");
                        ForegroundColor = ConsoleColor.White;
                        string title = ReadLine();

                        ForegroundColor = ConsoleColor.DarkCyan;
                        Write("Description : ");
                        ForegroundColor = ConsoleColor.White;
                        string description = ReadLine();

                        ForegroundColor = ConsoleColor.DarkCyan;
                        Write("Release Year : ");
                        ForegroundColor = ConsoleColor.White;
                        int? releaseYear = ToInt32(ReadLine());

                        ForegroundColor = ConsoleColor.DarkCyan;
                        Write("Rental Duration (days) : ");
                        ForegroundColor = ConsoleColor.White;
                        int? rentalDuration = ToInt32(ReadLine());

                        ForegroundColor = ConsoleColor.DarkCyan;
                        Write("Rental Rate : Rs ");
                        ForegroundColor = ConsoleColor.White;
                        double? rentalRate = ToDouble(ReadLine());

                        ForegroundColor = ConsoleColor.DarkCyan;
                        Write("Length (minutes) : ");
                        ForegroundColor = ConsoleColor.White;
                        short? length = ToInt16(ReadLine());

                        ForegroundColor = ConsoleColor.DarkCyan;
                        Write("Replacement Cost : Rs ");
                        ForegroundColor = ConsoleColor.White;
                        double? replacementCost = ToDouble(ReadLine());

                        ForegroundColor = ConsoleColor.DarkCyan;
                        Write("Rating (out of 10) : ");
                        ForegroundColor = ConsoleColor.White;
                        float? rating = ToSingle(ReadLine());

                        ForegroundColor = ConsoleColor.DarkCyan;
                        Write("Actors (Separated by ',') : ");
                        ForegroundColor = ConsoleColor.White;
                        string actors = ReadLine();

                        ForegroundColor = ConsoleColor.DarkCyan;
                        Write("Category (Separated by ',') : ");
                        ForegroundColor = ConsoleColor.White;
                        string category = ReadLine();

                        ForegroundColor = ConsoleColor.DarkCyan;
                        Write("Language (Separated by ',') : ");
                        ForegroundColor = ConsoleColor.White;
                        string language = ReadLine();
                        
                        newFilm = new Film()
                        {
                            Title = title,
                            Description = description,
                            ReleaseYear = releaseYear,
                            RentalDuration = rentalDuration,
                            RentalRate = rentalRate,
                            Length = length,
                            ReplacementCost = replacementCost,
                            Rating = rating,
                            Actors = actors,
                            Category = category,
                            Language = language
                        };

                        if (ops.Create(newFilm))
                        {
                            ForegroundColor = ConsoleColor.Green;
                            WriteLine("\nFilm Added Successfully!\n");
                        }
                        else
                        {
                            ForegroundColor = ConsoleColor.DarkRed;
                            WriteLine("\nFILM NOT ADDED!\n");
                        }
                        //ForegroundColor = ConsoleColor.White;
                        break;
                    #endregion

                    #region READ
                    case 2:
                        ForegroundColor = ConsoleColor.Blue;
                        WriteLine("Search Parameters:");
                        Write("1. Title\t");
                        Write("2. Actor\t");
                        Write("3. Category\t");
                        Write("4. Language\n");
                        Write("5. Rating\n");
                        Write("0. Back to Menu\n");

                        ForegroundColor = ConsoleColor.DarkGray;
                        Write("\nEnter Search Choice : ");
                        ForegroundColor = ConsoleColor.White;
                        choice = ToInt16(ReadLine());
                        WriteLine();
                        ForegroundColor = ConsoleColor.DarkCyan;

                        List <Film> myFilms = null;

                        switch (choice)
                        {
                            case 1:
                                Write("Film Title : ");
                                ForegroundColor = ConsoleColor.White;
                                string searchBy = ReadLine();
                                myFilms = ops.SearchTitle(searchBy);
                                if (myFilms.Count == 0)
                                {
                                    ForegroundColor = ConsoleColor.DarkRed;
                                    WriteLine("\nFILM NOT FOUND!\n");
                                }
                                else
                                    Display(myFilms);
                                break;
                            case 2:
                                Write("Actor : ");
                                ForegroundColor = ConsoleColor.White;
                                searchBy = ReadLine();
                                myFilms = ops.SearchActor(searchBy);
                                if (myFilms.Count == 0)
                                {
                                    ForegroundColor = ConsoleColor.DarkRed;
                                    WriteLine("\nFILM NOT FOUND!\n");
                                }
                                else
                                    Display(myFilms);
                                break;
                            case 3:
                                Write("Category : ");
                                ForegroundColor = ConsoleColor.White;
                                searchBy = ReadLine();
                                myFilms = ops.SearchCategory(searchBy);
                                if (myFilms.Count == 0)
                                {
                                    ForegroundColor = ConsoleColor.DarkRed;
                                    WriteLine("\nFILM NOT FOUND!\n");
                                }
                                else
                                    Display(myFilms);
                                break;
                            case 4:
                                Write("Language : ");
                                ForegroundColor = ConsoleColor.White;
                                searchBy = ReadLine();
                                myFilms = ops.SearchLanguage(searchBy);
                                if (myFilms.Count == 0)
                                {
                                    ForegroundColor = ConsoleColor.DarkRed;
                                    WriteLine("\nFILM NOT FOUND!\n");
                                }
                                else
                                    Display(myFilms);
                                break;
                            case 5:
                                Write("Rating : ");
                                ForegroundColor = ConsoleColor.White;
                                float searchByRating = Single.Parse(ReadLine());
                                myFilms = ops.SearchRating(searchByRating);
                                if (myFilms.Count == 0)
                                {
                                    ForegroundColor = ConsoleColor.DarkRed;
                                    WriteLine("\nFILM NOT FOUND!\n");
                                }
                                else
                                    Display(myFilms);
                                break;
                            case 0:
                                continue;
                            default:
                                ForegroundColor = ConsoleColor.DarkRed;
                                WriteLine("INVALID CHOICE!\n");
                                continue;
                        }

                        break;
                    #endregion

                    #region UPDATE
                    case 3:
                        ForegroundColor = ConsoleColor.DarkCyan;
                        Write("Film Title : ");
                        ForegroundColor = ConsoleColor.White;
                        string searchTitle = ReadLine();
                        myFilms = ops.SearchTitle(searchTitle);
                        if (myFilms.Count == 0)
                        {
                            ForegroundColor = ConsoleColor.DarkRed;
                            WriteLine("\nFILM NOT FOUND!\n");
                            continue;
                        }

                        bool flag = true;
                        do
                        {
                            ForegroundColor = ConsoleColor.Blue;
                            WriteLine("Update Parameters:");
                            Write("1. Description\t\t");
                            Write("2. Release Year\t\t");
                            Write("3. Rental Duration\t");
                            Write("4. Rental Rate\t\t");
                            Write("5. Length\n");
                            Write("6. Replacement Cost\t");
                            Write("7. Rating\t\t");
                            Write("8. Actors\t\t");
                            Write("9. Category\t\t");
                            Write("10. Language\n");
                            Write("0. Back to Menu\n");

                            ForegroundColor = ConsoleColor.DarkGray;
                            Write("\nEnter Search Choice: ");
                            ForegroundColor = ConsoleColor.White;
                            choice = ToInt16(ReadLine());
                            WriteLine();
                            ForegroundColor = ConsoleColor.DarkCyan;

                            switch (choice)
                            {
                                case 1:
                                    ForegroundColor = ConsoleColor.DarkCyan;
                                    Write("New Description : ");
                                    ForegroundColor = ConsoleColor.White;
                                    description = ReadLine();
                                    if(ops.Modify(searchTitle, choice, description))
                                    {
                                        ForegroundColor = ConsoleColor.Green;
                                        WriteLine("\nFilm Description Updated Successfully!\n");
                                    }
                                    else
                                    {
                                        ForegroundColor = ConsoleColor.DarkRed;
                                        WriteLine("\nUPDATE FAILED!!\n");
                                    }
                                    break;
                                case 2:
                                    ForegroundColor = ConsoleColor.DarkCyan;
                                    Write("New Release Year : ");
                                    ForegroundColor = ConsoleColor.White;
                                    releaseYear = ToInt32(ReadLine());
                                    if (ops.Modify(searchTitle, choice, releaseYear.ToString()))
                                    {
                                        ForegroundColor = ConsoleColor.Green;
                                        WriteLine("\nRelease Year Updated Successfully!\n");
                                    }
                                    else
                                    {
                                        ForegroundColor = ConsoleColor.DarkRed;
                                        WriteLine("\nUPDATE FAILED!!\n");
                                    }
                                    break;
                                case 3:
                                    ForegroundColor = ConsoleColor.DarkCyan;
                                    Write("New Rental Duration (days) : ");
                                    ForegroundColor = ConsoleColor.White;
                                    rentalDuration = ToInt32(ReadLine());
                                    if (ops.Modify(searchTitle, choice, rentalDuration.ToString()))
                                    {
                                        ForegroundColor = ConsoleColor.Green;
                                        WriteLine("\nRental Duration Updated Successfully!\n");
                                    }
                                    else
                                    {
                                        ForegroundColor = ConsoleColor.DarkRed;
                                        WriteLine("\nUPDATE FAILED!!\n");
                                    }
                                    break;
                                case 4:
                                    ForegroundColor = ConsoleColor.DarkCyan;
                                    Write("New Rental Rate : Rs ");
                                    ForegroundColor = ConsoleColor.White;
                                    rentalRate = ToDouble(ReadLine());
                                    if (ops.Modify(searchTitle, choice, rentalRate.ToString()))
                                    {
                                        ForegroundColor = ConsoleColor.Green;
                                        WriteLine("\nRental Duration Updated Successfully!\n");
                                    }
                                    else
                                    {
                                        ForegroundColor = ConsoleColor.DarkRed;
                                        WriteLine("\nUPDATE FAILED!!\n");
                                    }
                                    break;
                                case 5:
                                    ForegroundColor = ConsoleColor.DarkCyan;
                                    Write("New Length (minutes) : ");
                                    ForegroundColor = ConsoleColor.White;
                                    length = ToInt16(ReadLine());
                                    if (ops.Modify(searchTitle, choice, length.ToString()))
                                    {
                                        ForegroundColor = ConsoleColor.Green;
                                        WriteLine("\nLength Updated Successfully!\n");
                                    }
                                    else
                                    {
                                        ForegroundColor = ConsoleColor.DarkRed;
                                        WriteLine("\nUPDATE FAILED!!\n");
                                    }
                                    break;
                                case 6:
                                    ForegroundColor = ConsoleColor.DarkCyan;
                                    Write("New Replacement Cost : Rs ");
                                    ForegroundColor = ConsoleColor.White;
                                    replacementCost = ToDouble(ReadLine());
                                    if (ops.Modify(searchTitle, choice, replacementCost.ToString()))
                                    {
                                        ForegroundColor = ConsoleColor.Green;
                                        WriteLine("\nReplacement Cost Updated Successfully!\n");
                                    }
                                    else
                                    {
                                        ForegroundColor = ConsoleColor.DarkRed;
                                        WriteLine("\nUPDATE FAILED!!\n");
                                    }
                                    break;
                                case 7:
                                    ForegroundColor = ConsoleColor.DarkCyan;
                                    Write("New Rating (out of 10) : ");
                                    ForegroundColor = ConsoleColor.White;
                                    rating = ToSingle(ReadLine());
                                    if (ops.Modify(searchTitle, choice, rating.ToString()))
                                    {
                                        ForegroundColor = ConsoleColor.Green;
                                        WriteLine("\nRating Updated Successfully!\n");
                                    }
                                    else
                                    {
                                        ForegroundColor = ConsoleColor.DarkRed;
                                        WriteLine("\nUPDATE FAILED!!\n");
                                    }
                                    break;
                                case 8:
                                    ForegroundColor = ConsoleColor.DarkCyan;
                                    Write("New Actors (Separated by ',') : ");
                                    ForegroundColor = ConsoleColor.White;
                                    actors = ReadLine();
                                    if (ops.Modify(searchTitle, choice, actors))
                                    {
                                        ForegroundColor = ConsoleColor.Green;
                                        WriteLine("\nActors Updated Successfully!\n");
                                    }
                                    else
                                    {
                                        ForegroundColor = ConsoleColor.DarkRed;
                                        WriteLine("\nUPDATE FAILED!!\n");
                                    }
                                    break;
                                case 9:
                                    ForegroundColor = ConsoleColor.DarkCyan;
                                    Write("New Category (Separated by ',') : ");
                                    ForegroundColor = ConsoleColor.White;
                                    category = ReadLine();
                                    if (ops.Modify(searchTitle, choice, category))
                                    {
                                        ForegroundColor = ConsoleColor.Green;
                                        WriteLine("\nCategory Updated Successfully!\n");
                                    }
                                    else
                                    {
                                        ForegroundColor = ConsoleColor.DarkRed;
                                        WriteLine("\nUPDATE FAILED!!\n");
                                    }
                                    break;
                                case 10:
                                    ForegroundColor = ConsoleColor.DarkCyan;
                                    Write("New Language (Separated by ',') : ");
                                    ForegroundColor = ConsoleColor.White;
                                    language = ReadLine();
                                    if (ops.Modify(searchTitle, choice, language))
                                    {
                                        ForegroundColor = ConsoleColor.Green;
                                        WriteLine("\nLanguage Updated Successfully!\n");
                                    }
                                    else
                                    {
                                        ForegroundColor = ConsoleColor.DarkRed;
                                        WriteLine("\nUPDATE FAILED!!\n");
                                    }
                                    break;
                                default:
                                    flag = false;
                                    break;
                            }
                        } while (flag);

                        break;
                    #endregion

                    #region DELETE
                    case 4:
                        ForegroundColor = ConsoleColor.DarkCyan;
                        Write("Title : ");
                        ForegroundColor = ConsoleColor.White;
                        searchTitle = ReadLine();
                        if(ops.Remove(searchTitle))
                        {
                            ForegroundColor = ConsoleColor.Green;
                            WriteLine("\nFilm Removed Successfully!\n");
                        }
                        else
                        {
                            ForegroundColor = ConsoleColor.DarkRed;
                            WriteLine("\nFILM NOT FOUND!\n");
                        }
                        break;
                    #endregion

                    case 5:
                        myFilms = ops.ViewAll();
                        if(myFilms.Count == 0)
                        {
                            ForegroundColor = ConsoleColor.DarkRed;
                            WriteLine("FILE IS EMPTY");
                        }
                        else
                            Display(myFilms);
                        break;

                    default:
                        ForegroundColor = ConsoleColor.White;
                        return;
                }
            }
        }        
    }
}
