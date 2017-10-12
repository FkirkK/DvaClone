namespace DvaCore.Models
{
    public class Document
    {
        /// <summary>
        /// Constructor for the Document class
        /// </summary>
        /// <param name="name">Name of the document</param>
        public Document(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Name of the document
        /// </summary>
        public string Name { get; set; }

        public override bool Equals(object obj)
        {
            var otherDoc = (Document) obj;

            return Name.Equals(otherDoc.Name);
        }
    }
}