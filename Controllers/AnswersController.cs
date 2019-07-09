using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswersController : ControllerBase
    {
        // GET: api/Answers
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Answers/782/0
        [HttpGet("{id}/{q}", Name = "Get")]
        public string Get(int id, int q)
        {
            string response = "";
            using (var db = new ModelDbContext())
            {
                var activityQuestionIds = db.QuestionTable.Where(x => x.Case_Id == id && x.Question_Type_Id == 2)
                                                            .Select(x => x.Question_Id)
                                                            .ToList();
                List<string> responseList = new List<string>();
                var answers = db.AnswerTable.Where(x => x.Question_Id == activityQuestionIds[q]);
                foreach(var answer in answers)
                {
                    responseList.Add("{\"" + answer.Answer_Id 
                        + "\":{\"correct\":\"" 
                        + answer.Answer_Correct 
                        + "\",\"explain\":\"" 
                        + answer.answer_explanation + "\"}}");
                }
                response = "["+ string.Join(",", responseList) + "]";
            }
            return response;
        }
        // POST: api/Answers
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Answers/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
