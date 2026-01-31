using FoodRescue.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodRescue.Data
{
	public class DataContext:DbContext
	{
		public DbSet<Business> businesses { get; set; }
		public DbSet<Charity> charities { get; set; }
		public DbSet<Donation> donations { get; set; }
		public DbSet<User> Users { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

		{

			optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=FoodRescue_db;Trusted_Connection=True;TrustServerCertificate=True;");

		}

	}
}
