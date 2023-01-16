using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChoreScore.Repositories;



public class ChoreRespository
{

  private List<Chore> choreDb;

  public ChoreRespository()
  {
    this.choreDb = new List<Chore>(){
        new Chore(1, "Clean the dishes", 5, false),
        new Chore(2, "Walk the dog", 10, false),
        new Chore(3, "Take out the garbage", 2, false),
        new Chore(4, "Mow the lawn", 15, false),
        new Chore(5, "Water the plants", 3, false)
      };
  }

  internal Chore Create(Chore choreData)
  {
    choreData.Id = choreDb[choreDb.Count - 1].Id + 2;
    choreDb.Add(choreData);
    return choreData;
  }


  internal List<Chore> Get()
  {
    return choreDb;
  }


  internal string Complete(int id)
  {
    Chore choreToRemove = choreDb.Find(c => c.Id == id);
    if (!choreToRemove.Completed)
    {
      choreToRemove.Completed = !choreToRemove.Completed;
      return $"{choreToRemove.Task} has been completed, you have earned ${choreToRemove.Earnings} for completing it";
    }
    return "This chore has already been completed";
  }
}
