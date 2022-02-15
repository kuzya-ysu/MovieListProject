using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MovieListWebAPI.Exceptions;
using MovieListWebAPI.Managers;
using MovieListWebAPI.Models;

namespace MovieListWebAPI.Controllers
{
    [Route("MovieList")]
    [ApiController]
    public class MovieListController : ControllerBase
    {
        private readonly MovieListManager _movieListManager;

        public MovieListController(MovieListManager movieListManager)
        {
            _movieListManager = movieListManager;
        }

        [HttpGet]
        public IEnumerable<Title> GetMovieList()
        {
            return _movieListManager.GetMovieList();
        }

        [HttpGet("{titleId}")]
        public ActionResult<Title> GetTitle(int titleId)
        {
            return _movieListManager.GetTitle(titleId);
        }

        [HttpPost]
        public IActionResult CreateTitle([FromBody] Title title)
        {
            _movieListManager.CreateTitle(title);
            return CreatedAtAction("GetTitle", new { titleId = title.Id }, title);
        }

        [HttpDelete("{titleId}")]
        public IActionResult DeleteTitle(int titleId)
        {
            _movieListManager.DeleteTitle(titleId);
            return NoContent();
        }

        [HttpPatch("{titleId}")]
        public IActionResult UpdateTitle(int titleId,[FromBody] Title title)
        {
            _movieListManager.UpdateTitle(titleId, title);
            return NoContent();
        }

    }
}
