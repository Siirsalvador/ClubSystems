using ClubSystemsAssessment.Models;
using ClubSystemsAssessment.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ClubSystemsAssessment.Controllers;

[ApiController]
[Route("api/membershiptypes")]
public class MembershipTypeController : ControllerBase
{
    private readonly ILogger<MembershipTypeController> _logger;
    private readonly IRepository<MembershipType> _repository;
    private Response _response;

        public MembershipTypeController(ILogger<MembershipTypeController> logger, IRepository<MembershipType> repository)
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
                var membershipTypes = await _repository.GetAll();
                _response.Result = membershipTypes;
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> {e.ToString()};
            }

            return _response;
        }

    [HttpPost]
    public async Task<object> Post([FromBody] MembershipType membershipType)
    {
        try
        {
            var model = await _repository.CreateUpdate(membershipType);
            _response.Result = model;
        }
        catch (Exception e)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string> {e.ToString()};
        }

        return _response;
    }

}