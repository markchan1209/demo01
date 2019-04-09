using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using demo01.Models;

namespace demo01.Controllers
{
    [Route("api/[controller]")]
    public class MyController : Controller
    {
        KSContext db;

        public MyController(KSContext _db) {
            db = _db;
        }
               
        [HttpGet("/api/spots")]
        public IEnumerable<Record> Gets(string k = "")
        {
            var data = this.db.ScenicSpots.AsQueryable();
            if (!String.IsNullOrEmpty(k))
            {
                data = data.Where(t => t.Name.Contains(k) || t.Description.Contains(k));
            }
            return data.Take(10);
        }

        // GET api/my/5
        [HttpGet("/api/spots/{id}")]
        public Record GetById(string id)
        {
            return this.db.ScenicSpots.Find(id);
        }

        // POST api/my
        [HttpPost("")]
        public void Post([FromBody] string value) { }

        // PUT api/my/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value) { }

        // DELETE api/my/5
        [HttpDelete("{id}")]
        public void DeleteById(int id) { }

        // [HttpGet("/importdb")]
        // public IActionResult ImportDB()
        // {
        //   All data = All.FromJson(System.IO.File.ReadAllText("data.json"));
        //   foreach (var item in data.Result.Records)
        //   {
        //       this.db.Add(item);
        //   }
        //   this.db.SaveChanges();

        //   return Content("OK");
        // }
    }
}