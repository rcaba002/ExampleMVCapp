using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DealershipManager.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }

        public Car(int _id, string _make, string _model, string _color)
        {
            this.Id = _id;
            this.Make = _make;
            this.Model = _model;
            this.Color = _color;
        }
    }
}