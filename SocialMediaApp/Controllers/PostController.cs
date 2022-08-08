using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialMediaApp.Data.Models;
using SocialMediaApp.DataAccess.Repositories;

namespace SocialMediaApp.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class PostController : ControllerBase
    {
        [HttpGet(nameof(GetPost))]
        public IActionResult GetPost(string id)
        {
            using (var mongo = new MongoRepository<PostModel>())
            {
                var data = mongo.Get(x => x.PostId.Equals(id));
                if (data == null) return NotFound();
                return Ok(data);
            }
        }

        [HttpGet(nameof(GetPostAll))]
        public IActionResult GetPostAll()
        {
            using (var mongo = new MongoRepository<PostModel>())
            {
                var data = mongo.GetAll();
                return Ok(data);
            }
        }

        [HttpPost(nameof(AddPost))]
        public IActionResult AddPost(PostModel model)
        {
            using (var mongo = new MongoRepository<PostModel>())
            {
                if (model == null) return BadRequest();
                mongo.Add(model);
                return Ok(model);

            }
        }

        [HttpPut(nameof(UpdatePost))]
        public IActionResult UpdatePost(PostModel model)
        {
            using (var mongo = new MongoRepository<PostModel>())
            {
                mongo.Update(x => x.PostId.Equals(model.PostId), model);
                return Ok(model);
            }
        }

        [HttpDelete(nameof(DeletePost))]
        public IActionResult DeletePost(PostModel model)
        {
            using (var mongo = new MongoRepository<PostModel>())
            {
                mongo.Delete(x => x.PostId.Equals(model.PostId));
                return Ok(model);
            }
        }
    }
}
