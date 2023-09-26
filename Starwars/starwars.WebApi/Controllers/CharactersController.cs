using Microsoft.AspNetCore.Mvc;
using starwars.Domain;
using starwars.IBusinessLogic;
using starwars.WebApi.Dtos;
using System.Collections.Generic;
using starwars.Exceptions.BusinessLogicExceptions;
using starwars.WebApi.Filters;
using System.ComponentModel;

namespace starwars.WebApi.Controllers;

[ApiController]
[Route("api/characters")]
public class CharactersController : ControllerBase
{
    private ICharacterService _characterService;

    public CharactersController(ICharacterService characterService)
    {
        _characterService = characterService;
    }

    [HttpGet]
    [Description("Get a list of all tasks.")]
    public IActionResult GetCharacters()
    {
        return Ok(_characterService.GetCharacters().Select(c => new CharacterDTO(c)).ToList());
    }

    [HttpGet("{id}")]
    public IActionResult GetCharacterById([FromRoute] int id)
    {
        CharacterDTO characterResponseModel = new CharacterDTO(_characterService.GetCharacterById(id));
        return Ok(characterResponseModel);
    }

    [HttpPost]
    public IActionResult InsertCharacter([FromBody] CharacterCreateModel newCharacter)
    {
        _characterService.InsertCharacter(newCharacter.ToEntity());
        return Ok();
    }

}

