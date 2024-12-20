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
**Application Structure**

ContactsManagementAPI/
│
├── Controllers/
│   └── ContactsController.cs    # Handles API endpoints
│
├── Models/
│   └── Contact.cs               # Contact data model with validation attributes
│
├── Repositories/
│   └── ContactRepository.cs     # Handles CRUD operations for contacts
│
├── Middleware/
│   └── ErrorHandlingMiddleware.cs # Global error handling
│
├── contacts.json                # JSON file for data storage
│
├── Program.cs                   # Application entry point
│
└── README.md                    # Project documentation



