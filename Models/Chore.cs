using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChoreScore.Models;

public class Chore
{
  public Chore(int id, string task, int earnings, bool completed)
  {
    Id = id;
    Task = task;
    Earnings = earnings;
    Completed = completed;
  }

  public int Id { get; set; }
  public string Task { get; set; }
  public int Earnings { get; set; }
  public bool Completed { get; set; }
}
