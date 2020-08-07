using Microsoft.AspNetCore.Mvc;
using DrSneussFactory.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DrSneussFactory.Controllers
{
  public class EngineersController : Controller
  {
    private readonly DrSneussFactoryContext _db;

    public EngineersController(DrSneussFactoryContext db)
    {
      _db = db;
    }

    public ActionResult Index(string seachQuery)
    {
      IQueryable<Engineer> engineerQuery = _db.Engineers;
      ViewBag.SearchFlag = 0;
      if (!string.IsNullOrEmpty(searchQuery))
      {
        engineerQuery = engineerQuery.Where(engineers => engineers.Name.ToLower().Contains(searchQuery.ToLower()));
        ViewBag.SearchFlag = 1;
      }
      IEnumerable<Engineer> engineerList = engineerQuery.ToList().OrderBy(engineers => engineers.Name);
      return View(engineerList);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Engineer engineer)
    {
      _db.Engineers.Add(engineer);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Engineer thisEngineer = _db.Engineers
          .Include(engineer => engineer.Machines)
          .ThenInclude(join => join.Machine)
          .FirstOrDefault(engineer => engineer.EngineerId == id);
      return View(thisEngineer);
    }

    public ActionResult Edit(int id)
    {
      Engineer thisEngineer = _db.Engineers.FirstOrDefault(engineer => engineer.EngineerId == id);
      return View(thisEngineer);
    }

    [HttpPost]
    public ActionResult Edit(Engineer engineer)
    {
      _db.Entry(engineer).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult Delete(int id)
    {
      Engineer thisEngineer = _db.Engineers.FirstOrDefault(engineer => engineer.EngineerId == id);
      _db.Engineers.Remove(thisEngineer);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddMachine(int id)
    {
      Engineer thisEngineer = _db.Engineers.FirstOrDefault(engineer => engineer.EngineerId == id);
      ViewBag.MachineId = new SelectList(_db.Machines, "MachineId", "Name");
    }

    [HttpPost]
    public ActionResult AddMachine (Engineer engineer, int MachineId)
    {
      if (MachineId != 0)
      {
        _db.EngineerMachine.Add(new EngineerMachine() { MachineId = MachineId, EngineerId = engineer.EngineerId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult RemoveMachine (int EngineerId, int MachineId)
    {
      if (MachineId != 0 && EngineerId != 0)
      {
        EngineerMachine thisEngineerMachine = _db.EngineerMachine.FirstOrDefault(join => join.Engineer.EngineerId == EngineerId && join.Machine.MachineId == MachineId);
        _db.EngineerMachine.Remove(thisEngineerMachine);
        _db.SaveChanges();
        return RedirectToAction("Index");
      }
    }
  }
}