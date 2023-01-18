using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChoreScore.Models;

public class Chore
{

  public int Id { get; set; }
  public string Task { get; set; }
  public int Earnings { get; set; }
  public bool Completed { get; set; } = false;

  public string CreatorId { get; set; }

  public Account Creator { get; set; }
}
