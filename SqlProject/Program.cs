// See https://aka.ms/new-console-template for more information

using SqlProject;
using System.ComponentModel.Design;
class Program
{
static void Main(string [] args) {
    DataAccess dataAccess = new DataAccess();
string conString= "Data Source=SRV2\\PUPILS; Initial Catalog = Products_326023306; Integrated Security = True";
    string table="c";
    string action = "a";
    Console.WriteLine("Choose Categories or Products, c/p");
    table = Console.ReadLine();
    Console.WriteLine("What would you like to do, add rows or just see all rows? a/s ");
    action = Console.ReadLine();
    if (table=="p"&& action=="a")//add to products
    {
        Console.WriteLine("Start filling your store...");
        string c = "y";
        int res = 0;
        while (c == "y")
        {
            res += dataAccess.insertProduct(conString);
            Console.WriteLine("would you like to continue? y/n");
            c = Console.ReadLine();
        }
        Console.WriteLine(res + " rows affected successfully");
        Console.WriteLine("your amazing store :");
        dataAccess.readProducts(conString);
    }

    else  if(table=="p"&& action=="s")//see products
    {
        Console.WriteLine( "your amazing store :");
        dataAccess.readProducts(conString);
    }

    else if(table == "c" && action == "a")//add to categories
    {
        Console.WriteLine("Add categories...");
        string c = "y";
        int res = 0;
        while (c == "y")
        {
            res += dataAccess.insertCategory(conString);
            Console.WriteLine("would you like to continue? y/n");
            c = Console.ReadLine();
        }
        Console.WriteLine(res + " rows affected successfully");
        Console.WriteLine(" the categories in your amazing store :");
        dataAccess.readCategories(conString);
    }

    else if (table == "c" && action == "s")//see categories
    {
        Console.WriteLine(" the categories in your amazing store :");
        dataAccess.readCategories(conString);
    }
}
}
