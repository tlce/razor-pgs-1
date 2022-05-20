using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorPgs1.Models;

public class RazorPagesMovieContext : DbContext {
    public RazorPagesMovieContext(DbContextOptions<RazorPagesMovieContext> options)
        : base(options) {
    }

    public DbSet<RazorPgs1.Models.Movie> Movie { get; set; }
}
