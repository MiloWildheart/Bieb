# Bieb Application

The Bieb Application is a WPF (Windows Presentation Foundation) desktop application that allows users to manage a collection of books and their authors. It provides features such as adding, editing, and deleting books and authors, as well as viewing and searching the collection.

## Features

- View a list of books and their authors
- Add a new book with its associated authors
- Edit the details of an existing book
- Delete a book from the collection
- View a list of authors and their associated books
- Add a new author with their associated books
- Edit the details of an existing author
- Delete an author from the collection
- Search for books by title or authors by name

## Technologies Used

- C# language for application logic
- WPF (Windows Presentation Foundation) for the desktop application framework
- Entity Framework Core for data access and ORM (Object-Relational Mapping)
- Microsoft SQL Server for the database
- MVVM (Model-View-ViewModel) architectural pattern for separation of concerns
- CommunityToolkit.Mvvm package for MVVM infrastructure
- RelayCommand and DelegateCommand for handling user commands
- Microsoft.EntityFrameworkCore package for Entity Framework Core integration

## Getting Started

### Prerequisites

- Visual Studio 2019 or later
- .NET Core 3.1 or later
- Microsoft SQL Server

### Installation

1. Clone the repository: `git clone https://github.com/your-username/bieb-application.git`
2. Open the solution file (`bieb-application.sln`) in Visual Studio.
3. Set up the database connection string in the `BiebDbContext` class, located in the `Models` folder.
4. Build the solution to restore NuGet packages.
5. Run the application from Visual Studio.

## Usage

1. Upon launching the application, you will be presented with the main window that displays the list of books and authors.
2. To add a new book, click the "Add Book" button and enter the book details in the provided form. You can select authors from the available list or add new authors on the fly.
3. To edit a book, select a book from the list and click the "Edit" button. Modify the book details in the form and save the changes.
4. To delete a book, select a book from the list and click the "Delete" button. Confirm the deletion when prompted.
5. To add a new author, click the "Add Author" button and enter the author details in the provided form. You can assign books to the author by selecting them from the available list or add new books on the fly.
6. To edit an author, select an author from the list and click the "Edit" button. Modify the author details in the form and save the changes.
7. To delete an author, select an author from the list and click the "Delete" button. Confirm the deletion when prompted.
8. To search for books, enter a book title in the search bar at the top. The list will update to display matching results.
9. To search for authors, enter an author name in the search bar at the top. The list will update to display matching results.

## Contributing

Contributions to the Bieb Application are welcome! If you have any ideas, suggestions, or bug reports, please open an issue on the GitHub repository.

## License

The Bieb Application is open-source software licensed under the [MIT License](https://opensource.org/licenses/MIT).
