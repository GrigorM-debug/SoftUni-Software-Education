using EDriveRent.Models.Contracts;
using EDriveRent.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDriveRent.Models
{
    public class User : IUser
    {
        private string firstName;
        private string lastName;
        private double rating;
        private string drivingLicenseNumber;
        private bool isBlocked;

        public User(string firstName, string lastName, string drivingLicenseNumber)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.DrivingLicenseNumber = drivingLicenseNumber;
            this.Rating = 0;
            this.IsBlocked = false;
        }

        public string FirstName 
        {
            get => this.firstName;
            private set
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.FirstNameNull);
                }
                this.firstName = value;
            }
        }

        public string LastName
        {
            get => this.lastName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.LastNameNull);
                }
                this.lastName = value;
            }
        }

        public double Rating
        {
            get => this.rating; 
            private set
            {
                rating = value;
            }
        }

        public string DrivingLicenseNumber
        {
            get => this.drivingLicenseNumber;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.DrivingLicenseRequired);
                }
                this.drivingLicenseNumber = value;
            }
        }

        public bool IsBlocked
        {
            get => this.isBlocked; 
            private set
            {
                isBlocked = value;
            }
        }

        public void DecreaseRating()
        {
            if(this.rating < 2 )
            {
                this.Rating = 0;
                this.IsBlocked = true;
            }
            else
            {
                this.Rating -= 2;
            }
        }

        public void IncreaseRating()
        {
            if(this.Rating > 10)
            {
                this.Rating = 10;
            }

            this.Rating += 0.5;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} Driving license: {DrivingLicenseNumber} Rating: {Rating}";
        }
    }
}
