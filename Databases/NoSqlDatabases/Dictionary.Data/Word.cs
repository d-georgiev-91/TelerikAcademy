using System;
using System.Linq;
using MongoDB.Bson;

namespace Dictionary.Data
{
    
    public class Word
    {
        public ObjectId _id { get; set; }

        public string Reperesentation { get; set; }

        public string Translation { get; set; }

        public Word(string representation, string translation)
        {
            this.Reperesentation = representation;
            this.Translation = translation;
        }
    }
}