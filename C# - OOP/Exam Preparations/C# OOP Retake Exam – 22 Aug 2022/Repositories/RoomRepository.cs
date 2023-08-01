using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Repositories
{
    public class RoomRepository : IRepository<IRoom>
    {
        private ICollection<IRoom> rooms;

        public RoomRepository()
        {
            rooms = new List<IRoom>();
        }

        public void AddNew(IRoom model)
        {
            this.rooms.Add(model);
        }

        public IReadOnlyCollection<IRoom> All()
        {
            return this.rooms.ToList().AsReadOnly();
        }

        public IRoom Select(string criteria)
        {
            return this.rooms.FirstOrDefault(x => x.GetType().Name == criteria);
        }
    }
}
