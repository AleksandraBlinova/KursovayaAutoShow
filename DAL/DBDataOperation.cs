using DAL;
using DAL.Entity;
using DAL.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace DAL.Services
{
    public class DBDataOperation
    {
        private DBContext db;
        public DBDataOperation()
        {
            db = new DBContext();
            db.Automobile.Load();
            db.Client.Load();
            db.Employee.Load();
            db.Purchase.Load();
        }

        public List<AutoModel> GetAllAutomobiles()
        {
            return db.Automobile.ToList().Select(i => new AutoModel(i)).ToList();
        }
        public List<ClientModel> GetAllClients()
        {
            return db.Client.ToList().Select(i => new ClientModel(i)).ToList();
        }

        public List<EmployeeModel> GetEmployees()
        {
            return db.Employee.ToList().Select(i => new EmployeeModel(i)).ToList();
        }
        public List<PurchModel> GetPurches()
        {
            return db.Purchase.ToList().Select(i => new PurchModel(i)).ToList();
        }

    }
}
