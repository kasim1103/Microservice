using MicroService.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroService
{
    class Program
    {
        static void Main(string[] args)
        {
            SupplierController supplier = new SupplierController();
            supplier.Suppliers();
        }
    }
}
