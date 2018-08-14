
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
            
            var result = MOVDB.insert_New_User(email, Passowrd, UserName,First_Name,lastname,soicalid,oauthtype);
           
            return result;
        }

        [HttpPost]
        [Route("Update/UserInfo")]
        // GET: api/regest
        public IEnumerable<Update_userResult>PostUpdateuser(int userid,string email, string UserName, string First_Name, string lastname)
        {

            var result = MOVDB.Update_user(userid, UserName, email, First_Name, lastname).ToList();

            return result;
        }
        
        [Route("getUser")]
        // GET: api/regest
        public IEnumerable<getuserResult> GetUser(string soicalid)
        {

            var result = MOVDB.getuser( soicalid).ToList();

            return result;
        }
        [Route("getemail")]
        // GET: api/regest
        public getuseremailResult Getemail(string useremail)
        {

            var result = MOVDB.getuseremail(useremail).Single();

            return result;
        }
        [Route("GetUserById")]
        // GET: api/regest
        public getuserbyidResult GetUserById(string userid)
        {

            var result = MOVDB.getuserbyid(userid).Single();

            return result;
        }



    }
}
