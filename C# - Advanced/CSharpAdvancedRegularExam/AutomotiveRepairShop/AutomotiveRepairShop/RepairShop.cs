using System.Text;

namespace AutomotiveRepairShop
{
    public class RepairShop
    {
        public RepairShop(int capasity)
        {
            Capasity = capasity;
            Vehicles = new List<Vehicle>();
        }

        public int Capasity { get; set; }

        public List<Vehicle> Vehicles  { get; set; }

        public int Count { get { return Vehicles.Count; } }

        public void AddVehicle(Vehicle vehicle)
        {
            if(Vehicles.Count < Capasity)
            {
                Vehicles.Add(vehicle);
            }
        }

        public bool RemoveVehicle(string vin)
        {
            var vehicleToRemove = Vehicles.Find(x => x.VIN== vin);

            bool isRemoved = Vehicles.Remove(vehicleToRemove);  

            return isRemoved;
        }

        public int GetCount()
        {
            return Vehicles.Count;
        }

        public Vehicle GetLowestMileage()
        {
            return Vehicles.OrderBy(x => x.Mileage).FirstOrDefault();
        }

        public string Report()
        {
            StringBuilder sb = new();

            sb.AppendLine("Vehicles in the preparatory:");

            foreach(var vehicle in Vehicles)
            {
                sb.AppendLine(vehicle.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
