using ClubSystemsAssessment.Models;
using ClubSystemsAssessment.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ClubSystemsAssessment.Controllers;

[ApiController]
[Route("api/memberships")]
public class MembershipController : ControllerBase
{
    private readonly ILogger<MembershipController> _logger;
    private readonly IMembershipRepository _repository;
    private Response _response;

    public MembershipController(ILogger<MembershipController> logger, IMembershipRepository repository)
{
    _logger = logger;
    _repository = repository;
    _response = new();
}

    [HttpGet]
    public async Task<object> Get()
    {
        try
        {
            var memberships = await _repository.GetAll();
            _response.Result = memberships;
        }
        catch (Exception e)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string> {e.ToString()};
        }

        return _response;
    }

    [HttpPost]
    public async Task<object> Post([FromBody] MembershipDto membership)
    {
        try
        {
            var model = await _repository.CreateUpdate(membership.Map());
            _response.Result = model;
            if (model.MembershipId == 0)
                throw new Exception("Verify Member and MemberType information");
        }
        catch (Exception e)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string> {e.ToString()};
        }

        return _response;
    }

    [HttpGet]
    [Route("member/{id}")]
    public async Task<object> GetByMember(int id)
    {
        try
        {
            var memberships = await _repository.GetByMemberId(id);
            _response.Result = memberships;
        }
        catch (Exception e)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string> {e.ToString()};
        }

        return _response;
    }
 
    [HttpGet]
    [Route("membershiptype/{id}")]
    public async Task<object> GetByMembershipType(int id)
    {
        try
        {
            var memberships = await _repository.GetByMembershipTypeId(id);
            _response.Result = memberships;
        }
        catch (Exception e)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string> {e.ToString()};
        }

        return _response;
    }
    
    [HttpGet]
    [Route("overdrawn")]
    public async Task<object> GetOverdrawn()
    {
        try
        {
            var memberships = await _repository.GetOverdrawnMemberships();
            _response.Result = memberships;
        }
        catch (Exception e)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string> {e.ToString()};
        }

        return _response;
    }
    
}