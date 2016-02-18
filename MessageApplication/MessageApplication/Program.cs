using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageApplication
{
    interface IStorable
    {
        void Create();
        void Load();
        void Menu();
    }

    class Messages : IStorable
    {
        SqlConnection conn = new SqlConnection("Server=tcp:contacstserver.database.windows.net,1433;Database=contactsdatabase;User ID=peter@contacstserver;Password=AzurePass123;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;");           

        public void Create()
        {
            conn.Open();
            Console.Clear();

            bool retry = true;

            while (retry == true)
            {
               
                    string text;

                    Console.Write("Skriv ett meddelande; ");
                    text = Console.ReadLine();

                    //Check if string is empty
                    if (string.IsNullOrEmpty(text))
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine("Du måste skriva ett meddelande");
                        Console.ResetColor();
                    }
                    else
                    {
                        retry = false;

                        //Insert value to database.
                        SqlCommand insertCommand = new SqlCommand("INSERT INTO [dbo].[ConsoleMessage] (Text, Tid) VALUES (@1, @2)", conn);

                        insertCommand.Parameters.Add(new SqlParameter("1", text));
                        insertCommand.Parameters.Add(new SqlParameter("2", DateTime.Now));

                        Console.WriteLine();
                        Console.WriteLine("Du har skapat " + insertCommand.ExecuteNonQuery() + " meddelande");
                        Console.WriteLine();
                        Console.WriteLine("Tryck på Enter för att skriva ett nytt meddelande eller R för att komma till menyn");

                        string command = Console.ReadLine();
                        if (command.ToUpper() == "R")
                        {
                            Console.Clear();
                            conn.Close();
                            Menu();
                        }
                        retry = true;
                        Console.Clear();
                    }                            
            }
        }

        public void Load()
        {
            conn.Open();
            Console.Clear();
            SqlCommand cmd = new SqlCommand("SELECT Text, Tid FROM [dbo].[ConsoleMessage]", conn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine("{0}, {1}", reader.GetString(0), reader.GetDateTime(1));
            }
            reader.Close();
            Console.WriteLine();
            Console.WriteLine("Tryck på R för att komma till menyn");

            string command = Console.ReadLine();
            if (command.ToUpper() == "R")
            {
                Console.Clear();
                conn.Close();
                Menu();
            }
           
        }

        public void Menu()
        {
            try
            {
                Console.WriteLine("Meddelandetjänst");
                Console.WriteLine();
                Console.WriteLine("1. Skriv ett meddelande");
                Console.WriteLine("2. Läs alla meddelanden");
                Console.WriteLine("3. Öppna webbsidan");
                Console.WriteLine("4. Exit");
                Console.WriteLine();
                byte result = byte.Parse(Console.ReadLine());

                //Create message
                if (result == 1)
                {
                    Create();
                }

                //Read messages.
                else if (result == 2)
                {
                    Load();
                }

                else if (result == 3)
                {
                    Console.Clear();
                    System.Diagnostics.Process.Start("http://viewconsolemessages.azurewebsites.net");
                    Menu();
                }

                //Close program.
                else if (result == 4)
                {
                    conn.Close();
                    Environment.Exit(0);
                }

                }
                catch
                {
                    Console.WriteLine("Du måste skriva ett nummer. tryck R för att börja om.");

                    string command = Console.ReadLine();
                    if (command.ToUpper() == "R")
                    {
                        Console.Clear();
                        Menu();
                    }
            }
 
        }     
    }

    class Program
    {      
        static void Main(string[] args)
        {

            Messages m = new Messages();
            
            m.Menu();

            if (Debugger.IsAttached)
            {
                Console.ReadLine();
            }

        }
    }
}
