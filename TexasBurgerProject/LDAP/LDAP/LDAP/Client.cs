using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.DirectoryServices.Protocols;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDAP
{
    class Client
    {
        private static Client client1 = new Client();
        public DirectoryEntry CreateDirectoryEntry()
        {
            // create and return new LDAP connection with desired settings  
            DirectoryEntry ldapConnection = new DirectoryEntry("LDAP://Texasburger.local","administrator","Pass4dmiN!");
            return ldapConnection;
        }
        public SearchResult SearchAllFromOne(string username)
        {
            DirectorySearcher search = new DirectorySearcher(client1.CreateDirectoryEntry());
            search.Filter = "(samaccountname=" + username + ")";
            SearchResult result = search.FindOne();
            return result;
        }
    }  
}
