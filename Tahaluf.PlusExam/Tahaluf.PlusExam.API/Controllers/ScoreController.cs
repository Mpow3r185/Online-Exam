using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Tahaluf.PlusExam.Core.Data;
using Tahaluf.PlusExam.Core.ServiceInterface;

namespace Tahaluf.PlusExam.API.Controllers
{
    [Route("[api/controller]")]
    [ApiController]
    public class ScoreController : ControllerBase
    {
        #region Fields
        private readonly IScoreService _scoreService;
        #endregion Fields

        #region Constructor
        public ScoreController(IScoreService scoreService)
        {
            _scoreService = scoreService;
        }
        #endregion Constructor

        #region CRUD_Operation

        #region GetScores
        //Get Scores
        [HttpGet]
        [ProducesResponseType(typeof(List<Score>), StatusCodes.Status200OK)]
        public List<Score> GetScores()
        {
            return _scoreService.GetScores();
        }
        #endregion GetScores

        #region CreateScore
        // Create Score
        [HttpPost]
        [ProducesResponseType(typeof(Score), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool CreateScore([FromBody] Score score)
        {
            return _scoreService.CreateScore(score);
        }
        #endregion CreateScore

        #region UpdateScore
        // Update Score
        [HttpPut]
        [ProducesResponseType(typeof(List<Score>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool UpdateScore([FromBody] Score score)
        {
            return _scoreService.UpdateScore(score);
        }
        #endregion UpdateScore

        #region DeleteScore
        // Delete Score
        [HttpDelete]
        [Route("delete/{id}")]
        public bool DeleteScore(int id)
        {
            return _scoreService.DeleteScore(id);
        }
        #endregion DeleteScore

        #endregion CRUD_Operation
    }
}
