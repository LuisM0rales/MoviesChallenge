using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesCatalogueChallenge.Contexts;
using MoviesCatalogueChallenge.Entities;
using System.Security.Claims;

namespace MoviesCatalogueChallenge.Controllers
{
    [Authorize]
    [Route("api/Ratings")]
    [ApiController]
    public class RatingsController : ControllerBase
    {
        private readonly MoviesChContext context;
        private readonly IMapper mapper;

        public RatingsController(MoviesChContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Post(int movieId, [FromBody] int ratingValue)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.Name)?.Value);

            var existingRating = await context.Ratings.FirstOrDefaultAsync(r => r.MovieId == movieId && r.UserId == userId);

            if (existingRating != null)
            {
                // user has already rated this movie, update the existing rating
                existingRating.Value = ratingValue;
            }
            else
            {
                // user hasn't rated this movie yet, create a new rating
                var rating = new Rating
                {
                    MovieId = movieId,
                    UserId = userId,
                    Value = ratingValue
                };
                context.Ratings.Add(rating);
            }

            await context.SaveChangesAsync();

            return Ok();
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(int movieId)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.Name)?.Value);

            var rating = await context.Ratings.FirstOrDefaultAsync(r => r.MovieId == movieId && r.UserId == userId);

            if (rating != null)
            {
                context.Ratings.Remove(rating);
                await context.SaveChangesAsync();
            }

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var userId = User.FindFirst(ClaimTypes.Name)?.Value;

            var ratings = await context.Ratings
                .Where(r => r.UserId.ToString() == userId)
                .ToListAsync();

            return Ok(ratings);
        }
    }
}
