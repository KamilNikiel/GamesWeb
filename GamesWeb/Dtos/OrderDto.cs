using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamesWeb.Dtos
{
    public class OrderDto
    {
        public string CustomerId { get; set; }
        public List<int> GameIds { get; set; }
    }
}