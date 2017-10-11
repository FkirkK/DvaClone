namespace DvaCore.Models
{
    public class RatedDocument : Document
    {
        public RatedDocument(string name, bool labeledClassifier, bool ourClassifier) : base(name)
        {
            LabeledClassifier = labeledClassifier;
            OurClassifier = ourClassifier;
        }

        public bool LabeledClassifier { get; set; } //If this is true the source says that the rating is deceptive

        public bool OurClassifier { get; set; } //If this is true our algorithm says that the rating is deceptive

        public override bool Equals(object obj)
        {
            var otherDoc = (RatedDocument) obj;
            var isSame = true;

            isSame &= LabeledClassifier.Equals(otherDoc.LabeledClassifier);
            isSame &= OurClassifier.Equals(otherDoc.OurClassifier);
            isSame &= base.Equals(obj);

            return isSame;
        }
    }
}