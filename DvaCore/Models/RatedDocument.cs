namespace DvaCore.Models
{
    public class RatedDocument : Document
    {
        public RatedDocument(string name, bool deceptive, bool rating) : base(name)
        {
            Deceptive = deceptive;
            Rating = rating;
            
        }

        public bool Deceptive { get; set; }

        public bool Rating { get; set; }


        public override bool Equals(object obj)
        {
            var otherDoc = (RatedDocument) obj;
            var isSame = true;

            isSame &= Deceptive.Equals(otherDoc.Deceptive);
            isSame &= Rating.Equals(otherDoc.Rating);
            isSame &= base.Equals(obj);

            return isSame;
        }
    }
}