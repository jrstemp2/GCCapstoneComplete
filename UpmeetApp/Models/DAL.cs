using Dapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace UpmeetApp.Models
{
    public class DAL
    {

        private SqlConnection conn;
        public DAL(string connectionString)
        {
            conn = new SqlConnection(connectionString);
        }

        
        //-----------------EVENT---------------------------------------------------
        public IEnumerable<Event> GetAllEvents()
        {
            string queryString = "SELECT * FROM Events";
            IEnumerable<Event> events = conn.Query<Event>(queryString);
            return events;
        }

        public Event GetEventByID(int id)
        {
            string queryString = "SELECT * FROM Events WHERE ID= @id";
            Event singleEvent = conn.QueryFirst<Event>(queryString, new { id = id});
            return singleEvent;
        }

        //Add an Event
        public int AddEvent(Event singleEvent)
        {
            string addString = "INSERT INTO Events (Title, Description, EventDate, EventLocation) ";
            addString += "VALUES(@Title, @Description, @EventDate, @EventLocation)";
            return conn.Execute(addString, singleEvent);
        }

        //Delete an Event
        public int DeleteEventByID(int id)
        {
            string deleteString = "DELETE FROM Events WHERE ID = @id";
            return conn.Execute(deleteString, new { id = id });
        }

        //-----------------------------------------------------------------------



        //------------------------------FAVORITES--------------------------------
        //public IEnumerable<Favorite> GetAllFavorites()
        //{
        //    string queryString = "SELECT * FROM Favorites";
        //    IEnumerable<Favorite> favorites = conn.Query<Favorite>(queryString);
        //    return favorites;
        //}

        public IEnumerable<JoinedEF> GetJoined(int id)
        {
            string command = "SELECT * ";
            command += "FROM Events e JOIN Favorites f ON e.ID = f.EventID WHERE f.UserID=@id";
            IEnumerable<JoinedEF> result = conn.Query<JoinedEF>(command, new { id = id });
            return result;
        }

        public IEnumerable<Favorite> GetFavoritesByID(int id)
        {
            string queryString = "SELECT * FROM Favorites WHERE UserID=@id";
            IEnumerable<Favorite> myFavorite = conn.Query<Favorite>(queryString, new { id = id });
            return myFavorite;
        }

        //Add to favorites
        public int AddToFavorites(Favorite favorite)
        {
            string command = "INSERT INTO Favorites (EventID, UserID) ";
            command += "VALUES (@eventID, @userID)";

            int result = conn.Execute(command, new
            {
                eventID = favorite.EventID,
                userID = favorite.UserID,
            });
            return result;
        }

        //Delete from favorites

        public int DeleteFavoriteByID(int id)
        {
            string deleteString = "DELETE FROM Favorites WHERE ID = @id";
            return conn.Execute(deleteString, new { id = id });
        }

        



    }
}
