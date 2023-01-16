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


  internal List<Chore> Get()
  {
    List<Chore> chores = _repo.Get();
    return chores;
  }


  internal string CompleteChore(int id)
  {
    string message = _repo.Complete(id);
    return message;
  }

}