using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Tahaluf.PlusExam.Core.Data;
using Tahaluf.PlusExam.Core.ServiceInterface;

namespace Tahaluf.PlusExam.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScoreController : ControllerBase
    {
        private readonly IScoreService _scoreService;

        public ScoreController(IScoreService scoreService)
        {
            _scoreService = scoreService;
        }
        //Get All Scores
        [HttpGet]
        [ProducesResponseType(typeof(List<Score>), StatusCodes.Status200OK)]
        public List<Score> GetAll()
        {
            return _scoreService.GetAll();
        }

        //Create
        [HttpPost]
        [ProducesResponseType(typeof(Score), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool CreateScore([FromBody] Score score)
        {
            return _scoreService.CreateScore(score);
        }

        //Update
        [HttpPut]
        [ProducesResponseType(typeof(List<Score>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool UpdateScore([FromBody] Score score)
        {
            return _scoreService.UpdateScore(score);
        }

        //Delete
        [HttpDelete]
        [Route("delete/{id}")]
        public bool DeleteScore(int id)
        {
            return _scoreService.DeleteScore(id);
        }
    }
}
