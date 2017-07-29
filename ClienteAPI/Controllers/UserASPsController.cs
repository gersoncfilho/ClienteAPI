using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ClienteAPI.Models;

namespace ClienteAPI.Controllers
{
    public class UserAspsController : ApiController
    {
        private ClienteContext db = new ClienteContext();

        // GET: api/UserAsps
        public IQueryable<UserAsp> GetUsersASP()
        {
            return db.UsersASP;
        }

        [ResponseType(typeof(UserAsp))]
        [Route("api/UsersASP/login")]
        public IHttpActionResult DoLogin(string username, string password)
        {
            UserAsp user;
            try
            {
                user = db.UsersASP.Single(correctUser => (correctUser.Username == username && correctUser.Password == password));
            }
            catch (Exception ex)
            {
                return NotFound();
            }



            return Ok(user);
        }

        // GET: api/UserAsps/5
        [ResponseType(typeof(UserAsp))]
        public IHttpActionResult GetUserAsp(int id)
        {
            UserAsp UserAsp = db.UsersASP.Find(id);
            if (UserAsp == null)
            {
                return NotFound();
            }

            return Ok(UserAsp);
        }

        // PUT: api/UserAsps/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUserAsp(int id, UserAsp UserAsp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != UserAsp.IdUser)
            {
                return BadRequest();
            }

            db.Entry(UserAsp).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserAspExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/UserAsps
        [ResponseType(typeof(UserAsp))]
        public IHttpActionResult PostUserAsp(UserAsp UserAsp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.UsersASP.Add(UserAsp);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = UserAsp.IdUser }, UserAsp);
        }

        // DELETE: api/UserAsps/5
        [ResponseType(typeof(UserAsp))]
        public IHttpActionResult DeleteUserAsp(int id)
        {
            UserAsp UserAsp = db.UsersASP.Find(id);
            if (UserAsp == null)
            {
                return NotFound();
            }

            db.UsersASP.Remove(UserAsp);
            db.SaveChanges();

            return Ok(UserAsp);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserAspExists(int id)
        {
            return db.UsersASP.Count(e => e.IdUser == id) > 0;
        }
    }
}