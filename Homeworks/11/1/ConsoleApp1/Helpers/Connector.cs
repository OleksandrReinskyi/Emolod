using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers
{
    public class Connector
    {
        public string server;
        public string port;
        public string database;
        public string user;
        public string password;
        public Connector(string server, string port, string database, string user, string password)
        {
            this.server = server;
            this.port = port;
            this.database = database;
            this.user = user;
            this.password = password;
        }
    }
}
