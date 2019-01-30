using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicroService.DataAccess.Model;
using MicroService.DataAccess.Param;

namespace MicroService.Common.Interfaces.Master
{
    public class SupplierRepository : ISupplierRepository
    {
        bool status = false;
        MyContext _context = new MyContext();
        Suppliers supplier = new Suppliers();
        public bool Delete(int? id)
        {
            var result = 0;
            var supplier = Get(id);
            try
            {
                supplier.IsDelete = true;
                supplier.DeleteDate = DateTimeOffset.Now.LocalDateTime;
                result = _context.SaveChanges();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            if (result > 0)
            {
                status = true;
            }
            return status;
        }

        public List<Suppliers> Get()
        {
            return _context.Suppliers.Where(x => x.IsDelete == false).ToList();
        }

        public Suppliers Get(int? id)
        {
            return _context.Suppliers.Where(x => x.id == id && x.IsDelete == false).SingleOrDefault();
        }

        public bool Insert(SupplierParam supplierParam)
        {
            var result = 0;
            supplier.Nama = supplierParam.Name;
            supplier.JoinDate = DateTimeOffset.Now.LocalDateTime;
            supplier.CreateDate = DateTimeOffset.Now.LocalDateTime;
            _context.Suppliers.Add(supplier);
            result = _context.SaveChanges();
            
            if(result == 0)
            {
                status = true;
            }
                return status;
        }

        public bool Update(int? id, SupplierParam supplierParam)
        {
            var result = 0;
            Suppliers supplier = Get(id);
            supplier.Nama = supplierParam.Name;
            supplier.UpdateDate = DateTimeOffset.Now.LocalDateTime;
            result = _context.SaveChanges();
            if(result > 0)
            {
                status = true;
                Console.WriteLine("Insert Succesfully");
            }

            return status;
        }
    }
}