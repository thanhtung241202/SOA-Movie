﻿using System.Collections.Generic;
using System.Reflection.Emit;
using System.Runtime.Remoting.Contexts;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieSeries.CoreLayer.Entities;
namespace MovieSeries.DataAccessLayer
{
    public class AppDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<MovieSeriesTag> MovieSeriesTags { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) :
        base(options)
        { }
        protected override void OnModelCreating(ModelBuilder
        modelBuilder)
        {
            modelBuilder.Entity<MovieSeriesTag>()
            .HasKey(mst => new { mst.MovieSeriesId, mst.TagId });
            modelBuilder.Entity<MovieSeriesTag>()
            .HasOne(mst => mst.Movie)
            .WithMany(m => m.MovieSeriesTags)
            .HasForeignKey(mst => mst.MovieSeriesId);
            modelBuilder.Entity<MovieSeriesTag>()
            .HasOne(mst => mst.Tag)
            .WithMany(t => t.MovieSeriesTags)
            .HasForeignKey(mst => mst.TagId);
        }
        public async Task<IEnumerable<Movie>> GetAllMoviesAsync()
        {
            return await _context.Movies.ToListAsync();
        }
        public async Task<IEnumerable<Movie>> GetTopRatedMoviesWithSpAsync(int
        topCount)
        {
            return await _context.Movies
            .FromSqlRaw("EXEC GetTopRatedMovies @top_count = {0}", topCount)
            .ToListAsync();
        }
    }
}