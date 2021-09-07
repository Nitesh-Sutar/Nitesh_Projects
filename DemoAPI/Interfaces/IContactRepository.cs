using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactAPI.Model;

namespace ContactAPI.Interfaces
{
    public interface IContactRepository
    {

        Contact GetContact(string contactID);

        Task<Contact> CreateContact(Contact contact);

        Task<Contact> DeleteContact(string ContactID);

        Task<Contact> UpateContact(Contact contact);

        Task<IList<Contact>> GetAllContacts();
    }
}
