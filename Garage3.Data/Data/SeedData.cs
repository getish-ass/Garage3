using Bogus;
using Garage3.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage3.Data.Data
{
    public class SeedData
    {

        private static Faker faker = null!;

        public static async Task InitAsync(Garage3Context db)
        {
            if (await db.Member.AnyAsync()) return;

            faker = new Faker("sv");


            var members = GetMembers();
            await db.AddRangeAsync(members);
            await db.SaveChangesAsync();

            var vehicleTypes = GetVehicleType();
            await db.AddRangeAsync(vehicleTypes);
            await db.SaveChangesAsync();

            var parkingLots = GetParkingLot();
            await db.AddRangeAsync(parkingLots);
            await db.SaveChangesAsync();

            var vehicles = GetVehicles(members, vehicleTypes, parkingLots);
            await db.AddRangeAsync(vehicles);


            await db.SaveChangesAsync();
        }





        private static IEnumerable<Vehicle> GetVehicles(List<Member> members, List<VehicleType> vehicleTypes, List<ParkingLot> parkingLots)
        {
            var vehicles = new List<Vehicle>();

            var spots = parkingLots.Count;
            var skip = 0;
            var take = 0;



            for (int i = 0; i < 20; i++)
            {
                if(skip >= spots - 3) continue;
                var type = vehicleTypes[faker.Random.Int(0, 2)];
                take = type.Size;


                var regNo = faker.Random.AlphaNumeric(6);
                var model = faker.Vehicle.Model();
                var brand = faker.Vehicle.Manufacturer();
                var color = faker.Commerce.Color();
                var noWheel = faker.Random.Int(1, 5);

                var vehicle = new Vehicle(regNo, model, brand, color, noWheel)
                {
                    Member = members[i],
                    VehicleType = type ,
                    ParkingLot = parkingLots.Skip(skip).Take(take).ToList()

                };

                skip += take;
                vehicles.Add(vehicle);

            }

            

            return vehicles;
        }





        private static List<VehicleType> GetVehicleType()
        {
            var vehicleTypes = new List<VehicleType>()
            {
                 new VehicleType(){ TypeName = "Car", Size= 1, TypeCode  = 1},
                 new VehicleType(){ TypeName = "Buss", Size= 3, TypeCode  = 1},
                 new VehicleType(){ TypeName = "Boat", Size= 3, TypeCode  = 1}
            };
            

            return vehicleTypes;
        }

        private static List<Member> GetMembers()
        {
            var members = new List<Member>();

            for (int i = 0; i < 20; i++)
            {
                var fName = faker.Name.FirstName();
                var lName = faker.Name.LastName();
                var personalNo = GeneratePersonalNumber();

                //var age = ComputeAge(personalNo);
                var age = faker.Random.Int(18, 100);

                var member = new Member(personalNo, age, new Name(fName, lName));


                members.Add(member);
            }
            return members;
        }


        private static List<ParkingLot> GetParkingLot()
        {
            var parkingLots = new List<ParkingLot>();

            for (int i = 0; i < 90; i++)
            {
                var parkingLot = new ParkingLot();

                parkingLots.Add(parkingLot);
            }

            return parkingLots;
        }






       

        public static int GetAge(DateTime dob)
        {
            int age = 0;
            age = DateTime.Now.Subtract(dob).Days;
            age = age / 365;
            return age;
        }







        private static string GeneratePersonalNumber()
        {
            var year = faker.Random.Int(-100, -1);

            var fourDigit = faker.Random.Int(1111, 9999);

            var dateOfBirth = DateTime.Now.AddYears(year).ToString("yyyy-MM-dd");

            dateOfBirth = dateOfBirth.Replace("-", string.Empty);

            string personalNo = $"{dateOfBirth}-{fourDigit}";

            return personalNo;
        }
















    }
}
