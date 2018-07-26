
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPIMovies.DB;

namespace MovieWebApi.Controllers
{
    public class LoginController : ApiController
    {
        MoviesDBDataContext MOVDB = new MoviesDBDataContext();
        // GET: api/Login
        [HttpGet]
        public Login_userResult GetLoginUser(string UserName, string Passowrd)
        {
           
           var userdata =  MOVDB.Login_user(Passowrd, UserName).SingleOrDefault();
            
            
            return userdata;
        }

        [HttpPost]
        [Route("Regstration")]
        // GET: api/regest
        public IEnumerable<insert_New_UserResult> PostRegstration(string email, string Passowrd, string UserName, string First_Name, string lastname, string soicalid, string oauthtype)
        {
            
            var Isregst = MOVDB.insert_New_User(email, Passowrd, UserName,First_Name,lastname,soicalid,oauthtype);
           
            return Isregst;
        }

        [HttpPost]
        [Route("Update/UserInfo")]
        // GET: api/regest
        public int PostUpdateuser(int userid,string email, string Passowrd, string UserName, string First_Name, string lastname)
        {

            var Isregst = MOVDB.Update_user(userid, UserName, email, Passowrd, First_Name, lastname);

            return Isregst;
        }
        
        [Route("getUser")]
        // GET: api/regest
        public IEnumerable<getuserResult> GetUser(string soicalid)
        {

            var Isregst = MOVDB.getuser( soicalid).ToList();

            return Isregst;
        }

        
    }
}
