using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesCatalogueChallenge.Contexts;
using MoviesCatalogueChallenge.DTOs;
using MoviesCatalogueChallenge.Entities;
using System.Data;

namespace MoviesCatalogueChallenge.Controllers
{
    [Route("api/Movies")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly MoviesChContext context;
        private readonly IMapper mapper;

        public MoviesController(MoviesChContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string search, int? categoryId, int? releaseYear, int page = 1, int pageSize = 10, string sortBy = "createdDate", bool sortAsc = false)
        {
            // start with all movies
            var query = context.Movies.AsQueryable();

            // filter by category if specified
            if (categoryId != null)
            {
                query = query.Where(m => m.CategoryId == categoryId);
            }

            // filter by release year if specified
            if (releaseYear != null)
            {
                query = query.Where(m => m.ReleaseYear == releaseYear);
            }

            // search by name or synopsis if specified
            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(m => m.Name.Contains(search) || m.Synopsis.Contains(search));
            }

            // calculate skip count and take count for paging
            var skipCount = (page - 1) * pageSize;
            var takeCount = pageSize;

            // sort by specified property and order
            switch (sortBy.ToLower())
            {
                case "name":
                    query = sortAsc ? query.OrderBy(m => m.Name) : query.OrderByDescending(m => m.Name);
                    break;
                case "releaseyear":
                    query = sortAsc ? query.OrderBy(m => m.ReleaseYear) : query.OrderByDescending(m => m.ReleaseYear);
                    break;
                case "createddate":
                    query = sortAsc ? query.OrderBy(m => m.CreatedDate) : query.OrderByDescending(m => m.CreatedDate);
                    break;
                default:
                    query = query.OrderByDescending(m => m.CreatedDate);
                    break;
            }

            // apply paging
            query = query.Skip(skipCount).Take(takeCount);

            // execute the query and return the results
            var movies = await query.ToListAsync();
            return Ok(movies);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> Post([FromBody]MoviePostRequestDTO moviePost)
        {
            if (!User.IsInRole("admin"))
            {
                return StatusCode(403, "You are not allowed to perform this action.");
            }

            var movie = mapper.Map<Movie>(moviePost);

            // validate payload
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            context.Add(movie);
            await context.SaveChangesAsync();
            return Ok();
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody]MoviePostRequestDTO moviePut)
        {

            if (!User.IsInRole("admin"))
            {
                return StatusCode(403, "You are not allowed to perform this action.");
            }

            // find movie by id
            var existingMovie = await context.Movies.FindAsync(id);

            // return not found if movie does not exist
            if (existingMovie == null)
            {
                return NotFound();
            }

            // validate payload
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // update existing movie properties
            existingMovie.Name = moviePut.Name;
            existingMovie.ReleaseYear = moviePut.ReleaseYear;
            existingMovie.Synopsis = moviePut.Synopsis;
            existingMovie.Poster = moviePut.Poster;
            existingMovie.CategoryId = moviePut.CategoryId;

            // save changes to database
            await context.SaveChangesAsync();

            // return success response with updated movie
            return Ok("The Updated Movie was: \n"+existingMovie);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            if (!User.IsInRole("admin"))
            {
                return StatusCode(403, "You are not allowed to perform this action.");
            }

            // find movie by id
            var movie = await context.Movies.FindAsync(id);

            // return not found if movie does not exist
            if (movie == null)
            {
                return NotFound();
            }

            // remove movie from context
            context.Movies.Remove(movie);

            // save changes to database
            await context.SaveChangesAsync();

            // return success response with deleted movie
            return Ok("Movie was successfully deleted");
        }
    }
}
