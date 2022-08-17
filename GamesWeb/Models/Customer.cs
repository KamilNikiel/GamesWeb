﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamesWeb.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }
        public MembershipType MembershipType { get; set; }
        public Nullable<DateTime> Birthdate { get; set; }
    }
}