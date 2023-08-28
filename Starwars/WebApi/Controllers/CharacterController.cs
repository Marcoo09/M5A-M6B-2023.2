using Microsoft.AspNetCore.Mvc;
using starwars.Models.In;

namespace WebApi.Controllers;

[Route("api/characters")]
public class CharacterController : StarwarsControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok();
    }

    //api/characters?name=Yoda
    [HttpGet]
    public IActionResult GetBy([FromQuery] string name)
    {
        return Ok();
    }

    //api/characters/5
    [HttpGet("{id}")]
    public IActionResult Get([FromRoute] int id)
    {
        return Ok();
    }

    //api/characters
    [HttpPost]
    public IActionResult Post([FromBody] CharacterModel character)
    {
        return Ok();
    }

    //api/characters/5
    [HttpPut("{id}")]
    public IActionResult Put([FromRoute] int id, [FromBody] CharacterModel character)
    {
        return Ok();
    }

    //api/characters/5
    [HttpDelete("{id}")]
    public IActionResult Delete([FromRoute] int id)
    {
        return Ok();
    }

    //api/characters
    [HttpDelete]
    public IActionResult Delete()
    {
        return Ok();
    }
}
