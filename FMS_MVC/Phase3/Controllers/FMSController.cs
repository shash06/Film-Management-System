using Phase3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace Phase3.Controllers
{
    public class FMSController : Controller
    {
        MyDatabase dbcon = new MyDatabase();

        static List<SelectListItem> categories;
        static List<SelectListItem> languages;

        //VIEW ALL
        public ActionResult FilmList(string title, string rating, string releaseYear)
        {
            if (title == null && rating == null && releaseYear == null)
                return View(dbcon.Films.ToList());

            List<Film> allFilms = dbcon.Films.Where(film => 
            (film.Title.Contains(title) || title == string.Empty) &&
            ( rating == string.Empty || film.Rating.ToString() == rating || rating == film.Rating.ToString().Substring(0,1) ) &&
            (releaseYear == string.Empty || film.Release_Year.ToString() == releaseYear )).ToList();
            
            return View(allFilms);
        }


        //DETAILS
        public ActionResult Details(int id)
        {
            return View();
        }

        //CREATE
        [HttpGet]
        public ActionResult AddFilm()
        {
            ViewBag.Category = new SelectList(AddCategories(), "Category", "Text");
            ViewBag.Language = new SelectList(AddLanguages(), "Language", "Text");
            //ViewBag.getCategories = AddCategories();
            //ViewBag.getLanguages = AddLanguages();
            return View();
        }
        [HttpPost]
        public ActionResult AddFilm(Film newFilm)
        {
            try
            {
                //newFilm.Category = Request.Form["ddlCategories"].ToString();
                //newFilm.Language = Request.Form["ddlLanguages"].ToString();
                dbcon.Films.Add(newFilm);
                dbcon.SaveChanges();
                Response.Write("Film Added Successfully!");
                return RedirectToAction("FilmList");
            }
            catch
            {
                return View();
            }
        }

        //UPDATE
        [HttpGet]
        public ActionResult EditFilm(int id)
        {
            Film myFilm = dbcon.Films.ToList().Find(film => film.Film_ID == id);
            return View(myFilm);
        }
        [HttpPost]
        public ActionResult EditFilm(int id, Film newFilm)
        {
            try
            {
                Film myFilm = dbcon.Films.ToList().Find(Film => Film.Film_ID == id);
                myFilm.Description = newFilm.Description;
                myFilm.Release_Year = newFilm.Release_Year;
                myFilm.Actors = newFilm.Actors;
                myFilm.Category = newFilm.Category;
                myFilm.Language = newFilm.Language;
                myFilm.Rating = newFilm.Rating;
                myFilm.Length = newFilm.Length;
                myFilm.Rental_Duration = newFilm.Rental_Duration;
                myFilm.Rental_Rate = newFilm.Rental_Rate;
                myFilm.Replacement_Cost = newFilm.Replacement_Cost;
                dbcon.SaveChanges();

                return RedirectToAction("FilmList");
            }
            catch
            {
                return View();
            }
        }

        //DELETE
        [HttpGet]
        public ActionResult DeleteFilm(int id)
        {
            Film myFilm = dbcon.Films.ToList().Find(film => film.Film_ID == id);
            return View(myFilm);
        }
        [HttpPost]
        public ActionResult DeleteFilm(int id, Film delFilm)
        {
            try
            {
                Film myFilm = dbcon.Films.ToList().Find(Film => Film.Film_ID == id);
                dbcon.Films.Remove(myFilm);
                dbcon.SaveChanges();

                return RedirectToAction("FilmList");
            }
            catch
            {
                return View();
            }
        }

        [NonAction]
        public List<SelectListItem> AddCategories()
        {
            categories = new List<SelectListItem>();

            foreach (string item in MyLists.allCategories)
            {
                SelectListItem category = new SelectListItem();
                category.Text = item;
                category.Value = item;
                categories.Add(category);
            }

            return categories;
        }
        [NonAction]
        public List<SelectListItem> AddLanguages()
        {
            languages = new List<SelectListItem>();

            foreach (string item in MyLists.allLanguages)
            {
                SelectListItem language = new SelectListItem();
                language.Text = item;
                language.Value = item;
                languages.Add(language);
            }

            return languages;
        }
    }
}
