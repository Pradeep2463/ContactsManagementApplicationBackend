using ContactsManagementApplication.Dto;
using ContactsManagementApplication.Models;
using System.Text.Json;

namespace ContactsManagementApplication.Repository
{
    public class ContactRepository : IContactRepository
    {
        private const string DataFilePath = "contacts.json";
        private List<Contact> _contacts;

        public ContactRepository()
        {
            if (File.Exists(DataFilePath))
            {
                var json = File.ReadAllText(DataFilePath);
                _contacts = JsonSerializer.Deserialize<List<Contact>>(json) ?? new List<Contact>();

            }
            else
            {
                _contacts = new List<Contact>();
            }
        }

        private void SaveChanges()
        {
            var json = JsonSerializer.Serialize(_contacts);
            File.WriteAllText(DataFilePath, json);
        }

        public List<ContactDto> GetAllContacts()
        {

            List<ContactDto> contacts = new List<ContactDto>();
            foreach (var cont in _contacts)
            {
                ContactDto contactDto = new ContactDto();
                contactDto.Id = cont.Id;
                contactDto.FirstName = cont.FirstName;
                contactDto.LastName = cont.LastName;
                contactDto.Email = cont.Email;
                contacts.Add(contactDto);
            }

            return contacts;
        }

        public Contact GetContactById(int id)
        {
            return _contacts.FirstOrDefault(c => c.Id == id);

        }

        public void AddContact(Contact contact)
        {
            if (_contacts.Any(c => c.Email.Equals(contact.Email, StringComparison.OrdinalIgnoreCase)))
            {
                throw new Exception("A contact with the same email already exists.");
            }

            if (contact.Id == null || contact.Id == 0)
            {
                contact.Id = _contacts.Count > 0 ? _contacts.Max(c => c.Id) + 1 : 1;
            }

            if (_contacts.Any(c => c.Id == contact.Id))
                throw new System.Exception("Contact with the same ID already exists.");

            _contacts.Add(contact);
            SaveChanges();
        }

        public void UpdateContact(Contact contact)
        {
            var existing = GetContactById(contact.Id);
            if (existing == null)
            {
                throw new System.Exception("Contact not found.");
            }
            existing.FirstName = contact.FirstName;
            existing.LastName = contact.LastName;
            existing.Email = contact.Email;
            SaveChanges();
        }

        public void DeleteContact(int id)
        {
            var existing = GetContactById(id);
            if (existing == null)
            {
                throw new System.Exception("Contact not deleted.");
            }
            _contacts.RemoveAll(c => c.Id == id);
            SaveChanges();
        }
        public List<Contact> SearchContacts(string query)
        {
            return _contacts.Where(c =>
                c.FirstName.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                c.LastName.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                c.Email.Contains(query, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public List<Contact> GetSortedContacts(string orderBy, bool ascending)
        {
            return orderBy.ToLower() switch
            {
                "firstname" => ascending ? _contacts.OrderBy(c => c.FirstName).ToList() : _contacts.OrderByDescending(c => c.FirstName).ToList(),
                "lastname" => ascending ? _contacts.OrderBy(c => c.LastName).ToList() : _contacts.OrderByDescending(c => c.LastName).ToList(),
                "email" => ascending ? _contacts.OrderBy(c => c.Email).ToList() : _contacts.OrderByDescending(c => c.Email).ToList(),
                _ => _contacts
            };
        }

        public (List<Contact> data, bool hasNext) GetPaginatedContacts(int page, int pageSize)
        {
            var skip = (page - 1) * pageSize;
            var pagedContacts = _contacts.Skip(skip).Take(pageSize).ToList();
            var hasNext = _contacts.Count > skip + pageSize;
            return (pagedContacts, hasNext);
        }
    }
}
