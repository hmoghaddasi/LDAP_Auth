using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Novell.Directory.Ldap;


namespace TestLDAPAuth
{

    public class LdapAuthentication
    {
   
        public bool Authenticate(string userName, string password)
        {
            var connection = new LdapConnection();
            try
            {
                string server = "server";
                string dn = $"prefix\\{userName}";

                connection.Connect(server, LdapConnection.DEFAULT_PORT);
                connection.SecureSocketLayer = false;
                connection.Bind(dn, password);

                bool isAuthenticated = connection.Bound;

                connection.Disconnect();
                
                return isAuthenticated;
            }
            catch (LdapException ex)
            {
                connection.Disconnect();
                // Handle specific LDAP exceptions
                throw new Exception($"LDAP Exception: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                connection.Disconnect();
                // Handle other exceptions
                throw new Exception($"An error occurred: {ex.Message}", ex);
            }
        }
    }
}
