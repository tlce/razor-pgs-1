using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPgs1.Models;

namespace RazorPgs1.Pages_Movies {
    public class IndexModel : PageModel {
        private readonly RazorPagesMovieContext _context;

        public IndexModel(RazorPagesMovieContext context) {
            _context = context;
        }

        public IList<Movie> Movie { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Genres { get; set; }

        [BindProperty(SupportsGet = true)]
        public string MovieGenre { get; set; }


        public async Task OnGetAsync() {
            IQueryable<string> genreQuery = from m in _context.Movie orderby m.Genre select m.Genre;

            var movies = from m in _context.Movie
                         select m; // Select all movies

            if (!string.IsNullOrEmpty(SearchString)) {
                movies = movies.Where(s => s.Title.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(MovieGenre)) {
                movies = movies.Where(x => x.Genre == MovieGenre);
            }
            Genres = new SelectList(await genreQuery.Distinct().ToListAsync()); // Creates a list of all distinct genres in database to select from

            Movie = await movies.ToListAsync();
        }
    }
}
