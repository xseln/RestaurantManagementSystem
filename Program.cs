using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RestorantManagement
{
    public class Table
    {
        public int TableId { get; set; }
        public int Capacity { get; set; }
        public bool IsReserved { get; set; }
        public string ReservationName { get; set; }
    }
   
    class Program
    {
        static void Main(string[] args)
        {
while (true)
{
    Console.WriteLine("\nМЕНЮ");
    AddLine();
    Console.WriteLine("\tМоля изберете желаното действие:");
    AddLine();
    Console.WriteLine("1. Добавяне на нова маса");
    Console.WriteLine("2. Резервиране на маса");
    Console.WriteLine("3. Отказване на резервация");
    Console.WriteLine("4. Проверка на налични маси");
    Console.WriteLine("5. Справка за всички маси");
    Console.WriteLine("6. Изход");
    Console.Write("Вашият избор: ");

    var choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            restaurant.AddNewTable();
            break;
        case "2":
            restaurant.ReserveTable();
            break;
        case "3":
            restaurant.CancelReservation();
            break;
        case "4":
            restaurant.CheckAvailableTables();
            break;
        case "5":
            restaurant.ListAllTables();
            break;
        case "6":
            return;
        default:
           
            break;
    }


}
          
        }
      
    }
}
