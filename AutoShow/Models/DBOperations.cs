using DAL.Entity;
using DAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoShow.Models
{
    public class DBOperations
    {
        private DBContext db;
        public DBOperations()
        {
            db = new DBContext();
        }

        public List<AutoModel> GetAllCars()
        {
            return db.Automobile.ToList().Select(i => new AutoModel(i)).ToList();
        }

        public List<ClientModel> GetAllClients()
        {
            return db.Client.ToList().Select(i => new ClientModel(i)).ToList();
        }

        public List<EmployeeModel> GetAllEmps()
        {
            return db.Employee.ToList().Select(i => new EmployeeModel(i)).ToList().OrderBy(i => i).ToList();
        }

        public List<PurchModel> GetAllPurchs()
        {
            return db.Purchase.ToList().Select(i => new PurchModel(i)).ToList().OrderBy(i => i).ToList();
        }

        public AutoModel GetAuto(int Id)
        {
            return new AutoModel(db.Automobile.Find(Id));
        }

        
        public bool Save()
        {
            if (db.SaveChanges() > 0) return true;
            return false;
        }
    }
}
