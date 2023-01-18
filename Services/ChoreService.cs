using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChoreScore.Services;
public class ChoreService
{
  private readonly ChoreRespository _repo;

  public ChoreService(ChoreRespository repo)
  {
    _repo = repo;
  }



  internal Chore Create(Chore choreData)
  {
    Chore newChore = _repo.Create(choreData);
    return newChore;
  }


  internal List<Chore> Get(string userId)
  {
    List<Chore> chores = _repo.Get();
    List<Chore> choresFiltered = chores.FindAll(c => c.Completed == false || c.CreatorId == userId);
    return choresFiltered;
  }

  internal string Complete(int id, string userId)
  {
    Chore choreOriginal = _repo.Get(id);
    if (choreOriginal == null)
    {
      throw new Exception("There is no chore here");
    }
    if (choreOriginal.CreatorId != userId)
    {
      throw new Exception("this is not your chore to complete!");
    }
    if (choreOriginal.Completed == true)
    {
      throw new Exception("this chore was already completed");
    }
    choreOriginal.Completed = true;

    return $"{choreOriginal.Task} has been completed, you have earned {choreOriginal.Earnings} dollars";


  }

}