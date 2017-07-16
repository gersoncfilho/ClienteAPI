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
    public class ProfileASPsController : ApiController
    {
        private ClienteContext db = new ClienteContext();

        // GET: api/ProfileASPs
        public IQueryable<ProfileASP> GetProfilesASP()
        {
            return db.ProfilesASP;
        }

        // GET: api/ProfileASPs/5
        [ResponseType(typeof(ProfileASP))]
        public IHttpActionResult GetProfileASP(int id)
        {
            ProfileASP profileASP = db.ProfilesASP.Find(id);
            if (profileASP == null)
            {
                return NotFound();
            }

            return Ok(profileASP);
        }

        // PUT: api/ProfileASPs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProfileASP(int id, ProfileASP profileASP)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != profileASP.IdProfile)
            {
                return BadRequest();
            }

            db.Entry(profileASP).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfileASPExists(id))
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

        // POST: api/ProfileASPs
        [ResponseType(typeof(ProfileASP))]
        public IHttpActionResult PostProfileASP(ProfileASP profileASP)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ProfilesASP.Add(profileASP);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = profileASP.IdProfile }, profileASP);
        }

        // DELETE: api/ProfileASPs/5
        [ResponseType(typeof(ProfileASP))]
        public IHttpActionResult DeleteProfileASP(int id)
        {
            ProfileASP profileASP = db.ProfilesASP.Find(id);
            if (profileASP == null)
            {
                return NotFound();
            }

            db.ProfilesASP.Remove(profileASP);
            db.SaveChanges();

            return Ok(profileASP);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProfileASPExists(int id)
        {
            return db.ProfilesASP.Count(e => e.IdProfile == id) > 0;
        }
    }
}