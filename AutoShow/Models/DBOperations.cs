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

        public List<OrderModel> GetAllOrders()
        {
            return db.Order.ToList().Select(i => new OrderModel(i)).ToList();
        }


        public List<ColorModel> GetAllColors()
        {
            return db.Color.ToList().Select(i => new ColorModel(i)).ToList();
        }

        public List<TransmissionModel> GetAllTransm()
        {
            return db.Transmission.ToList().Select(i => new TransmissionModel(i)).ToList();
        }


        public AutoModel GetCars(int carid)//order
        {
            return db.Automobile
                .Where(i => i.Id == carid)
                .Select(i => new AutoModel
                {
                    Id = i.Id,
                    Price = i.Price,
                    Availability = i.Availability,
                    ReleaseYear = i.ReleaseYear,
                    Brand=i.Model.Brand.Brand1,
                    Model=i.Model.Model1,
                    Color=i.Color.Color1,
                    Plant=i.Plant.PlantName,
                    Transm=i.Model.VehicleEquip.FirstOrDefault().Transmission.Transmission1
                }).FirstOrDefault();

        }

        public AutoModel GetCar(int equip)//purchase
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

        public PurchModel GetPurch(int Id)
        {
            return new PurchModel(db.Purchase.Find(Id));
        }

        public OrderModel GetOrder(int Id)
        {
            return new OrderModel(db.Order.Find(Id));
        }

        public EmployeeModel GetEmp(string EmpFCS)
        {
            return db.Employee.ToList().Select(a => new EmployeeModel(a)).Where(i => i.FCS == EmpFCS ).FirstOrDefault();
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

        public List<ExtraServModel> GetExtraServ()
        {
            return db.ExtraServ.ToList().Select(i => new ExtraServModel(i)).ToList();
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
            return db.Automobile
                .Join(db.Color, a => a.ColorFK, c => c.Id, (a, c) => a)
                .Join(db.Model, a => a.ModelFK, m => m.Id, (a, m) => a)
                .Where(i => i.ModelFK == model && i.ColorFK == color )
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
                    Speed = i.Speed,
                    TransmFK=i.TransmFK
                    
                }).ToList();
          
        }
        public List<TransmissionModel> GetSelTransm(int vechid, int modelid)// зависящие от типа компл типы трансмиссии и модели
        {
            return db.VehicleEquip
                .Join(db.Transmission, a => a.TransmFK, p => p.Id, (a, p) => a)
                .Where(i => i.ModelFK == modelid && i.Id==vechid)
                .Select(i => new TransmissionModel
                {
                   Id=i.Transmission.Id,
                   Transmission1=i.Transmission.Transmission1

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

        public List<PurchModel> GetReportPurch(DateTime selectedDate)// для отчета о выручке
        {
            return db.Purchase
                .Where(i => i.PurchDate==selectedDate)
                .Select(i => new PurchModel
                {
                    TotalCost=i.TotalCost

                }).ToList();
        }

       public List<OrderModel> GetReportOrder(DateTime selectedDate)// для отчета о выручке
        {
            return db.Order
                .Where(i => i.OrderDate==selectedDate)
               .Select(i => new OrderModel
               {
                   Cost=i.Cost

               }).ToList(); 
        }



        public int CreatePurch(PurchModel purchModel, int carid, int clientid, int empid, int paytypeid, int vechtype, int extraserv)//создать покупку авто
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
            purchase.ExtraSevFK = extraserv;
            db.Purchase.Add(purchase);
            
            Save();
            return (int)purchase.Id;
        }

        public int CreateOrder(OrderModel order, int carid, int clientid, int empid,  int vechtype, int paytype)//создать покупку авто
        {
            DAL.Entity.Order ord = new DAL.Entity.Order();
            string date = order.OrderDate;
            ord.OrderDate = DateTime.Parse(date);
            ord.Cost = order.Cost;
            ord.AutoFK = carid;
            ord.ClientFK = clientid;
            ord.EmpFK = empid;
            ord.VechTypeFK = vechtype;
            ord.PayTypeFK = paytype;
            db.Order.Add(ord);

            Save();
            return (int)ord.Id;
        }

        public int CreateAuto( int model, int color, int plant, int price, int release)//создать  авто (для заказа)
        {
           Automobile car = new Automobile();
            car.ModelFK = model;
            car.Availability = false;
            car.ColorFK =color;
            car.PlantFK = plant;
            car.Price = price;
            car.ReleaseYear = release;
            db.Automobile.Add(car);

            Save();
            return (int)car.Id;
        }

        public void UpdateAuto(AutoModel a)
        {
            Automobile auto = db.Automobile.Find(a.Id);
            auto.Availability = false;
            db.Entry(auto).State = System.Data.Entity.EntityState.Modified;
            Save();
        }

        public void ChangeAvail(AutoModel a)
        {
            Automobile auto = db.Automobile.Find(a.Id);

            if (auto.Availability==true)
            auto.Availability = false;
            else
            auto.Availability = true;
            db.Entry(auto).State = System.Data.Entity.EntityState.Modified;
            Save();
        }
        public bool Save()
        {
            if (db.SaveChanges() > 0) return true;
            return false;
        }
    }
}

