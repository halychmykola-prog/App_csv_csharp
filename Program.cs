using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace App_csv
{
    internal class Program
    {
        struct OrganizationSample
        {
            public int Index;
            public string OrganizationId;
        }

        static void Inserisci(OrganizationSample[] record1, ref int index1, int insertindex,  string insertId)
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
            for (int i = 0; i < dimensione; i++)
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
            if (result != -1)
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
                if (records[result + 1].OrganizationId == null)
                {
                    records[result].Index = -1;
                    records[result].OrganizationId = null;

                }
                else
                {
                    for (int i = result; i < dimensione - 1; i++)
                    {
                        records[i] = records[i + 1];
                    }
                    dimensione--;

                }


            }


        }


        static int Somma(OrganizationSample[] records, ref int dimensione, ref int valore)
        {

            int result = 0;
            for (int i = 0; i < dimensione; i++)
            {
                if (records[i].Index >= valore)
                {
                    result += records[i].Index;
                }


            }
            return result;
        }





        static void LetturaFile(OrganizationSample[] records, ref int dimensione, string filename,ref bool check1)
        {
            if(File.Exists(filename))
            {

                //apro file e chiudo alla fine
                using (StreamReader sr = new StreamReader(filename))
                {
                    // leggo il file riga per riga
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        //se la riga è vuota, passo alla prossima
                        if (string.IsNullOrWhiteSpace(line))
                            continue;

                        //se l'array è pieno, esco dal ciclo
                        if (records != null && dimensione >= records.Length)
                        {
                            
                            break;
                        }

                        // divido la riga in due parti separate da una virgola
                        string[] parts = line.Split(',');
                        if (parts.Length == 2)
                        {
                            int index;
                            if (int.TryParse(parts[0], out index))
                            {
                                string organizationId = parts[1];
                                Program.Inserisci(records, ref dimensione, index, organizationId);
                            }
                        }
                    }



                }
                check1 = true;

            }
            else
            {
                check1 = false;
            }

        }


        static void ScritturaFile(OrganizationSample[] records, int dimensione, string filename, ref bool check2)
        {
            try
            {
                // apro file e chiudo alla fine
                using (StreamWriter sw = new StreamWriter(filename, false))
                {
                    

                    
                    for (int i = 0; i < dimensione; i++)
                    {
                        // vreazione della stringa 
                        string line = $"{records[i].Index};{records[i].OrganizationId}";

                        // metto la stringa nel file
                        sw.WriteLine(line);
                    }
                }

                check2 = true;
            }
            catch (Exception ex)
            {
                //Console.WriteLine($"errore in salvataggio file. Motivo: {ex.Message}");
                check2 = false;
            }

        }





        static void Main(string[] args)
        {
            bool esegui = true;
            int choice;// variabile per la scelta dell'utente
            OrganizationSample[] records = new OrganizationSample[5]; // Array to store records
            int dimensione = 0;


            while (esegui)
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Insert record");
                Console.WriteLine("2. View records");
                Console.WriteLine("3. Modify record");
                Console.WriteLine("4. Delete record");
                Console.WriteLine("5. Carica dati da file");
                Console.WriteLine("6. Salva dati in file");
                Console.WriteLine("7. Exit");
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

                        Program.Inserisci(records, ref dimensione,  insertindex,  insertId);
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
                        Console.WriteLine("inserisci path del file:");
                        string filepath = Console.ReadLine();
                        bool check = false;
                        Program.LetturaFile(records, ref dimensione, filepath, ref check);
                        if(check)
                        {
                            Console.WriteLine("Eseguito");
                        }
                        else
                        {
                            Console.WriteLine("Errore");
                        }
                        Console.WriteLine("");


                       break;


                    case 6:
                        Console.WriteLine("inserisci path del file:");
                        string filepath2 = Console.ReadLine();
                        bool check2 = false;
                        Program.ScritturaFile(records, dimensione, filepath2, ref check2);
                        if (check2)
                        {
                            Console.WriteLine("Eseguito");
                        }
                        else
                        {
                            Console.WriteLine("Errore");
                        }
                        Console.WriteLine("");
                        break;



                    case 7:
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