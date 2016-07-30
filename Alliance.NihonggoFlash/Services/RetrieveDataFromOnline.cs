using Alliance.NihonggoFlash.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Alliance.NihonggoFlash.Services
{
    public class RetrieveDataFromOnline
    {
        public void RetrieveData()
        {
            try
            {
                var request = WebRequest.Create(Properties.Settings.Default.FlashCardUpdateUrl);
                request.Method = "GET";
                var response = request.GetResponse();
                using (var reader = new System.IO.StreamReader(response.GetResponseStream()))
                {
                    var db = SimpleIoc.Default.GetInstance<Repository>();
                    var responseStr = reader.ReadToEnd();
                    var cards = Newtonsoft.Json.JsonConvert.DeserializeObject<List<FlashCard>>(responseStr);

                    if (cards.Count > 0)
                    {
                        db.Database.ExecuteSqlCommand("delete from Cards");
                        foreach (var card in cards)
                        {
                            db.Cards.Add(card);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                // dunno what to do here yet                
            }
        }
    }
}
