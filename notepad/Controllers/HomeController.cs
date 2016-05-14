using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using notepad.Models;
using Newtonsoft.Json;
using System.IO;

namespace notepad.Controllers
{
    public class HomeController : Controller
    {
        static List<Note> list = new List<Note>();
        public string myPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data", "DB.json");
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Save(Note note)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if(list[i].Name==note.Name)
                {
                    list[i].Text = note.Text;
                    break;
                }
                if (i == list.Count - 1)
                {
                    list.Add(note);
                }
            }
            if (list.Count == 0) list.Add(note);
            System.IO.File.WriteAllText(myPath, JsonConvert.SerializeObject(list));
            return Json("Сохранено!"); 
        }
        public ActionResult Load()
        {
            if (System.IO.File.Exists(myPath))
            {
                var text = System.IO.File.ReadAllText(myPath);
                list = JsonConvert.DeserializeObject<List<Note>>(text);
            }
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Create()
        {
            return PartialView("_Create");
        }
        public ActionResult Select(string id)
        {
            ViewBag.name = id;
            return View("Index");
        }
        public ActionResult Imageload(string id)
        {
            var stream = id.ToImage().ToStream();
            return File(stream, "image/png");
        }
    }
}