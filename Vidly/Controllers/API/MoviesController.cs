using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using Vidly.App_Start;
using Vidly.Models;

namespace Vidly.Controllers.API
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        [System.Web.Http.HttpGet]
        public IHttpActionResult Index()
        {
            return Ok(_context.Movie.Include(m => m.Genre).Select(Mapper.Map<Movie, MovieDto>));
        }

        [System.Web.Http.HttpGet]
        public IHttpActionResult Details(int? id)
        {
            Movie movie = _context.Movie.SingleOrDefault(m => m.ID == id);
            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }

        [System.Web.Http.HttpPost]
        public IHttpActionResult New(MovieDto movieDto)
        {
            if (!ModelState.IsValid) return BadRequest();
            Movie movie = Mapper.Map<MovieDto, Movie>(movieDto);

            _context.Movie.Add(movie);
            _context.SaveChanges();

            movieDto.ID = movie.ID;
            return Created(new Uri(Request.RequestUri + "/" + movie.ID), movieDto);
        }

        [System.Web.Http.HttpPut]
        public IHttpActionResult UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid) return BadRequest();

            Movie movieInDb = _context.Movie.SingleOrDefault(m => m.ID == id);
            if (movieInDb is null) return NotFound();

            Mapper.Map(movieDto,movieInDb);
            _context.SaveChanges();

            return Ok();
        }

        [System.Web.Http.HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {
            Movie movieInDb = _context.Movie.SingleOrDefault(m => m.ID == id);
            if (movieInDb is null) return NotFound();

            _context.Movie.Remove(movieInDb);
            _context.SaveChanges();
            return Ok();
        }
    }
}
