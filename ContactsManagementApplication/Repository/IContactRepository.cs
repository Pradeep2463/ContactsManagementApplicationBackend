using ContactsManagementApplication.Dto;
using ContactsManagementApplication.Models;

namespace ContactsManagementApplication.Repository
{
    public interface IContactRepository
    {
        List<ContactDto> GetAllContacts();
        Contact GetContactById(int id);
        void AddContact(Contact contact);
        void UpdateContact(Contact contact);
        void DeleteContact(int id);
        List<Contact> SearchContacts(string query);
        List<Contact> GetSortedContacts(string orderBy, bool ascending);
        (List<Contact> data, bool hasNext) GetPaginatedContacts(int page, int pageSize);
    }
}
