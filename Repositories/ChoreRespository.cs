using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChoreScore.Repositories;



public class ChoreRespository
{
  private readonly IDbConnection _db;

  public ChoreRespository(IDbConnection db)
  {
    _db = db;
  }

  internal List<Chore> Get()
  {
    string sql = @"
    SELECT
    ch.*,
    ac.*
    FROM chores ch
    JOIN accounts ac ON ac.id = ch.creatorId ;
    ";
    List<Chore> chores = _db.Query<Chore, Account, Chore>(sql, (chore, account) =>
    {
      chore.Creator = account;
      return chore;
    }).ToList();
    return chores;
  }


  internal Chore Get(int id)
  {
    string sql = @"
  SELECT
  ch.*,
  ac.*
  FROM chores ch
  JOIN accounts ac ON ac.id = ch.creatorId
  WHERE ch.id = @id;
  ";
    return _db.Query<Chore, Account, Chore>(sql, (chore, account) =>
    {
      chore.Creator = account;
      return chore;
    }, new { id }).FirstOrDefault();

  }

  internal Chore Create(Chore choreData)
  {
    string sql = @"
    INSERT INTO chores
    (task, earnings, creatorId)
    VALUES
    (@task, @earnings, @creatorId);
    SELECT LAST_INSERT_ID();
    ";
    int id = _db.ExecuteScalar<int>(sql, choreData);
    choreData.Id = id;
    return choreData;
  }


  internal bool Update(Chore choreOriginal)
  {
    string sql = @"
  UPDATE chores
  SET
  task = @task,
  earnings = @earnings,
  completed = @completed
  WHERE id == @id;
  ";
    int rows = _db.Execute(sql, choreOriginal);
    return rows > 0;
  }















}












