using System.Collections.Generic;

namespace SampleMvcApp.DataComponent
{
    public interface ICarInfoRepo
    {
        void AddNewCar(CARINFO info);
        void DeleteCar(int entryId);
        CARINFO FindCar(int id);
        List<CARINFO> GetAllCars();
        void UpdateCar(CARINFO carInfo);
    }
}