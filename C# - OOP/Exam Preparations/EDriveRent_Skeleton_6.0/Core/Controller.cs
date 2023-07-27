using EDriveRent.Core.Contracts;
using EDriveRent.Models;
using EDriveRent.Models.Contracts;
using EDriveRent.Repositories;
using EDriveRent.Repositories.Contracts;
using EDriveRent.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace EDriveRent.Core
{
    public class Controller : IController
    {
        private readonly IRepository<IUser> users;
        private readonly IRepository<IVehicle> vehicles;
        private readonly IRepository<IRoute> routes;

        public Controller()
        {
            users = new UserRepository();
            vehicles = new VehicleRepository();
            routes = new RouteRepository();
        }
        public string AllowRoute(string startPoint, string endPoint, double length)
        {
            int routeId = this.routes.GetAll().Count + 1;

            var route = this.routes
                .GetAll()
                .FirstOrDefault(r => r.StartPoint == startPoint && r.EndPoint == endPoint && r.Length == length) ;

            if (route != null)
            {
                return string.Format(OutputMessages.RouteExisting,startPoint, endPoint, routeId) ;
            }

            route = this.routes
                .GetAll()
                .FirstOrDefault(r => r.StartPoint == startPoint && r.EndPoint == endPoint && r.Length <length);

            if(route != null)
            {
                return string.Format(OutputMessages.RouteIsTooLong, startPoint, endPoint, routeId);
            }

            route = this.routes.GetAll().FirstOrDefault(r=> r.StartPoint == startPoint && r.EndPoint == endPoint && r.Length > length);

            if(route != null )
            {
                route.LockRoute();
            }

            Route newRoute = new(startPoint, endPoint, length, routeId) ;

            this.routes.AddModel(newRoute);

            return string.Format(OutputMessages.NewRouteAdded, startPoint, endPoint, length);

        }
        public string MakeTrip(string drivingLicenseNumber, string licensePlateNumber, string routeId, bool isAccidentHappened)
        {
            IUser user = this.users.FindById(drivingLicenseNumber);
            IVehicle vehicle = this.vehicles.FindById(licensePlateNumber);
            IRoute route = this.routes.FindById(routeId);

            if (user.IsBlocked)
            {
                return string.Format(OutputMessages.UserBlocked, drivingLicenseNumber);
            }
            if (vehicle.IsDamaged)
            {
                return string.Format(OutputMessages.VehicleDamaged, licensePlateNumber);
            }
            if (route.IsLocked)
            {
                return string.Format(OutputMessages.RouteLocked, routeId);
            }

            vehicle.Drive(route.Length);

            if (isAccidentHappened)
            {
                vehicle.ChangeStatus();
                user.DecreaseRating();
            }
            else
            {
                user.IncreaseRating();
            }

            return vehicle.ToString();
        }

        public string RegisterUser(string firstName, string lastName, string drivingLicenseNumber)
        {
            var user = users.FindById(drivingLicenseNumber);

            if(user != null)
            {
                return string.Format(OutputMessages.UserWithSameLicenseAlreadyAdded, drivingLicenseNumber);
            }

            user = new User(firstName, lastName, drivingLicenseNumber);

            users.AddModel(user);

            return string.Format(OutputMessages.UserSuccessfullyAdded, firstName, lastName, drivingLicenseNumber);
        }

        public string RepairVehicles(int count)
        {
            var damagedVehicles = this.vehicles.GetAll().Where(x=> x.IsDamaged).OrderBy(v => v.Brand).ThenBy(v => v.Model).Take(count).ToList();

            foreach (var vehicle in damagedVehicles)
            {
                vehicle.ChangeStatus();
                vehicle.Recharge();
            }
            return $"{damagedVehicles.Count} vehicles are successfully repaired!";
        }

        public string UploadVehicle(string vehicleType, string brand, string model, string licensePlateNumber)
        {
            if(vehicleType != "CargoVan" && vehicleType != "PassengerCar")
            {
                return string.Format(OutputMessages.VehicleTypeNotAccessible, vehicleType);
            }

            var vehicle = vehicles.FindById(licensePlateNumber);

            if (vehicle != null)
            {
                return $"{licensePlateNumber} belongs to another vehicle.";
            }
            else
            {
                //IVehicle vehicle = null;

                if (vehicleType == "CargoVan")
                {
                    vehicle = new CargoVan(brand, model, licensePlateNumber);
                }
                else if (vehicleType == "PassengerCar")
                {
                    vehicle = new PassengerCar(brand, model, licensePlateNumber);
                }

                this.vehicles.AddModel(vehicle);

                return string.Format(OutputMessages.VehicleAddedSuccessfully, brand, model, licensePlateNumber);
            }
        }

        public string UsersReport()
        {
            var usersSorted = users.GetAll().OrderByDescending(x=>x.Rating).ThenBy(x=>x.LastName).ThenBy(x=>x.FirstName).ToList();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("*** E-Drive-Rent ***");
            foreach(var user in usersSorted)
            {
                sb.AppendLine(user.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
