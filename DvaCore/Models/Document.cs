namespace DvaCore.Models
{
    public class Document
    {
        public Document(string name)
        {
            Name = name;
        }

        public string Name { get; set; }


        public override bool Equals(object obj)
        {
            var otherDoc = (Document) obj;

            return Name.Equals(otherDoc.Name);
        }
    }
}