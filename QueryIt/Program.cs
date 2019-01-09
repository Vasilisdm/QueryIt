using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryIt
{
    class Program
    {
        static void Main(string[] args)
        {

            Database.SetInitializer(new DropCreateDatabaseAlways<EmployeeDb>());
        }
    }
}
