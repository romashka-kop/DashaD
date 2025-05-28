using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DashaD.Models;
using Microsoft.EntityFrameworkCore;

namespace DashaD.Context
{
    public class ApplicationContext : DbContext
    {
        public DbSet<ActComparingAnalysis> Analysis { get; set; }
        public DbSet<ActImplementation> Implementation { get; set; }
        public DbSet<ActUse> ActUses { get; set; }
        public DbSet<Agreement> Agreement { get; set; }
        public DbSet<AgreementCreation> AgreementCreation { get; set; }
        public DbSet<Authors> Author { get; set; }
        public DbSet<Bid> Bids { get; set; }
        public DbSet<LetterAuthor> LetterAuthor { get; set; }
        public DbSet<Notification> Notification { get; set; }
        public DbSet<Payments> Payments { get; set; }
        public DbSet<PaymentsDuties> PaymentsDuties { get; set; }
        public DbSet<EmployeeData> EmployeeData { get; set; }
        public DbSet<Patents> Patent { get; set; }
        public DbSet<BidAuthor> BidAuthor { get; set; }
        public DbSet<BidPayments> BidPayments { get; set; }
        public DbSet<BidNotification> BidNotification { get; set; }
        public DbSet<PatentAgreement> PatentAgreement { get; set; }
        public DbSet<PatentLetterAuthor> PatentLetterAuthors { get; set; }
        public DbSet<PatentPaymentsDuties> PatentPaymentsDuties{ get; set; }
        public DbSet<PatentAuthors> PatentAuthors { get; set; }

        public ApplicationContext() 
        {
            Database.EnsureCreated();
            //Database.Migrate();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=dbD;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
    }
}
