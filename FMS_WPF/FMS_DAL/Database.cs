using FMS_Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMS_DAL
{
    public class Database
    {
        static SqlConnection con = new SqlConnection(@"Server = localhost; Database=ShashwatDB;Trusted_Connection=True;");

        public static bool Insert(Film newFilm)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_InsertFilm";

                cmd.Parameters.AddWithValue("@Title", newFilm.Title);
                cmd.Parameters.AddWithValue("@Description", newFilm.Description);
                cmd.Parameters.AddWithValue("@ReleaseYear", newFilm.ReleaseYear);
                if(newFilm.RentalDuration == null)
                    cmd.Parameters.AddWithValue("@RentalDuration", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@RentalDuration", newFilm.RentalDuration);
                if (newFilm.RentalRate == null)
                    cmd.Parameters.AddWithValue("@RentalRate", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@RentalRate", newFilm.RentalRate);
                if (newFilm.Length == null)
                    cmd.Parameters.AddWithValue("@Length", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Length", newFilm.Length);
                if (newFilm.ReplacementCost == null)
                    cmd.Parameters.AddWithValue("@ReplacementCost", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@ReplacementCost", newFilm.ReplacementCost);
                if (newFilm.Rating == null)
                    cmd.Parameters.AddWithValue("@Rating", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Rating", newFilm.Rating);
                cmd.Parameters.AddWithValue("@Actors", newFilm.Actors);
                cmd.Parameters.AddWithValue("@Category", newFilm.Category);
                cmd.Parameters.AddWithValue("@Language", newFilm.Language);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected == 1)
                    return true;
                return false;
            }

            catch
            {
                return false;
            }
            finally
            {
                if(con.State==ConnectionState.Open)
                    con.Close();
            }
        }

        public static List<Film> Search(Film myFilm)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_SearchFilm";

                if(myFilm.Title == null)
                    cmd.Parameters.AddWithValue("@Title", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Title", myFilm.Title);

                if (myFilm.ReleaseYear == null)
                    cmd.Parameters.AddWithValue("@ReleaseYear", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@ReleaseYear", myFilm.ReleaseYear);

                if (myFilm.Rating == null)
                    cmd.Parameters.AddWithValue("@Rating", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Rating", myFilm.Rating);

                SqlDataReader reader = cmd.ExecuteReader();

                if (!reader.HasRows)
                    return null;

                List<Film> myFilms = new List<Film>();
                while (reader.Read())
                {
                    Film film = new Film()
                    {
                        Title = reader[1].ToString(),
                        Description = reader[2].ToString(),
                        ReleaseYear = Convert.ToInt32(reader[3]),
                        //RentalDuration = Convert.ToInt32(reader[4]),
                        //RentalRate = Convert.ToDouble(reader[5]),
                        //Length = Convert.ToInt16(reader[6]),
                        //ReplacementCost = Convert.ToDouble(reader[7]),
                        //Rating = Convert.ToSingle(reader[8]),
                        Actors = reader[9].ToString(),
                        Category = reader[10].ToString(),
                        Language = reader[11].ToString()
                    };

                    if (reader[4] != null)
                        film.RentalDuration = Convert.ToInt32(reader[4]);
                    else
                        film.RentalDuration = 0;
                    if (reader[5] != null)
                        film.RentalRate = Convert.ToDouble(reader[5]);
                    else
                        film.RentalRate = 0;
                    if (reader[6] != null)
                        film.Length = Convert.ToInt16(reader[6]);
                    else
                        film.Length = 0;
                    if (reader[7] != null)
                        film.ReplacementCost = Convert.ToDouble(reader[7]);
                    else
                        film.ReplacementCost = 0;
                    if (reader[8] != null)
                        film.Rating = Convert.ToSingle(reader[8]);
                    else
                        film.Rating = 0;

                    myFilms.Add(film);
                }

                return myFilms;
            }

            catch
            {
                return null;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }

        public static bool Update(Film myFilm)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_UpdateFilm";

                cmd.Parameters.AddWithValue("@Title", myFilm.Title);
                cmd.Parameters.AddWithValue("@Description", myFilm.Description);
                cmd.Parameters.AddWithValue("@ReleaseYear", myFilm.ReleaseYear);
                if (myFilm.RentalDuration == null)
                    cmd.Parameters.AddWithValue("@RentalDuration", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@RentalDuration", myFilm.RentalDuration);
                if (myFilm.RentalRate == null)
                    cmd.Parameters.AddWithValue("@RentalRate", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@RentalRate", myFilm.RentalRate);
                if (myFilm.Length == null)
                    cmd.Parameters.AddWithValue("@Length", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Length", myFilm.Length);
                if (myFilm.ReplacementCost == null)
                    cmd.Parameters.AddWithValue("@ReplacementCost", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@ReplacementCost", myFilm.ReplacementCost);
                if (myFilm.Rating == null)
                    cmd.Parameters.AddWithValue("@Rating", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Rating", myFilm.Rating);
                cmd.Parameters.AddWithValue("@Actors", myFilm.Actors);
                cmd.Parameters.AddWithValue("@Category", myFilm.Category);
                cmd.Parameters.AddWithValue("@Language", myFilm.Language);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected == 1)
                    return true;
                return false;
            }

            catch
            {
                return false;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }

        public static bool Delete(string myTitle)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_DeleteFilm";

                cmd.Parameters.AddWithValue("@Title", myTitle);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected == 1)
                    return true;
                return false;
            }

            catch
            {
                return false;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }

        public static List<Film> ViewAll()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Films";
                
                SqlDataReader reader = cmd.ExecuteReader();

                if (!reader.HasRows)
                    return null;

                List<Film> myFilms = new List<Film>();
                while (reader.Read())
                {
                    Film film = new Film()
                    {
                        Title = reader[1].ToString(),
                        Description = reader[2].ToString(),
                        ReleaseYear = Convert.ToInt32(reader[3]),
                        //RentalDuration = Convert.ToInt32(reader[4]),
                        //RentalRate = Convert.ToDouble(reader[5]),
                        //Length = Convert.ToInt16(reader[6]),
                        //ReplacementCost = Convert.ToDouble(reader[7]),
                        //Rating = Convert.ToSingle(reader[8]),
                        Actors = reader[9].ToString(),
                        Category = reader[10].ToString(),
                        Language = reader[11].ToString()
                    };

                    if (reader[4] != null)
                        film.RentalDuration = Convert.ToInt32(reader[4]);
                    else
                        film.RentalDuration = 0;
                    if (reader[5] != null)
                        film.RentalRate = Convert.ToDouble(reader[5]);
                    else
                        film.RentalRate = 0;
                    if (reader[6] != null)
                        film.Length = Convert.ToInt16(reader[6]);
                    else
                        film.Length = 0;
                    if (reader[7] != null)
                        film.ReplacementCost = Convert.ToDouble(reader[7]);
                    else
                        film.ReplacementCost = 0;
                    if (reader[8] != null)
                        film.Rating = Convert.ToSingle(reader[8]);
                    else
                        film.Rating = 0;

                    myFilms.Add(film);
                }

                return myFilms;
            }

            catch
            {
                return null;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }
    }
}
