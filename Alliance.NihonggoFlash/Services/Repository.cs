using Alliance.NihonggoFlash.Models;
using SQLite.CodeFirst;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alliance.NihonggoFlash.Services
{
    public interface IRepository
    {
        IDbSet<FlashCard> Cards { get; }
    }

    public sealed class Repository : DbContext, IRepository
    {       

        public IDbSet<FlashCard> Cards { get; private set; }

        public Repository()
            : base("FlashCardsDb")
        {
            Cards = Set<FlashCard>();
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
            // read from InitData.csv
            var cards = context.Cards;

            using (var reader = System.IO.File.OpenText("InitData.csv"))
            {
                var csv = new CsvHelper.CsvReader(reader);

                if (!SimpleIoc.Default.GetInstance<RetrieveDataFromOnline>().RetrieveData())
                {
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
            }
            cards.Add(new FlashCard
            {
                HowToRead = "ひるまがあたたかい",
                Word = "昼間が暖かい",
                Meaning = "It's warm in the daytime",
                Sample = "NA"
            });
            context.SaveChanges();
            base.Seed(context);
        }
    }
}
