using EDriveRent.Models.Contracts;
using EDriveRent.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDriveRent.Models
{
    public class Route : IRoute
    {
        private string startPoint;
        private string endPoint;
        private double length;
        private int routeId;
        private bool isLocked;

        public Route(string startPoint, string endPoint, double length, int routeId)
        {
            this.StartPoint = startPoint;
            this.EndPoint = endPoint;
            this.Length = length;
            this.RouteId = routeId;
            //this.IsLocked = false;
        }

        public string StartPoint
        {
            get => this.startPoint;
            private set
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.StartPointNull);
                }
                this.startPoint = value;
            }
        }

        public string EndPoint
        {
            get => this.endPoint;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.EndPointNull);
                }

                this.endPoint = value;
            }
        }

        public double Length
        {
            get => this.length;
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(ExceptionMessages.RouteLengthLessThanOne);
                }
                this.length = value;
            }
        }

        public int RouteId
        {
            get=> this.routeId; 
            private set
            {
                routeId = value;
            }
        }

        public bool IsLocked
        {
            get=> this.isLocked; 
            private set
            {
                isLocked = value;
            }
        }

        public void LockRoute()
        {
            this.IsLocked = true;
        }
    }
}
