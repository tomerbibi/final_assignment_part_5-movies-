using Npgsql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_part_5__movies_
{
    static class DAO
    {
        static private readonly log4net.ILog my_logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        static private readonly string connection_string;
        static private NpgsqlConnection con = new NpgsqlConnection(connection_string);
        static DAO()
        {
            try
            {
                var reader = File.OpenText("Test_part_5_(movies).config.json");
                string connection_string = reader.ReadToEnd();
            }
            catch(Exception)
            {
                my_logger.Error("cannot create a connection (Test_part_5_(movies).config.json doesnt exist)");
            }
        }
        static public void ExecuteNonQuery(string query)
        {
            try
            {
                con.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.ExecuteScalar();
                con.Close();
            }
            catch(Exception)
            {
                my_logger.Error("wasnt able to connect to database");
            }
        }
        static public List<MovieActor> GetStores()
        {
            List<MovieActor> ma = new List<MovieActor>();
            con.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("select * from movies_actors", con);
            cmd.CommandType = System.Data.CommandType.Text;
            var reader = cmd.ExecuteReader();
            while (reader.Read() == true)
            {
                MovieActor m = new MovieActor((long)reader[0], (long)reader[1], (long)reader[2]);
                ma.Add(m);
            }
            con.Close();
            return ma;
        }
        static public MovieActor GetStoreById(int id)
        {
            con.Open();
            MovieActor ma = new MovieActor();
            NpgsqlCommand cmd = new NpgsqlCommand($"select * from Stores where ID = {id}", con);
            cmd.CommandType = System.Data.CommandType.Text;
            var reader = cmd.ExecuteReader();
            while (reader.Read() == true)
            {
                ma = new MovieActor((long)reader[0], (long)reader[1], (long)reader[2]);
                return ma;
            }
            con.Close();
            return ma;
        }
        static public void AddMovieActor(long movie_id, long actor_id)
        {
            try
            {
                ExecuteNonQuery($"insert into movies_actors(movie_id, actor_id) values ({movie_id}, {actor_id})");
                my_logger.Info("movie was added");
            }
            catch(Exception)
            {
                my_logger.Error("failed to add movie");
            }
        }
        static public void UpdateMovieActor(long id, long movie_id, long actor_id)
        {
                ExecuteNonQuery($"update movies_actors set movie_id = {movie_id}, actor_id = {actor_id} where id = {id}");
        }
        static public void DeleteMovieActor(int id)
        {
            try
            {
                ExecuteNonQuery($"delete from movies_actors where id = {id}");
                my_logger.Info("movie was deleted");

            }
            catch (Exception)
            {
                my_logger.Error("failed to delete movie");
            }
        }
        static public List<MovieActor> Get_movies_where_actor_born_befor_1972()
        {
            ExecuteNonQuery("select id, name, release_date, genre_id from (select movies.id ,movies.name, movies.release_date ,movies.genre_id,actors.id" +
            " idd from movies join actors on movies.id = actors.id where actors.birth_date < '1972-01-01') c");
                List<MovieActor> ma = new List<MovieActor>();
                con.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("select id, name, release_date, genre_id from (select movies.id ,movies.name, movies.release_date ,movies.genre_id,actors.id" +
            " idd from movies join actors on movies.id = actors.id where actors.birth_date < '1972-01-01') c", con);
                cmd.CommandType = System.Data.CommandType.Text;
                var reader = cmd.ExecuteReader();
                while (reader.Read() == true)
                {
                    MovieActor m = new MovieActor((long)reader[0], (long)reader[1], (long)reader[2]);
                    ma.Add(m);
                }
                con.Close();
                return ma;
            
        }
        
    }
}
