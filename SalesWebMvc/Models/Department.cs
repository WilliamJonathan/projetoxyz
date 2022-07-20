using SalesWebMvc.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Models
{
    public class Department
    {

        private readonly SalesWebMvcContext _context;

        public int Id { get; set; }
        public string Name { get; set; }
        //um departamento possui varios vendedores
        public ICollection<Seller> Sellers { get; set; } = new List<Seller>();

        public Department()
        {
        }

        public Department(int id, string name)
        {
            Id = id;
            Name = name;
        }
        //adiona vendedor
        public void AddSeller(Seller seller)
        {
            Sellers.Add(seller);
        }
        //soma total de vendas do departamento
        public double TotalSales(DateTime initial, DateTime final)
        {
            //pega cada vendedor da lista e soma as vendas de acordo com o departamento
            return Sellers.Sum(Seller => Seller.TotalSales(initial, final));
        }

        public String DepartmentName(int id)
        {
            //return _context.Department.Where(d => d.Equals(id)).FirstOrDefault()?.Name;
            //return _context.Department.Select(x => x.Name).Where(d => d.Equals(id)).ToString();
            var ret = _context.Department.FirstOrDefault(obj => obj.Id == id);
            return ret.Name.ToString();
        }

    }
}
