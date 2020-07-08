using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingEventsDemo.Models
{
    public class Event
    {
        public string Name { get; set; }
        [FromForm(Name = "desc")]//added this in part of model binding to keep the set name in the html form as "desc"
        public string Description { get; set; }
        public string ContactEmail { get; set; }

        public int Id { get; }
        static private int nextId = 1;

        public Event()//Model Binding by constructor chaining
        {
            Id = nextId;
            nextId++;
        }

        public Event(string name, string description, string contactEmail)
        {
            Name = name;
            Description = description;
            //switched the location for ID to the empty constructor
            ContactEmail = contactEmail;
        }

        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object obj)
        {
            return obj is Event @event && Id == @event.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
