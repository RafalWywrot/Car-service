﻿using CarService.Repository.CustomTypes;
using System;

namespace CarService.Repository.Entities
{
    public class BookingService
    {
        public virtual int Id { get; set; }

        public virtual Service Service{ get; set; }
        public virtual Car Car { get; set; }
        public virtual ServiceBookingStatus Status { get; set; }
        public virtual DateTime DateStarted { get; set; }
        public virtual DateTime? DateEnded { get; set; }
        public virtual string UserComment { get; set; }
    }
}