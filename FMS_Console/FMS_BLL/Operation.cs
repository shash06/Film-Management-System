using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FMS_Entity;
using FMS_Exception;
using FMS_DAL;
using System.Text.RegularExpressions;

namespace FMS_BLL
{
    public class Operation
    {
        
        public bool Create(Film newFilm)
        {
            if (!Validation.ValidateFilm(newFilm))
                return false;
            List<Film> filmList = FileSerialize.DoDeserialize();
            if (filmList.Count != 0)
            {
                var res = filmList.Find(film => film.Title == newFilm.Title);
                if (res != null)
                    return false;
            }

            filmList.Add(newFilm);
            FileSerialize.DoSerialize(filmList);
            return true;
        }

        public List<Film> SearchTitle(string title)
        {
            List<Film> filmList = FileSerialize.DoDeserialize();
            if (filmList == null)
                return null;
            List<Film> myFilms = filmList.FindAll(film => film.Title == title);
            if (myFilms == null)
                return null;
            return myFilms;
        }

        public List<Film> SearchActor(string actor)
        {
            List<Film> filmList = FileSerialize.DoDeserialize();
            List<Film> myFilms = filmList.FindAll(film => film.Actors.Contains(actor));
            if (myFilms == null)
                return null;
            return myFilms;
        }

        public List<Film> SearchCategory(string category)
        {
            List<Film> filmList = FileSerialize.DoDeserialize();
            List<Film> myFilms = filmList.FindAll(film => film.Category.Contains(category));
            if (myFilms == null)
                return null;
            return myFilms;
        }

        public List<Film> SearchLanguage(string language)
        {
            List<Film> filmList = FileSerialize.DoDeserialize();
            List<Film> myFilms = filmList.FindAll(film => film.Language.Contains(language));
            if (myFilms == null)
                return null;
            return myFilms;
        }

        public List<Film> SearchRating(float rating)
        {
            List<Film> filmList = FileSerialize.DoDeserialize();
            List<Film> myFilms = filmList.FindAll(film => film.Rating == rating);
            if (myFilms == null)
                return null;
            return myFilms;
        }

        public bool Remove(string title)
        {
            List<Film> filmList = FileSerialize.DoDeserialize();
            Film delFilm = filmList.Find(film => film.Title == title);
            if (delFilm == null)
                return false;
            filmList.Remove(delFilm);
            FileSerialize.DoSerialize(filmList);
            return true;
        }

        public bool Modify(string title, short choice, string updateThis)
        {
            List<Film> filmList = FileSerialize.DoDeserialize();
            Film myFilm = filmList.Find(film => film.Title == title);
            if (myFilm == null)
                return false;

            switch (choice)
            {
                case 1:
                    myFilm.Description = updateThis;
                    break;
                case 2:
                    myFilm.ReleaseYear = Int32.Parse(updateThis);
                    break;
                case 3:
                    myFilm.RentalDuration = Int32.Parse(updateThis);
                    break;
                case 4:
                    myFilm.RentalRate = Double.Parse(updateThis); ;
                    break;
                case 5:
                    myFilm.Length = Int16.Parse(updateThis);
                    break;
                case 6:
                    myFilm.ReplacementCost = Double.Parse(updateThis);
                    break;
                case 7:
                    myFilm.Rating = float.Parse(updateThis);
                    break;
                case 8:
                    myFilm.Actors = updateThis;
                    break;
                case 9:
                    myFilm.Category = updateThis;
                    break;
                case 10:
                    myFilm.Language = updateThis;
                    break;
                default:
                    break;
            }

            if (!Validation.ValidateFilm(myFilm))
                return false;

            FileSerialize.DoSerialize(filmList);
            return true;
        }

        public List<Film> ViewAll()
        {
            return FileSerialize.DoDeserialize();
        }
    }
}