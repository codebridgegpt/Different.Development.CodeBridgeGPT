using Microsoft.AspNetCore.Mvc;
using ContactApi.Data;
using ContactApi.Models;

namespace ContactApi.Controllers
{
    [Route("api/contact")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ContactController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult SaveContact([FromBody] Contact contact)
        {
            _context.Contacts.Add(contact);
            _context.SaveChanges();
            return Ok();
        }
    }
}