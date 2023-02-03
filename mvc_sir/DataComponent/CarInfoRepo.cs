using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleMvcApp.DataComponent
{
    public class CarInfoRepo : ICarInfoRepo
    {
        private readonly CarInfoDataContext _context = new CarInfoDataContext();
        public void AddNewCar(CARINFO info)
        {
            _context.CARINFOs.InsertOnSubmit(info);
            _context.SubmitChanges();

        }
        public List<CARINFO> GetAllCars() => _context.CARINFOs.ToList();

        public CARINFO FindCar(int id) => _context.CARINFOs.FirstOrDefault((c) => c.ENTRYID == id);

        public void UpdateCar(CARINFO carInfo)
        {
            var car = FindCar(carInfo.ENTRYID);
            Copy(car, carInfo);
            _context.SubmitChanges();
        }

        public void DeleteCar(int entryId)
        {
            var car = FindCar(entryId);
            _context.CARINFOs.DeleteOnSubmit(car);
            _context.SubmitChanges();
        }
        private void Copy(CARINFO current, CARINFO other)
        {
            current.BODYTYPE = other.BODYTYPE;
            current.BRANDNAME = other.BRANDNAME;
            current.CAPACITY = other.CAPACITY;
            current.ENGINE = other.ENGINE;
            current.FUELTYPE = other.FUELTYPE;
            current.MODEL = other.MODEL;
            current.PRICE = other.PRICE;
        }
    }
}