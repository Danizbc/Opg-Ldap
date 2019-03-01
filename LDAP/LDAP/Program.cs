using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDAP
{
    class Program
    {
        static void Main(string[] args)
        {
            string WrongInput = "Wrong Input Try again.\n\nPress any key to continue.";

            string EnterNaL = "Enter first name and last name.\nWrite : ";

            string MenuOption = "  Options Menu  \n\nPress [1] to create user(not working yet).\n\nPress [2] Get user information.";

            string Failed = "Something went wrong please press enter to try again..\nOr contact system administrator.";

            string PressAny = "Press any key to continue";

            string loginText = "Login to your adminstrator account.\nWrite name : ";

            string loginPassword = "Password : ";

            bool runMeWhileTrue = true;

            Logic l = new Logic();


            while (runMeWhileTrue == true)
            {
                l.LoginPassword = null;
                l.LoginName = null;

                Console.Clear();
                Console.Write(loginText);
                l.LoginName = Console.ReadLine();
                Console.Clear();
                Console.Write(loginPassword);
                do
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    // Backspace Should Not Work
                    if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                    {
                        l.LoginPassword += key.KeyChar;
                        Console.Write("*");
                    }
                    else
                    {
                        if (key.Key == ConsoleKey.Backspace && l.LoginPassword.Length > 0)
                        {
                            l.LoginPassword = l.LoginPassword.Substring(0, (l.LoginPassword.Length - 1));
                            Console.Write("\b \b");
                        }
                        else if (key.Key == ConsoleKey.Enter)
                        {
                            break;
                        }
                    }
                } while (true);

                if (l.Loggin(l.LoginName, l.LoginPassword) == true)
                {
                    runMeWhileTrue = false;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Wrong login information.\nPress any key to try again..");
                    Console.ReadKey();
                }
            }


            while (l.TrueOrFalse == true)
            {
                Console.Clear();

                Console.WriteLine(MenuOption);

                ConsoleKeyInfo input = Console.ReadKey();

                Console.Clear();

                switch (char.ToLower(input.KeyChar))
                {
                    case '1':

                        Console.ReadKey();

                        break;

                    case '2':

                       

                        Console.Clear();
                        Console.Write("\n" + EnterNaL);

                        if (l.LdapConnect() == "Working")
                        {

                            for (int i = 0; i < l.Information.Count; i++)
                            {
                                Console.WriteLine(l.Information[i]);
                            }
                            Console.WriteLine(PressAny);
                        }
                        else
                        {
                            Console.WriteLine(Failed);
                        }

                        Console.ReadKey();
                        break;

                    default:
                        Console.WriteLine(WrongInput);
                        Console.ReadKey();
                        break;

                }
            }
        }


    }
}
