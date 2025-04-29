using ApiProjectCamp.WebApi.Context;
using ApiProjectCamp.WebApi.Dtos.ContactDtos;
using ApiProjectCamp.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjectCamp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly ApiContext _context;

        public ContactsController(ApiContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult ContacList ()
        {
            var values = _context.Contacts.ToList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateContact(CreateContactDto createContactDto)//mapleme işlemi
        {
            Contact contact = new Contact();
            contact.Eamil = createContactDto.Eamil;
            contact.Adress = createContactDto.Adress;
            contact.PhoneNumber = createContactDto.PhoneNumber;
            contact.MapLocation = createContactDto.MapLocation;
            contact.OpenHours = createContactDto.OpenHours;
            _context.Contacts.Add(contact);
            _context.SaveChanges();
            return Ok("Ekleme İşlemi Başarılı");
        }
        [HttpDelete]
        public IActionResult DeleteContact(int id)
        {
            var value = _context.Contacts.Find(id);
            _context.Contacts.Remove(value);
            _context.SaveChanges();
            return Ok("Silme İşlemi Başarılı");
        }
        [HttpGet("GetContact")]
        public IActionResult GetContact(int id)
        {
            var value = _context.Contacts.Find(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateContact(UpdateContactDto updateContactDto)
        {
            Contact contact = new Contact();
            contact.Eamil = updateContactDto.Eamil;
            contact.Adress = updateContactDto.Adress;
            contact.PhoneNumber = updateContactDto.PhoneNumber;
            contact.MapLocation = updateContactDto.MapLocation;
            contact.OpenHours = updateContactDto.OpenHours;
            contact.ContactId = updateContactDto.ContactId;
            _context.Contacts.Update(contact);
            _context.SaveChanges();
            return Ok("Güncelleme İşlemi Başarılı");
        }
    }
}
