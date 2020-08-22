﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Lib.io.Models;
using Lib.io.Dtos;
using AutoMapper;

namespace Lib.io.Controllers.Api {
    public class MembersController : ApiController {

        private ApplicationDbContext _context;

        public MembersController() {
            _context = new ApplicationDbContext();
        }

        // GET: /api/members
        [HttpGet]
        public IEnumerable<MemberDto> GetMembers() {
            // Maps the Member to the MemberDto, and returns the reference to this method.
            return _context.Members
                .Include(m => m.MembershipType)
                .ToList()
                .Select(Mapper.Map<Member, MemberDto>);
        }

        // GET: /api/members/<id>
        [HttpGet]
        public IHttpActionResult GetMembers(int id) {
            var member = _context.Members.SingleOrDefault(m => m.Id == id);

            if (member == null)
                return NotFound();
            else
                return Ok(Mapper.Map<Member, MemberDto>(member));
        }

        // POST: /api/members
        [HttpPost]
        [Authorize(Roles = RoleName.CanManageMembers)]
        public IHttpActionResult CreateMember(MemberDto memberDto) {
            if (!ModelState.IsValid)
                return BadRequest();

            var member = Mapper.Map<MemberDto, Member>(memberDto);
            _context.Members.Add(member);
            _context.SaveChanges();
            // Id is generated by the database, add it to DTO and return it to client.
            memberDto.Id = member.Id;

            // Returns the URI (Unified Resource Identifier)
            return Created(new Uri(Request.RequestUri + "/" + member.Id), memberDto);
        }

        // PUT: /api/members/<id>
        [HttpPut]
        [Authorize(Roles = RoleName.CanManageMembers)]
        public void UpdateMember(int id, MemberDto memberDto) {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var memberInDb = _context.Members.Single(m => m.Id == id);
            if (memberInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            // Use second argument for the existing member in database.
            Mapper.Map<MemberDto, Member>(memberDto, memberInDb);

            _context.SaveChanges();
        }

        // DELETE: /apis/members/<id>
        [HttpDelete]
        [Authorize(Roles = RoleName.CanManageMembers)]
        public IHttpActionResult DeleteMember(int id) {

            var memberInDb = _context.Members.Single(m => m.Id == id);
            if (memberInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Members.Remove(memberInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
