using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //AddedTest();
            //BrandGetAllTest();
            //UpdatedTest();
            //JoinTest();

            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            rentalManager.Add(new Rental { CarId=1,CustomerId=1,RentDate=2018, ReturnDate=2018});
        }

        private static void JoinTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();
            if (result.Success==true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.BrandName + " " + car.ColorName + " " + car.ModelYear);
                }
            }
        }

        private static void UpdatedTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Update(new Car { ColorId = 2, BrandId = 3, Id = 6, DailyPrice = 25000, Description = "En az 2 günlük kiralanabilir.", ModelYear = 2008 });
        }

        private static void BrandGetAllTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            var result = brandManager.GetAll();
            if (true)
            {
                foreach (var brand in result.Data)
                {
                    Console.WriteLine(brand.BrandId);
                }
            }
            
        }

        private static void AddedTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(new Car { ColorId = 1, BrandId = 1, Id = 7, DailyPrice = 0, Description = "3 gün", ModelYear = 2008 });
        }
    }
}
