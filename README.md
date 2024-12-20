# ContactsManagementApplicationBackend

**Setup Instructions**

**Prerequisites** 
* .NET 8 SDK installed
* A text editor or IDE like Visual Studio or Visual Studio Code
* Postman or a similar tool to test API endpoints.

**Steps to Setup**
 * git clone https://github.com/Pradeep2463/ContactsManagementApplicationBackend
 * dotnet restore
 * dotnet build
 * dotnet run
   
**Starting the API:**
 * By default, the API will run on https://localhost:44356
   
**Testing the Endpoints**
 * GET /api/Contacts/GetAllContacts - Retrieve all contacts
 * GET /api/Contacts/GetContactById/{id} - Retrieve a contact by ID
 * POST /api/Contacts/AddContact - Add a new contact
 * PUT /api/Contacts/UpdateContact - Update an existing contact
 * DELETE /api/Contacts/DeleteContact/{id} - Delete a contact
 * GET /api/Contacts/Search - Searched results
 * GET /api/Contacts/Sort - Sorted results
 * GET /api/Contacts/Paginate - Paginated results
