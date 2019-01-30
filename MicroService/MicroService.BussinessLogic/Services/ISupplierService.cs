using MicroService.DataAccess.Model;
using MicroService.DataAccess.Param;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroService.BussinessLogic.Services
{
    public interface ISupplierService
    {
        bool Insert(SupplierParam supplierParam);
        bool Update(int? id, SupplierParam supplierParam);
        bool Delete(int? id);
        List<Suppliers> Get();
        Suppliers Get(int? id);
    }
}
