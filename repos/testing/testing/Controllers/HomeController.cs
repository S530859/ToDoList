using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using testing.Models;

namespace testing.Controllers
{
    public class HomeController : Controller
    {


        

        public ActionResult Index()
        {
            

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
         

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult test()
        {
            List<PersonModel> persons = new List<PersonModel>();
            persons.Add(new PersonModel { Title = "Univeristy", id = 0 ,Description = "IOS Class"});
            persons.Add(new PersonModel { Title = "Walmart", id = 1, Description = "Apples" });
            TempData["data"] = persons;
            TempData.Keep();
            return View(persons);
        }
        public ActionResult test1()
        {
            List<PersonModel> data = (List<PersonModel>)TempData["data"];

            TempData.Keep();
            return View("test",data);
        }
        public ActionResult edit(int id) {
            //  Console.Write(persons.ElementAt(id - 1));
            List<PersonModel> data = (List<PersonModel>)TempData["data"];
            System.Diagnostics.Debug.WriteLine( data.ElementAt(id));
            TempData.Keep();
            return View(data.ElementAt(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult edit([Bind(Include ="id,Title,Description")] PersonModel pm)
        {
            if (ModelState.IsValid) {
                List<PersonModel> data = (List<PersonModel>)TempData["data"];


                //PersonModel editedPm1 = (PersonModel) data.Where().First();

                data[pm.id] = pm;
                TempData["data"] = data;
                System.Diagnostics.Debug.WriteLine(data[pm.id]);

                System.Diagnostics.Debug.WriteLine(data.FindIndex(i => i.id == pm.id));



            }
            TempData.Keep();
            return RedirectToAction("test1");
        }

        public ActionResult create() {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult create([Bind(Include = "Title,Description")] PersonModel pm)
        {
            if (ModelState.IsValid)
            {
                List<PersonModel> data = (List<PersonModel>)TempData["data"];
                if (data.Count != 0)
                {
                    pm.id = data.Last().id + 1;
                }
                else if (data.Count == 0) {
                    pm.id = 0;
                }
                data.Add(pm);


                TempData["data"] = data;

            }
            TempData.Keep();
            return RedirectToAction("test1");
        }

        public ActionResult details(int id) {
            List<PersonModel> data = (List<PersonModel>)TempData["data"];


            TempData.Keep();

            return View(data[id]);
        }


        public ActionResult delete(int id) {

            List<PersonModel> data = (List<PersonModel>)TempData["data"];
            int index = data.FindIndex(i => i.id == id);

            TempData.Keep();

            return View(data[index]);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult delete([Bind(Include = "id")] PersonModel pm)
        {

            List<PersonModel> data = (List<PersonModel>)TempData["data"];
            int index = data.FindIndex(i => i.id == pm.id);
            data.RemoveAt(index);

            TempData["data"] = data;
            TempData.Keep();

            return RedirectToAction("test1");
        }


    }
}