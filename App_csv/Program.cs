using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_csv
{
    internal class Program
    {
        struct OrganizationSample
        {
            public int Index;
            public string OrganizationId;
            public string Name;
            public string Website;
            public string Country;
            public string Description;
            public int Founded;
            public string Industry;
            public string NumberOfEmployees;

        }

        static void Inserisci()
        {
            
        }

        // 2. Visualizzazione dei file 
        static void Visualizza()
        {
            
        }

        // 3. Modifica di un record
        static void Modifica()
        {
            
        }

        // 4. Cancellazione di un record
        static void Cancella()
        {
            
        }


        static void Main(string[] args)
        {
            bool esegui = true;
            int choice;// Variable to store the user's choice

            while (esegui)
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Insert record");
                Console.WriteLine("2. View records");
                Console.WriteLine("3. Modify record");
                Console.WriteLine("4. Delete record");
                Console.WriteLine("5. Exit");
                choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
               
                
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Function Inserimento");
                        break;
                    case 2:
                        Console.WriteLine("Function Visualizzazione");
                        break;
                    case 3:
                        Console.WriteLine("Function Modifica");
                        break;
                    case 4:
                        Console.WriteLine("Function Cancellazione");
                        break;
                    case 5:
                        esegui = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }








        }
    }
}
