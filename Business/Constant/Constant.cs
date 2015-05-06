using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public static class Constant
    {
        public static class DB
        {
            private static readonly string _connectionstring = ConfigurationManager.ConnectionStrings["TryCatchShopEntities"].ToString();

            public static string CONNECTIONSTRING
            {
                get { return _connectionstring; }
            }
        }
    }
}
