using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using UpmeetApp.Models;

namespace UpmeetApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteController : ControllerBase
    {
        private DAL dal;
        public FavoriteController(IConfiguration config)
        {
            dal = new DAL(config.GetConnectionString("default"));
        }


        [HttpGet("{id}")] //api/Favorite
        public IEnumerable<JoinedEF> GetAllFavorites(int id)
        {
            IEnumerable<JoinedEF> result = dal.GetJoined(id);

            return result;
        }

        

        //[HttpGet("{id}")] //api/Favorite/id
        //public IEnumerable<Favorite> GetFavoritesByID(int id)
        //{
        //    IEnumerable<Favorite> result = dal.GetFavoritesByID(id);
        //    return result;
        //}

        //Add to favorites
        [HttpPost]
        public int AddToFavorites(Favorite favoriteEvent)
        {
            int result = dal.AddToFavorites(favoriteEvent);
            return result;
        }
        [HttpDelete("{id}")]
        public int DeleteFavorite(int id)
        {
            int result = dal.DeleteFavoriteByID(id);
            return result;
        }
    }
}