using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AsiHack.Base.Models
{
    public class FlashCard
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Word { get; set; } = "TestWord";
        public string HowToRead { get; set; } = "TestRead";
        public string Meaning { get; set; } = "TestMeaning";
        public string Sample { get; set; } = "TestSample";
    }
}