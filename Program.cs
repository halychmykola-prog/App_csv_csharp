using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
        }

        static void Inserisci(OrganizationSample[] record1, ref int index1, ref int insertindex, ref string insertId)
        {
            record1[index1].Index = insertindex;
            record1[index1].OrganizationId = insertId;
            index1++;
        }

        // 2. Visualizzazione dei file 
        static string Visualizza(OrganizationSample[] records, ref int dimensione)
        {
            string text;

            text = "Index" + "\t" + "OrganizationId" + "\n";
            for (int i = 0; i < dimensione; i++)
            {
                text += records[i].Index + "\t" + records[i].OrganizationId + "\n";
            }

            return text;

        }

        // Ricerca di index
        static int Cerca(OrganizationSample[] records, ref int dimensione, ref int searchIndex)
        {
            int result = -1; // se non trovato ritorna -1
            for(int i = 0; i < dimensione; i++)
            {
                if (records[i].Index == searchIndex)
                {
                    result = i; // ritorna l'indice del record trovato
                    break;
                }
            }


            return result;

        }

        // 3. Modifica di un record
        static void Modifica(OrganizationSample[] records, ref int dimensione, ref int searchIndex, string newOrganizationId, int newIndex)
        {
            int result = Program.Cerca(records, ref dimensione, ref searchIndex);
            if(result != -1)
            {
                
                records[result].Index = newIndex;
                records[result].OrganizationId = newOrganizationId;
                
            }
            


        }

        // 4. Cancellazione di un record
        static void Cancella(OrganizationSample[] records, ref int dimensione, ref int searchIndex)
        {
            int result = Program.Cerca(records, ref dimensione, ref searchIndex);
            

            if (result != -1)
            {
                if (records[result+1].OrganizationId == null)
                {
                    records[result].Index = -1;
                    records[result].OrganizationId = null;
                   
                }
                else
                {
                    for(int i = result; i < dimensione - 1; i++)
                    {
                        records[i] = records[i + 1];
                    }
                    dimensione--;
                    
                }


            }
            
            
        }



        static void Main(string[] args)
        {
            bool esegui = true;
            int choice;// Variable to store the user's choice
            OrganizationSample[] records = new OrganizationSample[5]; // Array to store records
            int dimensione = 0;
            

            while (esegui)
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Insert record");
                Console.WriteLine("2. View records");
                Console.WriteLine("3. Modify record");
                Console.WriteLine("4. Delete record");
                Console.WriteLine("5. Exit");
                Console.WriteLine("");
                choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
               
                
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Function Inserimento Started");
                        Console.WriteLine("Inserisci index");
                        int insertindex = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("");

                        string insertId;
                        Console.WriteLine("Inserisci OrganizationId");
                        insertId = Console.ReadLine();

                        Program.Inserisci(records, ref dimensione, ref insertindex, ref insertId);
                        Console.WriteLine("Function Inserimento Ended");
                        Console.WriteLine("");
                        break;



                    case 2:
                        Console.WriteLine(Program.Visualizza(records, ref dimensione));
                        break;


                    case 3:
                        int changeindex;
                        Console.WriteLine("inserisci index del record da modificare:");
                        changeindex = Convert.ToInt32(Console.ReadLine());
                        int tofindex = Program.Cerca(records, ref dimensione, ref changeindex);
                        int newIndex;
                        Console.WriteLine("inserisci nuovo index:");
                        newIndex = Convert.ToInt32(Console.ReadLine());
                        string newOrganizationId1;
                        Console.WriteLine("inserisci nuovo OrganizationId:");
                        newOrganizationId1 = Console.ReadLine();
                        

                        Program.Modifica(records, ref dimensione, ref changeindex, newOrganizationId1, newIndex);
                        Console.WriteLine("");
                        Console.WriteLine("case 3 ended");



                        break;



                    case 4:
                        int deleteindex;
                        Console.WriteLine("inserisci index del record da cancellare:");
                        deleteindex = Convert.ToInt32(Console.ReadLine());
                        Program.Cancella(records, ref dimensione, ref deleteindex);
                        Console.WriteLine("");



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
