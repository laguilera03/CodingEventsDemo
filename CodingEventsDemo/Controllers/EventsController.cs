using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodingEventsDemo.Data;
using CodingEventsDemo.Models;
using CodingEventsDemo.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace coding_events_practice.Controllers
{
    public class EventsController : Controller
    {
        //static private List<Event> Events = new List<Event>(); //unnessesary, wouldnt store for deletion
        
        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Event> events = new List<Event>(EventData.GetAll());
            //Commenting out the ViewBag since it is primitive and passing a collection(List... GetAll)
            //ViewBag.events = EventData.GetAll();//Pulls all Data and stores it for the viewbag for modification in the views/Events/cshtml

            return View(events);//passing the list events to the view
        }

        public IActionResult Add()
        {
            //passing an instance
            AddEventViewModel addEventViewModel = new AddEventViewModel();
            return View(addEventViewModel);
        }

        [HttpPost]
        //[Route("Events/Add")]
        public IActionResult Add(AddEventViewModel addEventViewModel)//renamed to Add to remove Routing and included the instanciation of view model
        {
            if(ModelState.IsValid)//asks framework if it meets the requirements
            {
                Event newEvent = new Event
                {
                    //do not use commas at the last property
                    Name = addEventViewModel.Name,
                    Description = addEventViewModel.Description,
                    ContactEmail = addEventViewModel.ContactEmail //add new property from ViewModel and Model
                };

                //Forgot to add the pass of data storage
                EventData.Add(newEvent);

                return Redirect("/Events");
            }

            return View(addEventViewModel);//has to return a value, returns user to page
        }

        public IActionResult Delete()
        {
            ViewBag.events = EventData.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult Delete(int[] eventIds)
        {
            foreach (int eventId in eventIds)
            {
                EventData.Remove(eventId);
            }
            return Redirect("/Events");
        }
    }
}
