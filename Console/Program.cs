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

            //DtoTest(carManager);

        }

        private static void DtoTest(CarManager carManager)
        {
            foreach (CarDetailDto car in carManager.GetCarDetails())
            {
                Console.WriteLine(car.Description + " -  " + car.BrandName + " - " + car.ColorName);
            }
        }

        private static void ColorTest(ColorManager colorManager)
        {
            foreach (Color color in colorManager.GetAll())
            {
                Console.WriteLine(color.ColorId + "-" + color.ColorName);
            }

            Console.WriteLine(colorManager.GetById(1).ColorName);

            
            
        }

        private static void BrandTest(BrandManager brandManager)
        {
            
            Console.WriteLine("Tamamını listeleme");
            foreach (Brand brand1 in brandManager.GetAll())
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
            Console.WriteLine("Tamamını listeleme");
            foreach (Car car in carManager.GetAll())
            {
                Console.WriteLine(car.Id + " " + car.Description);
            }

            Console.WriteLine("Brand Id'ye göre listeleme");
            foreach (Car car in carManager.GetAllByBrandId(1))
            {
                Console.WriteLine(car.Id + " " + car.Description);
            }

            Console.WriteLine("Color Id'ye göre listeleme");
            foreach (Car car in carManager.GetAllByColorId(1))
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
