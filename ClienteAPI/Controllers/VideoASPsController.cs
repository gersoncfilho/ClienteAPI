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
    public class VideoASPsController : ApiController
    {
        private ClienteContext db = new ClienteContext();

        // GET: api/VideoASPs
        public IQueryable<VideoASP> GetVideosASP()
        {
            return db.VideosASP;
        }

        // GET: api/VideoASPs/5
        [ResponseType(typeof(VideoASP))]
        public IHttpActionResult GetVideoASP(int id)
        {
            VideoASP videoASP = db.VideosASP.Find(id);
            if (videoASP == null)
            {
                return NotFound();
            }

            return Ok(videoASP);
        }

        // PUT: api/VideoASPs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVideoASP(int id, VideoASP videoASP)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != videoASP.IdVideo)
            {
                return BadRequest();
            }

            db.Entry(videoASP).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VideoASPExists(id))
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

        // POST: api/VideoASPs
        [ResponseType(typeof(VideoASP))]
        public IHttpActionResult PostVideoASP(VideoASP videoASP)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.VideosASP.Add(videoASP);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = videoASP.IdVideo }, videoASP);
        }

        // DELETE: api/VideoASPs/5
        [ResponseType(typeof(VideoASP))]
        public IHttpActionResult DeleteVideoASP(int id)
        {
            VideoASP videoASP = db.VideosASP.Find(id);
            if (videoASP == null)
            {
                return NotFound();
            }

            db.VideosASP.Remove(videoASP);
            db.SaveChanges();

            return Ok(videoASP);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VideoASPExists(int id)
        {
            return db.VideosASP.Count(e => e.IdVideo == id) > 0;
        }
    }
}