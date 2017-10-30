using Newtonsoft.Json;

namespace DvaCore.Models
{
    [JsonObject]
    public class RatedDocument : Document
    {
        /// <summary>
        /// Constructor for RatedDocument
        /// </summary>
        /// <param name="name">Name of the document</param>
        /// <param name="labeledClassifier">Describes wether the document is labeled as deceptive</param>
        /// <param name="ourClassifier">Describes wether our algorithm detects the document as deceptive</param>
        public RatedDocument(string name, bool labeledClassifier, bool ourClassifier) : base(name)
        {
            LabeledClassifier = labeledClassifier;
            OurClassifier = ourClassifier;
        }

        /// <summary>
        /// If this is true the source says that the rating is deceptive
        /// </summary>
        public bool LabeledClassifier { get; set; }     

        /// <summary>
        /// If this is true our algorithm says that the rating is deceptive
        /// </summary>
        public bool OurClassifier { get; set; }         

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