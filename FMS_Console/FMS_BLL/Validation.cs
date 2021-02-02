using FMS_Entity;
using FMS_Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FMS_BLL
{
    class Validation
    {
        public static bool ValidateFilm(Film myFilm)
        {
            StringBuilder sb = new StringBuilder();
            bool validFilm = true;

            //Title
            if (myFilm.Title == string.Empty)
            {
                validFilm = false;
                sb.Append(Environment.NewLine + "Film Title Cannot Be Left Empty!");
            }
            else if (!Regex.IsMatch(myFilm.Title, "[A-Z0-9][A-Za-z0-9.?/: !&-]+"))
            {
                validFilm = false;
                sb.Append(Environment.NewLine + "Invalid Film Title!");
            }

            //Description
            if (myFilm.Description == string.Empty)
            {
                validFilm = false;
                sb.Append(Environment.NewLine + "Film Description Cannot Be Left Empty!");
            }
            else if (!Regex.IsMatch(myFilm.Description, "[A-Z0-9][A-Za-z0-9.?&/: -]+"))
            {
                validFilm = false;
                sb.Append(Environment.NewLine + "Invalid Film Description!");
            }

            //Release Year
            if (!myFilm.ReleaseYear.HasValue)
            {
                validFilm = false;
                sb.Append(Environment.NewLine + "'Release Year' Cannot Be Left Empty!");
            }
            else if (!(myFilm.ReleaseYear >= 1900 && myFilm.ReleaseYear <= DateTime.Now.Year + 1))
            {
                validFilm = false;
                sb.Append(Environment.NewLine + "Invalid Release Year!");
            }

            //Actors
            if (myFilm.Actors == string.Empty)
            {
                validFilm = false;
                sb.Append(Environment.NewLine + "'Actors' Cannot Be Left Empty!");
            }
            else
            {
                bool validName = true;
                string[] actors = myFilm.Actors.Split(',');
                foreach (var item in actors)
                {
                    if (!Regex.IsMatch(item.Trim(), "[A-Z][a-z]*[ ]*[A-Za-z]*[ ]*[A-Za-z]*[ ]*[A-Za-z]*"))
                        validName = false;
                }
                if (!validName)
                {
                    validFilm = false;
                    sb.Append(Environment.NewLine + "Invalid Input In 'Actors'!");
                }
            }

            //Category
            if (myFilm.Category == string.Empty)
            {
                validFilm = false;
                sb.Append(Environment.NewLine + "'Category' Cannot Be Left Empty!");
            }
            else
            {
                bool validName = true;
                string[] category = myFilm.Category.Split(',');
                foreach (var item in category)
                {
                    if (!Regex.IsMatch(item.Trim(), "[A-Z][a-z]*[ ]*[A-Za-z]*[ ]*[A-Za-z]*[ ]*[A-Za-z]*"))
                        validName = false;
                }
                if (!validName)
                {
                    validFilm = false;
                    sb.Append(Environment.NewLine + "Invalid Input In 'Category'!");
                }
            }

            //Language
            if (myFilm.Language == string.Empty)
            {
                validFilm = false;
                sb.Append(Environment.NewLine + "'Language' Cannot Be Left Empty!");
            }
            else
            {
                bool validName = true;
                string[] language = myFilm.Language.Split(',');
                foreach (var item in language)
                {
                    if (!Regex.IsMatch(item.Trim(), "[A-Z][a-z]+[-]*[A-Za-z]"))
                        validName = false;
                }
                if (!validName)
                {
                    validFilm = false;
                    sb.Append(Environment.NewLine + "Invalid Input In 'Language'!");
                }
            }

            //Length
            if (myFilm.Length.HasValue && myFilm.Length < 10 || myFilm.Length > 300)
            {
                validFilm = false;
                sb.Append(Environment.NewLine + "Invalid Film Length!");
            }

            //RentalDuration
            if (myFilm.RentalDuration.HasValue && myFilm.RentalDuration < 10)
            {
                validFilm = false;
                sb.Append(Environment.NewLine + "Invalid Rental Duration!");
            }

            //RentalRate
            if (myFilm.RentalRate.HasValue && myFilm.RentalRate < 50)
            {
                validFilm = false;
                sb.Append(Environment.NewLine + "Invalid Rental Rate!");
            }

            //ReplacementCost
            if (myFilm.ReplacementCost.HasValue && myFilm.ReplacementCost < 75)
            {
                validFilm = false;
                sb.Append(Environment.NewLine + "Invalid Replacement Cost!");
            }

            //Rating
            if (myFilm.Rating.HasValue && myFilm.Rating < 0.1 || myFilm.Rating > 10)
            {
                validFilm = false;
                sb.Append(Environment.NewLine + "Invalid Rating!");
            }
            try
            {
                if (!validFilm)
                    throw new MyException(sb.ToString());
            }
            catch(MyException e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
            }

            return validFilm;
        }

    }
}
