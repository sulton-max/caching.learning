﻿using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using NickChapsas.DistributedCache.Advanced.Services;

namespace NickChapsas.DistributedCache.Advanced.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CacheController : ControllerBase
{
    private readonly ICacheService _cacheService;

    public CacheController(ICacheService cacheService)
    {
        _cacheService = cacheService;
    }

    [HttpGet("{key}")]
    public async Task<IActionResult> Get([FromRoute] string key)
    {
        var result = await _cacheService.GetCacheValueAsync("test");
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] object entry)
    {
        await _cacheService.SetCacheValueAsync("test", JsonSerializer.Serialize(entry));
        return Ok();
    }
}