using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DealershipManager.Models;

namespace DealershipManager.Controllers
{
    public class CarController : Controller
    {
        internal static List<Car> cars = new List<Car>()
        {
            new Car(1, "Ford", "F-150", "Red"),
            new Car(2, "Jeep", "Wrangler", "Baja Yellow"),
            new Car(3, "Chevy", "Malibu", "White")
        };

        // GET: Car
        public ActionResult Index()
        {
            return View(cars);
        }

        // GET: Car/Details/5
        public ActionResult Details(int id)
        {
            //we want to get the car that has the same ID as the id parameter

            var car = cars.Find(x => x.Id == id);
            return View(car);
        }

        // GET: Car/Create

        public ActionResult Create()
        {
            return View();
        }

        // POST: /Car/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                int id;
                string make;
                string model;
                string color;

                //Get the values from the form
                make = collection["Make"];
                model = collection["Model"];
                color = collection["Color"];
                id = cars.Count + 1;

                //Create a new car object form the values
                Car car = new Car(id, make, model, color);
                //Add the new car object to the list of cars we have
                cars.Add(car);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Car/Edit/5

        public ActionResult Edit(int id)
        {
            var car = cars.Find(x => x.Id == id);

            return View(car);
        }

        //
        // POST: /Car/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                string _make, _model, _color;
                //Get the values form the form
                _make = collection["Make"];
                _model = collection["Model"];
                _color = collection["Color"];

                //Get the car being edited
                var car = cars.Find(x => x.Id == id);
                cars.Remove(car);

                car.Make = _make;
                car.Model = _model;
                car.Color = _color;

                cars.Add(car);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Car/Delete/5

        public ActionResult Delete(int id)
        {
            var car = cars.Find(x => x.Id == id);
            return View(car);
        }

        //
        // POST: /Car/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                cars.RemoveAll(x => x.Id == id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
