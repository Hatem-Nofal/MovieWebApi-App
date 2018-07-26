using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebAPIMovies.DB;

namespace MovieWebApi.Controllers
{
    
    public class Comment_MovieController : ApiController
    {
        
        MoviesDBDataContext MOVDB = new MoviesDBDataContext();

   // [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]  
        public IEnumerable<Get_Movie_CommentResult> GetWishMovie(int UserID)
        {
            var Commentslist = MOVDB.Get_Movie_Comment(UserID).ToList();
            return Commentslist;
            
        }


     //   [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]  
        // POST: api/Movies
        [HttpPost]
        public int PostInsertMovieComment(int ID_User, string Comment_movie,  int Movie_id,int Rating)
        {

            return MOVDB.Insert_wish_movies_list(ID_User,Comment_movie,Movie_id,Rating);
        }
    }
}
