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


            Logic l = new Logic();

            while (l.TrueOrFalse == true)
            {
                Console.Clear();

                Console.WriteLine(MenuOption);

                ConsoleKeyInfo input = Console.ReadKey();

                Console.Clear();

                switch (char.ToLower(input.KeyChar))
                {
                    case '1':

                      
                        break;

                    case '2':
                        Console.Write(EnterNaL);
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
