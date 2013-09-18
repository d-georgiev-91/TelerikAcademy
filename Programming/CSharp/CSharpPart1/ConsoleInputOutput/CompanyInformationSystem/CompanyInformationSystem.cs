using System;

class CompanyInformationSystem
{
    static void Main()
    {
        string companyName, companyAddress, companyWebSite, managerFirstName, managerLastName;
        byte managerAge;
        int companyPhoneNumber, faxNumber, managerPhoneNumber;
        Console.Write("Input company name: ");
        companyName = Console.ReadLine();
        Console.Write("Input company addres: ");
        companyAddress = Console.ReadLine();
        Console.Write("Input company phone number: ");
        companyPhoneNumber = int.Parse(Console.ReadLine());
        Console.Write("Input company fax number: ");
        faxNumber = int.Parse(Console.ReadLine());
        Console.Write("Input company website: ");
        companyWebSite = Console.ReadLine();
        Console.Write("Input manager first name: ");
        managerFirstName = Console.ReadLine();
        Console.Write("Input manager last name: ");
        managerLastName = Console.ReadLine();
        Console.Write("Input manager age: ");
        managerAge = byte.Parse(Console.ReadLine());
        Console.Write("Input manager phone number: ");
        managerPhoneNumber = int.Parse(Console.ReadLine());
        Console.WriteLine("The name of the company is {0}", companyName);
        Console.WriteLine("The addres of the company is {0}", companyAddress);
        Console.WriteLine("The phone of the company is {0: +359-##-###-###}", companyPhoneNumber);
        Console.WriteLine("The fax number of the company is {0: +359 ###-#######}", faxNumber);
        Console.WriteLine("The company website is {0} ", companyWebSite);
        Console.WriteLine("The manager name is {0} {1}. He is {2} years old.\n His phone number is {3: +359-##-###-###}", managerFirstName, managerLastName, managerAge, managerPhoneNumber);
    }
}