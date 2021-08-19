using Contact.Api.Models.Repository;
using System.Collections.Generic;
using System.Linq;

namespace Contact.Api.Models.DataManager
{
    public class ContactManager : IDataRepository<Contact>
    {
        private readonly ContactContext _contactContext;

        public ContactManager(ContactContext context)
        {
            _contactContext = context;
        }

        public IEnumerable<Contact> GetAll()
        {
            return _contactContext.Contacts.ToList();
        }

        public Contact Get(long id)
        {
            return _contactContext.Contacts.FirstOrDefault(e => e.ContactId == id);
        }

        public void Add(Contact entity)
        {
            _contactContext.Contacts.Add(entity);
            _contactContext.SaveChanges();
        }

        public void Update(Contact contact, Contact entity)
        {
            contact.FirstName = entity.FirstName;
            contact.LastName = entity.LastName;
            contact.Email = entity.Email;
            contact.DateOfBirth = entity.DateOfBirth;

            _contactContext.SaveChanges();
        }

        public void Delete(Contact contact)
        {
            _contactContext.Contacts.Remove(contact);
            _contactContext.SaveChanges();
        }
    }
}