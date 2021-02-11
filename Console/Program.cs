using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Concrete.Entity_Framework;
using Entities.Concrete;
using Entities.Dtos;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());

            //CarTest(carManager);
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            //BrandTest(brandManager);
            ColorManager colorManager = new ColorManager(new EfColorDal());
            //ColorTest(colorManager);

            DtoTest(carManager);

        }

        private static void DtoTest(CarManager carManager)
        {
            var result = carManager.GetCarDetails();
            if (result.Success == true)
            {
                foreach (CarDetailDto car in result.Data)
                {
                    Console.WriteLine(car.Description + " -  " + car.BrandName + " - " + car.ColorName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
            

        private static void ColorTest(ColorManager colorManager)
        {
            var result = colorManager.GetAll();
            
            foreach (Color color in result.Data)
            {
                Console.WriteLine(color.ColorId + "-" + color.ColorName);
            }

            var result1 = colorManager.GetById(1);
            Console.WriteLine(result1.Data.ColorName);

            
            
        }

        private static void BrandTest(BrandManager brandManager)
        {

            var result = brandManager.GetAll();
            Console.WriteLine("Tamamını listeleme");
            foreach (Brand brand1 in result.Data)
            {
                Console.WriteLine(brand1.BrandId + "-" + brand1.BrandName);
            }
            Console.WriteLine("Brand Id'ye göre listeleme");


            Console.WriteLine(brandManager.GetById(2));

            Brand newBrand = new Brand() { BrandName = "Renault" };
            brandManager.Add(newBrand);
            
        }

        private static void CarTest(CarManager carManager)
        {
            var result = carManager.GetAll();
            Console.WriteLine("Tamamını listeleme");
            foreach (Car car in result.Data)
            {
                Console.WriteLine(car.Id + " " + car.Description);
            }

            var result1 = carManager.GetAllByBrandId(1);

            Console.WriteLine("Brand Id'ye göre listeleme");
            foreach (Car car in result1.Data)
            {
                Console.WriteLine(car.Id + " " + car.Description);
            }

            var result2 = carManager.GetAllByColorId(1);
            Console.WriteLine("Color Id'ye göre listeleme");
            foreach (Car car in result.Data)
            {
                Console.WriteLine(car.Id + " " + car.Description);
            }

            Car car1 = new Car() { BrandId = 3, ColorId = 2, DailyPrice = 450, Description = "2020 Model Kırmızı Renk Wolksvagen", ModelYear = 2020 };
            carManager.Add(car1);
            Car car2 = new Car() { BrandId = 3, ColorId = 2, DailyPrice = 0, Description = "2020 Model Kırmızı Renk Wolksvagen", ModelYear = 2020 };
            carManager.Add(car2);
        }
    }
}
