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
    public class UserASPsController : ApiController
    {
        private ClienteContext db = new ClienteContext();

        // GET: api/UserASPs
        public IQueryable<UserASP> GetUsersASP()
        {
            return db.UsersASP;
        }

        // GET: api/UserASPs/5
        [ResponseType(typeof(UserASP))]
        public IHttpActionResult GetUserASP(int id)
        {
            UserASP userASP = db.UsersASP.Find(id);
            if (userASP == null)
            {
                return NotFound();
            }

            return Ok(userASP);
        }

        // PUT: api/UserASPs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUserASP(int id, UserASP userASP)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userASP.IdUser)
            {
                return BadRequest();
            }

            db.Entry(userASP).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserASPExists(id))
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

        // POST: api/UserASPs
        [ResponseType(typeof(UserASP))]
        public IHttpActionResult PostUserASP(UserASP userASP)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.UsersASP.Add(userASP);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = userASP.IdUser }, userASP);
        }

        // DELETE: api/UserASPs/5
        [ResponseType(typeof(UserASP))]
        public IHttpActionResult DeleteUserASP(int id)
        {
            UserASP userASP = db.UsersASP.Find(id);
            if (userASP == null)
            {
                return NotFound();
            }

            db.UsersASP.Remove(userASP);
            db.SaveChanges();

            return Ok(userASP);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserASPExists(int id)
        {
            return db.UsersASP.Count(e => e.IdUser == id) > 0;
        }
    }
}