﻿using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BookingApp.Models.Bookings
{
    public class Booking : IBooking
    {
        private int residenceDuration;
        private int adultCount;
        private int childrenCount;

        public Booking(IRoom room, int residenceDuration, int adultsCount, int childrenCount, int bookingNumber)
        {
            this.Room = room;
            this.ResidenceDuration = residenceDuration;
            this.AdultsCount= adultsCount;
            this.ChildrenCount= childrenCount;
            this.BookingNumber = bookingNumber;
        }

        public IRoom Room {get; private set;}

        public int ResidenceDuration
        {
            get => this.residenceDuration;
            private set
            {
                if(value < 1)
                {
                    throw new ArgumentException(ExceptionMessages.DurationZeroOrLess);
                }

                this.residenceDuration = value;
            }
        }

        public int AdultsCount
        {
            get => this.adultCount;
            private set
            {
                if(value < 1)
                {
                    throw new ArgumentException(ExceptionMessages.AdultsZeroOrLess);
                }

                this.adultCount = value;
            }
        }

        public int ChildrenCount
        {
            get => this.childrenCount;
            private set
            {
                if(value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.ChildrenNegative);
                }

                this.childrenCount = value;
            }
        }

        public int BookingNumber { get; private set; }

        public string BookingSummary()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Booking number: {this.BookingNumber}");
            sb.AppendLine($"Room type: {this.Room.GetType().Name}");
            sb.AppendLine($"Adults: {this.AdultsCount} Children: {this.ChildrenCount}");
            sb.AppendLine($"Total amount paid: {TotalPaid():F2} $");

            return sb.ToString().TrimEnd();
        }

        private double TotalPaid()
        {
            double total = Math.Round(this.ResidenceDuration * this.Room.PricePerNight, 2);

            return total;
        }
    }
}
