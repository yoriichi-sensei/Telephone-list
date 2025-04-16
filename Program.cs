# Telephone-list
Test project 

using System;
using System.Collections.Generic;

class Program
{
    static List<Contact> phoneBook = new List<Contact>();

    static void Main(string[] args)
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n--- دفترچه تلفن ---");
            Console.WriteLine("1. اضافه کردن مخاطب");
            Console.WriteLine("2. نمایش همه مخاطبین");
            Console.WriteLine("3. جستجو با نام");
            Console.WriteLine("4. حذف مخاطب");
            Console.WriteLine("5. خروج");
            Console.Write("انتخاب شما: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddContact();
                    break;
                case "2":
                    ShowAllContacts();
                    break;
                case "3":
                    SearchContact();
                    break;
                case "4":
                    DeleteContact();
                    break;
                case "5":
                    running = false;
                    break;
                default:
                    Console.WriteLine("گزینه نامعتبر!");
                    break;
            }
        }
    }

    static void AddContact()
    {
        Console.Write("نام: ");
        string name = Console.ReadLine();

        Console.Write("شماره تلفن: ");
        string phone = Console.ReadLine();

        phoneBook.Add(new Contact(name, phone));
        Console.WriteLine("مخاطب با موفقیت اضافه شد!");
    }

    static void ShowAllContacts()
    {
        if (phoneBook.Count == 0)
        {
            Console.WriteLine("دفترچه خالی است.");
            return;
        }

        Console.WriteLine("\n--- لیست مخاطبین ---");
        foreach (var contact in phoneBook)
        {
            Console.WriteLine($"نام: {contact.Name} | شماره: {contact.Phone}");
        }
    }

    static void SearchContact()
    {
        Console.Write("نام مخاطب برای جستجو: ");
        string name = Console.ReadLine();

        bool found = false;
        foreach (var contact in phoneBook)
        {
            if (contact.Name.ToLower().Contains(name.ToLower()))
            {
                Console.WriteLine($"نام: {contact.Name} | شماره: {contact.Phone}");
                found = true;
            }
        }

        if (!found)
        {
            Console.WriteLine("مخاطبی با این نام یافت نشد.");
        }
    }

    static void DeleteContact()
    {
        Console.Write("نام مخاطب برای حذف: ");
        string name = Console.ReadLine();

        var removed = phoneBook.RemoveAll(c => c.Name.ToLower() == name.ToLower());

        if (removed > 0)
        {
            Console.WriteLine("مخاطب حذف شد.");
        }
        else
        {
            Console.WriteLine("مخاطب یافت نشد.");
        }
    }
}

class Contact
{
    public string Name { get; set; }
    public string Phone { get; set; }

    public Contact(string name, string phone)
    {
        Name = name;
        Phone = phone;
    }
}
