using ClubSystemsAssessment.Models;
using ClubSystemsAssessment.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ClubSystemsAssessment.Controllers;

[ApiController]
[Route("api/members")]
public class MemberController : ControllerBase
{
    private readonly ILogger<MemberController> _logger;
    private readonly IRepository<Member> _repository;
    private Response _response;

        public MemberController(ILogger<MemberController> logger, IRepository<Member> repository)
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
                var members = await _repository.GetAll();
                _response.Result = members;
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> {e.ToString()};
            }

            return _response;
        }

    [HttpPost]
    public async Task<object> Post([FromBody] Member member)
    {
        try
        {
            var model = await _repository.CreateUpdate(member);
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