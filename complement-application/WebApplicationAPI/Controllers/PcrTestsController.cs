using System.Net;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationAPI.Models;
using WebApplicationEntities;
using WebApplicationPersistence.DbContexts;

namespace WebApplicationAPI.Controllers;

[ApiController]
// [Route("[controller]")]
[Route("pcr-tests")]
public class PcrTestsController : ControllerBase
{
    private readonly ILogger<PcrTestsController> _logger;
    private readonly PcrContext _dbContext;
    private readonly IMapper _mapper;

    public PcrTestsController(ILogger<PcrTestsController> logger, PcrContext dbContext, IMapper mapper)
    {
        _logger = logger;
        _dbContext = dbContext;
        _mapper = mapper;
    }
    
    /// <summary>
    /// Retourne la liste des tests PCR
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(typeof(List<PcrTestDto>), (int) HttpStatusCode.OK)]
    [ProducesResponseType((int) HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetList()
    {
        var dbPcrTests = await _dbContext.PcrTests.ToListAsync();
        return Ok(_mapper.Map<List<PcrTestDto>>(dbPcrTests));
    }
    
    /// <summary>
    /// Retourne le test PCR correspondant
    /// </summary>
    /// <param name="id">Identifiant du test PCR</param>
    /// <returns></returns>
    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType((int) HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(PcrTestDto), (int) HttpStatusCode.OK)]
    [ProducesResponseType((int) HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> Get(int id)
    {
        var dbPcrTest = await _dbContext.PcrTests.FindAsync(id);

        if (dbPcrTest == null) return NotFound();

        return Ok(_mapper.Map<PcrTestDto>(dbPcrTest));
    }
    
    /// <summary>
    /// Crée un nouveau test PCR
    /// </summary>
    /// <param name="dto">Nouveau test PCR</param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType((int) HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(PcrTestDto), (int) HttpStatusCode.Created)]
    [ProducesResponseType((int) HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> Post(PcrTestDto dto)
    {
        if (dto.PerformerId.HasValue)
        {
            var dbPerformer = await _dbContext.Users.FindAsync(dto.PerformerId);
            if (dbPerformer is null)
                return BadRequest("This performer doesn't exist.");
        }

        var sampleNumberAlreadyUsed = await _dbContext.PcrTests.AnyAsync(x => x.SampleNumber == dto.SampleNumber);
        
        if (sampleNumberAlreadyUsed)
            return BadRequest("This sample number already exists.");
        
        var dbPcrTest = _mapper.Map<PcrTest>(dto);
        dbPcrTest.CreationDate = DateTime.Now;
        await _dbContext.AddAsync(dbPcrTest); 
        await _dbContext.SaveChangesAsync();
        return CreatedAtAction("Get", new { id = dbPcrTest.Id }, _mapper.Map<PcrTestDto>(dbPcrTest));
    }
    
    /// <summary>
    /// Mets à jour le test PCR correspondant
    /// </summary>
    /// <param name="id">Identifiant du test PCR</param>
    /// <param name="dto">Test PCR mit à jour</param>
    /// <returns></returns>
    [HttpPut]
    [ProducesResponseType((int) HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(PcrTestDto), (int) HttpStatusCode.OK)]
    [ProducesResponseType((int) HttpStatusCode.InternalServerError)]
    [Route("{id}")]
    public async Task<IActionResult> Put(int id, PcrTestDto dto)
    {
        var dbPcrTest = await _dbContext.PcrTests.FindAsync(id);

        if (dbPcrTest == null) return NotFound();

        _mapper.Map(dto, dbPcrTest);
        _dbContext.Update(dbPcrTest);
        await _dbContext.SaveChangesAsync();

        return Ok(_mapper.Map<PcrTestDto>(dbPcrTest));
    }
    
    /// <summary>
    /// Supprime le test PCR correspondant
    /// </summary>
    /// <param name="id">Identifiant du test PCR</param>
    /// <returns></returns>
    [HttpDelete]
    // [Route("{id}/tululu/{monDeuxiemeId}")]
    // public async Task<IActionResult> Delete(int monDeuxiemeId, int id)
    [Route("{id}")]
    [ProducesResponseType((int) HttpStatusCode.NotFound)]
    [ProducesResponseType((int) HttpStatusCode.NoContent)]
    [ProducesResponseType((int) HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> Delete(int id)
    {
        var dbPcrTest = await _dbContext.PcrTests.FindAsync(id);

        if (dbPcrTest == null) return NotFound();
        
        _dbContext.Remove(dbPcrTest);
        await _dbContext.SaveChangesAsync();
        return NoContent();
    }
}