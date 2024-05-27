﻿using MatrimonyApiService.Commons;
using MatrimonyApiService.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace MatrimonyApiService.Match;

// TODO In detail validations
[ApiController]
[Route("api/[controller]")]
public class MatchController(IMatchService matchService, ILogger<MatchController> logger): ControllerBase
{
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(int id)
    {
        try
        {
            var match = await matchService.GetById(id);
            return Ok(match);
        }
        catch (KeyNotFoundException ex)
        {
            logger.LogError(ex.Message);
            return NotFound(new ErrorModel(StatusCodes.Status404NotFound, ex.Message));
        }
    }

    [HttpGet("accepted/{profileId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAcceptedMatches(int profileId)
    {
        var matches = await matchService.GetAcceptedMatches(profileId);
        return Ok(matches);
    }

    [HttpGet("requests/{profileId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetMatchRequests(int profileId)
    {
        var matches = await matchService.GetMatchRequests(profileId);
        return Ok(matches);
    }

    [HttpDelete("{matchId}/{profileId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Cancel(int matchId, int profileId)
    {
        try
        {
            await matchService.Cancel(matchId, profileId);
            return Ok();
        }
        catch (InvalidMatchForProfile ex)
        {
            logger.LogError(ex.Message);
            return BadRequest(new ErrorModel(StatusCodes.Status400BadRequest, ex.Message));
        }
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Add(MatchDto dto)
    {
        var match = await matchService.Add(dto);
        return Ok(match);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Update(MatchDto dto)
    {
        var match = await matchService.Update(dto);
        return Ok(match);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> DeleteById(int id)
    {
        var match = await matchService.DeleteById(id);
        return Ok(match);
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        var matches = await matchService.GetAll();
        return Ok(matches);
    }
}