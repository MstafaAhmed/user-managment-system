//This program is coded by mostafa ahmed in 22/2/2025
using System;

class User
{
    public string Name { get; set; }
    public int Age { get; set; }
    public int ID { get; set; }
    public string Adress { get; set; }


    // Constructor to initialize user details
    public User(string name, int age, int iD, string adress)
    {
        Name = name;
        Age = age;
        ID = iD;
        Adress = adress;
    }
}

class UserManager
{
    // intialize an array that can contain 100 users
    private User[] users = new User[100]; 
    private int count = 0;  // a count to indicates the number of places that have users

    // Method to add a new user
    public void AddUser(string name, int age, int iD,string adress)
    {
        //check if user list has an empty place or not
        if (count < users.Length)
        {
            
            for (int i = 0; i < count; i++)
            {
                if (users[i].ID==iD)
                {
                    Console.WriteLine("This ID is already in use. Please choose a different one");
                    return;

                }
            }

                users[count] = new User(name, age,iD,adress);
            count++;  // Increment user count  (add the desired user)
            Console.WriteLine($"User {name} added successfully.");
        }           
        // the list is full
        else
        {
            Console.WriteLine("User list is full.");
        }
    }

    // Method to remove a user by his name
    public void RemoveUser(int id)
    {
        // check if list is emty or not
        if (count == 0)
        {
            Console.WriteLine("There is no user to remove ! user list is empty!");
            return; 
        }
        else 
        {
            for (int i = 0; i < count; i++)
            {
                if (users[i].ID == id)
                {
                    
                    users[i] = users[count - 1];            // Swap with last element
                    users[count - 1] = null;               // Clear last element
                    count--;        // number of user will be decresed

                    Console.WriteLine($"User {id} removed.");
                    return;
                }
            }
        }
        Console.WriteLine($"User {id} not found.");
    }

    // Method to dislay the users by name and age
    public void DisplayUsers()
    {
        Console.WriteLine("User List: ");
        if (count == 0) //Check if there are users
        {
            Console.WriteLine("No users available.");
        }
        else
        {
            for (int i = 0; i < count; i++) // Loop through avilable users
            {
                Console.WriteLine($"Name: {users[i].Name}, Adress: {users[i].Adress}, id: {users[i].ID}, Age: {users[i].Age}");
            }
        }
    }

    // Method to search for a user by name
    public void SearchUser(int id)
    {
        for (int i = 0; i < count; i++)
        {
            if (users[i].ID==(id))      // Check if name matches
            {
                Console.WriteLine($"User Found! Name: {users[i].Name}, Adress: {users[i].Adress}, id: {users[i].ID}, Age: {users[i].Age}");
                return;
            }
        }
        Console.WriteLine($"User {id} not found."); // If user not found
    }
}

class Program
{
    static void Main()
    {
        UserManager userManager = new UserManager();

        while (true)
        {
            Console.WriteLine("Welcome!!");
            Console.WriteLine("1. Add User");
            Console.WriteLine("2. Remove User");
            Console.WriteLine("3. Display All Users");
            Console.WriteLine("4. Search User");
            Console.WriteLine("5. Exit");
            Console.Write("Enter choice: ");

            string choice = Console.ReadLine();
            Console.Clear();  // Clear console for better readability


            switch (choice)
            {
                case "1":
                    Console.Write("Enter The Name: ");
                    string Name = Console.ReadLine();
                    Console.Write("Enter The adress: ");
                    string adress = Console.ReadLine();
                    Console.Write("Enter id: ");
                    int id = int.Parse(Console.ReadLine());
                    Console.Write("Enter Age: ");
                    int age = int.Parse(Console.ReadLine());
                    userManager.AddUser( Name, age, id, adress);
                    break;

                case "2":
                    Console.Write("Enter Id of user to Remove: ");
                    int removeId = int.Parse(Console.ReadLine());
                    userManager.RemoveUser(removeId);
                    break;

                case "3":
                    userManager.DisplayUsers();
                    break;

                case "4":
                    Console.Write("Enter ID to Search: ");
                    int searchId = int.Parse(Console.ReadLine());
                    userManager.SearchUser(searchId);
                    break;

                case "5":
                    return;

                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();  // Clear console for better readability

        }
    }
}
