using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ChoreScore.Controllers;




[ApiController]
[Route("api/[controller]")]
public class ChoreController : ControllerBase
{

  private readonly ChoreService _choreService;
  private readonly Auth0Provider _auth0provider;

  public ChoreController(ChoreService choreService, Auth0Provider auth0provider)
  {
    _choreService = choreService;
    _auth0provider = auth0provider;
  }

  [HttpGet]
  public async Task<ActionResult<List<Chore>>> Get()
  {
    try
    {
      Account userInfo = await _auth0provider.GetUserInfoAsync<Account>(HttpContext);
      List<Chore> chores = _choreService.Get(userInfo?.Id);
      return Ok(chores);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }


  [HttpPost]
  [Authorize]
  public async Task<ActionResult<Chore>> Create([FromBody] Chore choreData)
  {
    try
    {
      Account userInfo = await _auth0provider.GetUserInfoAsync<Account>(HttpContext);
      choreData.CreatorId = userInfo.Id;
      Chore chore = _choreService.Create(choreData);
      chore.Creator = userInfo;
      return Ok(chore);

    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpPut("{id}")]
  [Authorize]
  public async Task<ActionResult<string>> Complete(int id)
  {
    try
    {
      Account userInfo = await _auth0provider.GetUserInfoAsync<Account>(HttpContext);
      string message = _choreService.Complete(id, userInfo.Id);
      return Ok(message);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }







  // [HttpDelete("{id}")]
  // public ActionResult<string> Remove(int id)
  // {
  //   try
  //   {
  //     string message = _choreService.CompleteChore(id);
  //     return Ok(message);
  //   }
  //   catch (Exception e)
  //   {
  //     return BadRequest(e.Message);
  //   }
  // }






}