using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.EF
{
	public class ArchiveBookContext : DbContext
	{
		public ArchiveBookContext(DbContextOptions<ArchiveBookContext> options)
		: base(options)
		{ }

		public ArchiveBookContext()
		{
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder
				.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Archive;Trusted_Connection=True;MultipleActiveResultSets=true")
				.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<ArchiveBooking>().ToTable("ArchiveBooking").HasKey("ID_ArchiveBooking");
			modelBuilder.Entity<ArchiveCode>().ToTable("ArchiveCode").HasKey("ID_ArchiveCode");
			modelBuilder.Entity<DocumentScan>().ToTable("DocumentScan").HasKey("ID_DocumentScan");
			modelBuilder.Entity<Sender>().ToTable("Sender").HasKey("ID_Sender");
		}

		public DbSet<ArchiveBooking> ArchiveBookings { get; set; }
		public DbSet<ArchiveCode> ArchiveCodes { get; set; }
		public DbSet<DocumentScan> DocumentScans { get; set; }
		public DbSet<Sender> Senders { get; set; }
	}
}
