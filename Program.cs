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
     public class Restaurant
    {
        private List<Table> tables = new List<Table>();
        private string filePath = "tables.txt";

        public Restaurant()
        {
            LoadTablesFromFile();
        }

        private void LoadTablesFromFile()
        {
            if (File.Exists(filePath))
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        var parts = line.Split(',');
                        var table = new Table
                        {
                            TableId = int.Parse(parts[0]),
                            Capacity = int.Parse(parts[1]),
                            IsReserved = bool.Parse(parts[2]),
                            ReservationName = parts.Length > 3 ? parts[3] : string.Empty
                        };
                        tables.Add(table);
                    }
                }
            }
        }
           private void SaveTablesToFile()
 {
     using (StreamWriter sw = new StreamWriter(filePath))
     {
         foreach (var table in tables)
         {
             sw.WriteLine($"{table.TableId},{table.Capacity},{table.IsReserved},{table.ReservationName}");
         }
     }
 }
     public void AddNewTable()
 {
     Console.Write("Напишете номер на маса: ");
     int id = int.Parse(Console.ReadLine());
     Console.Write("Напишете капацитет на маса: ");
     int capacity = int.Parse(Console.ReadLine());

     var table = new Table { TableId = id, Capacity = capacity, IsReserved = false, ReservationName = string.Empty };
     tables.Add(table);
     SaveTablesToFile();
     Console.WriteLine("Масата е добавена успешно.");
  }
         	    
 public void ReserveTable()
        {
            Console.Write("Напишете номер на маса за резервация: ");
            int id = int.Parse(Console.ReadLine());
            var table = tables.FirstOrDefault(t => t.TableId == id);
            if (table != null && !table.IsReserved)
            {
                Console.Write("Напишете двете си имена: ");
                table.ReservationName = Console.ReadLine();
                table.IsReserved = true;
                SaveTablesToFile();
                Console.WriteLine("Масата е резервирана успешно.");
            }
            else
            {
                Console.WriteLine("Масата не е намерена или вече е резервирана.");
            }
     }
        public void CancelReservation()
 {
     Console.Write("Напишете номера на масата, която искате да откажете: ");
     int id = int.Parse(Console.ReadLine());
     var table = tables.FirstOrDefault(t => t.TableId == id);
     if (table != null && table.IsReserved)
     {
         table.IsReserved = false;
         table.ReservationName = string.Empty;
         SaveTablesToFile();
         Console.WriteLine("Резервацията е отказана успешно.");
     }
     else
     {
         Console.WriteLine("Масата не е намерена или не е резервирана.");
     }
 }  
         public void ListAllTables()
{
    Console.WriteLine("Всички маси:");
    foreach (var table in tables)
    {
        Console.WriteLine($"Номер на маса: {table.TableId}, Капацитет: {table.Capacity}, Резервация: {table.IsReserved}, Име: {table.ReservationName}");
    }
}
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
       private static void AddLine(int count = 1)
 {
     for (int i = 0; i < count; i++)
     {
         Console.WriteLine(Environment.NewLine);
     }
 }
    }
}
