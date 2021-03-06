﻿using System;
using System.Text;
using System.DirectoryServices;
using System.IO;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Collections.Generic;

namespace LdapWin
{
    class Logic
    {
        //Attribute
        bool trueOrFalse = true;

        List<string> information = new List<string>();

        readonly string Failed = "Failed";

        readonly string working = "Working";

        //Properties
        public bool TrueOrFalse
        {
            get { return trueOrFalse; }
            set
            {
                trueOrFalse = value;
            }
        }

        public List<string> Information
        {
            get { return information; }
            set
            {
                information = value;
            }
        }

        public string LdapConnect(string Uname)
        {

            string username = Uname;

            try
            {
                // create LDAP connection object  

                //mLdapConnetion is our connection to AD if there is no result comming out
                ///Check for the right connection string
                DirectoryEntry myLdapConnection = createDirectoryEntry();

                // create search object which operates on LDAP connection object  
                // and set search object to only find the user specified  

                ///Search filter becomes what we typed at the start                
                DirectorySearcher search = new DirectorySearcher(myLdapConnection);
                search.Filter = "(cn=" + username + ")";

                // create results objects from search object  
                SearchResult result = search.FindOne();

                ///When result is found 
                if (result != null)
                {
                    // user exists, cycle through LDAP fields (cn, telephonenumber etc.)  

                    ResultPropertyCollection fields = result.Properties;

                    ///Searches for all results that have pur input inside?
                    foreach (string ldapField in fields.PropertyNames)
                    {
                        // cycle through objects in each field e.g. group membership  
                        // (for many fields there will only be one object such as name)  

                        foreach (object myCollection in fields[ldapField])
                            information.Add(string.Format("{0,-20} : {1}",
                                          ldapField, myCollection.ToString()));
                    }
                }
                ///If it cant find the user
                ///IT will not say this if connetion string is wrong
                else
                {
                    // user does not exist  

                    return Failed;
                }
            }

            catch (Exception e)
            {
                return e.ToString();
            }

            return working;
        }
        /// <summary>
        /// Connection for our AD
        /// </summary>
        static DirectoryEntry createDirectoryEntry()
        {
            // create and return new LDAP connection with desired settings  
            ///We dont need a path? 
            ///Try the one below if it doesnt work
            /// DirectoryEntry directoryEntry = new DirectoryEntry("LDAP://MMDA.DK"); 
            DirectoryEntry ldapConnection = new DirectoryEntry("LDAP://192.168.0.2");
            ///We only need a path if we want to be very specific in what OU we want to look for
            //ldapConnection.Path = "LDAP://OU=DomainUsers,DC=miljø,DC=dk,"; ///We are searching for it in miljømærkering
            ldapConnection.AuthenticationType = AuthenticationTypes.Secure; ///makes secure connetion?
            ldapConnection.Username = "administrator";
            ldapConnection.Password = "Proh12019";
            return ldapConnection;
            ///return directoryEntry
        }




    }



}

