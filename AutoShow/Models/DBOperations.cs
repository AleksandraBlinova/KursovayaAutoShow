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
            return db.Employee.ToList().Select(i => new EmployeeModel(i)).ToList();
        }

     
        public List<PurchModel> GetAllPurchs()
        {
            return db.Purchase.ToList().Select(i => new PurchModel(i)).ToList();
        }

        public List<CarModel> GetCars(int modelid, int color)
        {
            return db.Automobile.ToList().Select(a => new CarModel(a)).Where(i => i.ModelFK == modelid && i.ColorFK==color).ToList();
        }

        public AutoModel GetCar(int equip)
        {
            return db.Automobile.Join(db.Model, a => a.ModelFK, m => m.Id, (a, m) => a)
               .Join(db.VehicleEquip, a => a.ModelFK, b => b.Id, (a, b) => a)
               .Where(i => i.Model.VehicleEquip.FirstOrDefault().Id == equip)
               .Select(i => new AutoModel
               {
                  Id=i.Id,
                   Price = i.Price,
                   Availability = i.Availability,
                   ReleaseYear = i.ReleaseYear
               }).FirstOrDefault();
        }

        public ClientModel GetClient(int Id)
        {
            return new ClientModel(db.Client.Find(Id));
        }

        public EmployeeModel GetEmp(int Id)
        {
            return new EmployeeModel(db.Employee.Find(Id));
        }
        public VechTypeModel GetEqType(int Id)
        {
            return new VechTypeModel(db.VehicleEquip.Find(Id));
        }
        public List<BrandModel> GetBrands()
        {
            return db.Brand.ToList().Select(i => new BrandModel(i)).ToList();
        }

        public List<PayTypeModel> GetTypes()
        {
            return db.PayType.ToList().Select(i => new PayTypeModel(i)).ToList();
        }
        public List<AutoModel> GetModels(int brand)
        {
            return db.Automobile.Join(db.Model, a => a.ModelFK, m => m.Id, (a, m) => a)
                .Join(db.Brand, a => a.Model.BrandFK, b => b.Id, (a, b) => a)
                .Where(i => i.Model.Brand.Id == brand)
                .Select(i => new AutoModel
                {
               Id = i.Model.Id,
                Model = i.Model.Model1,
                Price=i.Price,
                Availability=i.Availability,
                ReleaseYear=i.ReleaseYear
                }).ToList().Distinct().ToList();
        }
        public List<ColorModel> GetColors(int model)
        {
            return db.Automobile.Join(db.Color, a => a.ColorFK, c => c.Id, (a, c) => a)
                .Join(db.Model, a => a.ModelFK, m => m.Id, (a, m) => a)
                .Where(i => i.ModelFK == model)
                .Select(i => new ColorModel
                {
                    Id = i.Color.Id,
                    Color1 = i.Color.Color1
                }).ToList();
        }
        public long GetPrice(int model, int color)
        {
            return db.Automobile.Join(db.Color, a => a.ColorFK, c => c.Id, (a, c) => a)
                .Join(db.Model, a => a.ModelFK, m => m.Id, (a, m) => a)
                .Where(i => i.ModelFK == model && i.ColorFK == color)
                .ToList().FirstOrDefault().Price;
        }
        public int GetYear(int model, int color)
        {
            return db.Automobile.Join(db.Color, a => a.ColorFK, c => c.Id, (a, c) => a)
                .Join(db.Model, a => a.ModelFK, m => m.Id, (a, m) => a)
                .Where(i => i.ModelFK == model && i.ColorFK == color)
                .ToList().FirstOrDefault().ReleaseYear;
        }
        public bool GetAvailability(int model, int color)
        {
            return db.Automobile.Join(db.Color, a => a.ColorFK, c => c.Id, (a, c) => a)
                .Join(db.Model, a => a.ModelFK, m => m.Id, (a, m) => a)
                .Where(i => i.ModelFK == model && i.ColorFK == color)
                .ToList().FirstOrDefault().Availability;
        }
        public List<VechTypeModel> GetVechType(int model)
        {
            return db.VehicleEquip.Join(db.Model, ve => ve.ModelFK, m => m.Id, (ve, m) => ve)
                .Where(i => i.ModelFK == model)
                .Select(i => new VechTypeModel
                {
                    Id = i.Id,
                    EquipType = i.EquipType,
                    HP = i.HP,
                    Speed = i.Speed
                }).ToList();
          
        }
        public PlantModel GetPlants(int model)
        {
            return db.Automobile.Join(db.Plant, a => a.PlantFK, p => p.Id, (a, p) => a)
                 .Join(db.Model, a => a.ModelFK, m => m.Id, (a, m) => a)
                .Where(i => i.ModelFK == model)
                .Select(i => new PlantModel
                {
                    Id = i.Plant.Id,
                    PlantName = i.Plant.PlantName
                }).FirstOrDefault();
        }


        public int CreatePurch(PurchModel purchModel, int carid, int clientid, int empid, int paytypeid, int vechtype)//создать покупку авто
        {
            Purchase purchase  = new Purchase();
            string date = purchModel.PurchDate;
            purchase.PurchDate = DateTime.Parse( date);
            purchase.PayTypeFK = paytypeid;
            purchase.TotalCost = purchModel.TotalCost;
            purchase.AutoFK = carid;
            purchase.ClientFK = clientid;
            purchase.EmpFK =empid;
            purchase.VechTypeFK= vechtype;
            db.Purchase.Add(purchase);
            
            Save();
            return (int)purchase.Id;
        }



        public bool Save()
        {
            if (db.SaveChanges() > 0) return true;
            return false;
        }
    }
}

