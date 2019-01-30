using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicroService.DataAccess.Model;
using MicroService.DataAccess.Param;
using MicroService.Common.Interfaces;
using MicroService.Common.Interfaces.Master;

namespace MicroService.BussinessLogic.Services.Master
{
    public class SupplierService : ISupplierService
    {
        ISupplierRepository _supplierRepository = new SupplierRepository();
        MyContext _context = new MyContext();
        bool status = false;
        public bool Delete(int? id)
        {
            var getid = Get(id);
            var getsupplier = false;
            if (getid != null)
            {
                getsupplier = _supplierRepository.Delete(id);
                status = true;
            }
            return status;
        }

        public List<Suppliers> Get()
        {
            return _supplierRepository.Get();
        }


        public Suppliers Get(int? id)
        {
            if(id == null)
            {
                Console.WriteLine("Id Tidak Ada");
                Console.Read();
            }
            var getsupplier = _supplierRepository.Get(id);
            if(getsupplier == null)
            {
                Console.WriteLine("ID Tidak Ditemuksn");
                Console.Read();
            }
            return getsupplier;
        }

        public bool Insert(SupplierParam supplierParam)
        {

            _supplierRepository.Insert(supplierParam);
            return status = true;
        }

        public bool Update(int? id, SupplierParam supplierParam)
        {
            _supplierRepository.Update(id, supplierParam);
            return status = true;
        }
    }
}
