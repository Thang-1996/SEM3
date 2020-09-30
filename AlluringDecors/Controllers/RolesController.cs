﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using AlluringDecors.Models;

namespace AlluringDecors.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using AlluringDecors.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Role>("Roles");
    builder.EntitySet<Admin>("Admins"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class RolesController : ODataController
    {
        private AlluringDecorsEntities db = new AlluringDecorsEntities();

        // GET: odata/Roles
        [EnableQuery]
        public IQueryable<Role> GetRoles()
        {
            return db.Roles;
        }

        // GET: odata/Roles(5)
        [EnableQuery]
        public SingleResult<Role> GetRole([FromODataUri] int key)
        {
            return SingleResult.Create(db.Roles.Where(role => role.id == key));
        }

        // PUT: odata/Roles(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<Role> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Role role = db.Roles.Find(key);
            if (role == null)
            {
                return NotFound();
            }

            patch.Put(role);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoleExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(role);
        }

        // POST: odata/Roles
        public IHttpActionResult Post(Role role)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Roles.Add(role);
            db.SaveChanges();

            return Created(role);
        }

        // PATCH: odata/Roles(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Role> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Role role = db.Roles.Find(key);
            if (role == null)
            {
                return NotFound();
            }

            patch.Patch(role);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoleExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(role);
        }

        // DELETE: odata/Roles(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            Role role = db.Roles.Find(key);
            if (role == null)
            {
                return NotFound();
            }

            db.Roles.Remove(role);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/Roles(5)/Admins
        [EnableQuery]
        public IQueryable<Admin> GetAdmins([FromODataUri] int key)
        {
            return db.Roles.Where(m => m.id == key).SelectMany(m => m.Admins);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RoleExists(int key)
        {
            return db.Roles.Count(e => e.id == key) > 0;
        }
    }
}
