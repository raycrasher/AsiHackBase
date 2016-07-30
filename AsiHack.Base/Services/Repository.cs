using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AsiHack.Base.Models;
using System.Data.Entity;
using SQLite.CodeFirst;

namespace AsiHack.Base.Services
{

    public sealed class Repository : DbContext
    {

        public IDbSet<FlashCard> Cards { get; private set; }
        public IDbSet<User> Users { get; private set; }

        public Repository()
            : base("FlashCardsDb")
        {
            Cards = Set<FlashCard>();
            Users = Set<User>();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var sqliteConnectionInitializer = new FlashCardDbContextInitializer(modelBuilder);
            Database.SetInitializer(sqliteConnectionInitializer);
        }
    }

    public class FlashCardDbContextInitializer : SqliteCreateDatabaseIfNotExists<Repository>
    {
        public FlashCardDbContextInitializer(DbModelBuilder modelBuilder)
            : base(modelBuilder) { }

        protected override void Seed(Repository context)
        {
            var cards = context.Cards;

            using (var reader = System.IO.File.OpenText(AppDomain.CurrentDomain.BaseDirectory.ToString() +  "/cards.csv"))
            {
                var csv = new CsvHelper.CsvReader(reader);

                while (csv.Read())
                {
                    string word, howToRead, meaning, sample;

                    csv.TryGetField(0, out word);
                    csv.TryGetField(1, out howToRead);
                    csv.TryGetField(2, out meaning);
                    csv.TryGetField(3, out sample);
                    var card = new FlashCard
                    {
                        Word = word,
                        HowToRead = howToRead,
                        Meaning = meaning,
                        Sample = sample
                    };
                    cards.Add(card);
                }
            }


            // add data here
            /*
            var cards = context.Cards;
            
            cards.Add(new FlashCard
            {
                HowToRead = "ひるまがあたたかい",
                Word = "昼間が暖かい",
                Meaning = "It's warm in the daytime",
                Sample = "NA"
            });
            */
            context.SaveChanges();
            base.Seed(context);
        }
    }
}