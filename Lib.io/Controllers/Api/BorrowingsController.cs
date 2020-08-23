using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Lib.io.Models;
using Lib.io.Dtos;
using AutoMapper;
using System.Data.Entity.Validation;

namespace Lib.io.Controllers.Api {
    public class BorrowingsController : ApiController {

        private ApplicationDbContext _context;

        public BorrowingsController() {
            _context = new ApplicationDbContext();
        }
        // GET: /api/borrowings
        [HttpGet]
        public IEnumerable<BorrowingDto> GetBorrowings() {
            // Maps the Borrowing to the BorrowingDto, and returns the reference to this method.
            // Eager Load Everything
            return _context.Borrowings
                .Include(b => b.Member)
                .Include(b => b.Member.MembershipType)
                .Include(b => b.Book)
                .Include(b => b.Book.Genre)
                .Where(b => b.HasReturned == false)
                .ToList()
                .Select(Mapper.Map<Borrowing, BorrowingDto>);
        }
        // GET: /api/allborrowings
        [HttpGet]
        [Route("allborrowings")]
        public IEnumerable<BorrowingDto> GetAllBorrowings() {
            // Maps the Borrowing to the BorrowingDto, and returns the reference to this method.
            // Eager Load Everything
            return _context.Borrowings
                .Include(b => b.Member)
                .Include(b => b.Member.MembershipType)
                .Include(b => b.Book)
                .Include(b => b.Book.Genre)
                .ToList()
                .Select(Mapper.Map<Borrowing, BorrowingDto>);
        }

        // GET: /api/borrowings/<id>
        [HttpGet]
        public IHttpActionResult GetBorrowings(int id) {
            var borrowing = _context.Borrowings.SingleOrDefault(m => m.Id == id);

            if (borrowing == null)
                return NotFound();
            else
                return Ok(Mapper.Map<Borrowing, NewBorrowingDto>(borrowing));
        }

        // POST: /api/borrowings
        [HttpPost]
        [Authorize(Roles = RoleName.CanManageBorrowings)]
        public IHttpActionResult CreateBorrowing(NewBorrowingDto newBorrowing) {

            if (!ModelState.IsValid)
                return BadRequest();

            var member = _context.Members.Single(m => m.Id == newBorrowing.MemberId);
            var books = _context.Books.Where(b => newBorrowing.BookIds.Contains(b.Id));

            foreach (var book in books) {
                var borrowing = new Borrowing { Member = member, Book = book, DateBorrowed = DateTime.Today, DateReturned = DateTime.Today, HasReturned = false };
                // If we have it in stock, add it as a borrowing, and reduce the number in stock
                if (book.NumberInStock > 0) {
                    _context.Borrowings.Add(borrowing);
                    book.NumberInStock--;
                }
            }

            _context.SaveChanges();

            return Ok();
        }

        // PUT: /api/borrowings/<id>
        [HttpPut]
        [Authorize(Roles = RoleName.CanManageBorrowings)]
        public void UpdateBorrowing(int id, BorrowingDto borrowingDto) {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var borrowingInDb = _context.Borrowings.Single(m => m.Id == id);
            if (borrowingInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            // Use second argument for the existing book in database.
            Mapper.Map<BorrowingDto, Borrowing>(borrowingDto, borrowingInDb);

            _context.SaveChanges();
        }

        // DELETE: /apis/borrowings/<id>
        [HttpDelete]
        [Authorize(Roles = RoleName.CanManageBorrowings)]
        public IHttpActionResult DeleteBorrowing(int id) {
            var borrowingInDb = _context.Borrowings.Single(m => m.Id == id);
            if (borrowingInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Borrowings.Remove(borrowingInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
