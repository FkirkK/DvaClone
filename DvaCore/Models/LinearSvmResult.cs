namespace DvaCore.Models
{
    public class LinearSvmResult
    {
        private int _id;

        public LinearSvmResult(int id)
        {
            _id = id;
        }

        public override bool Equals(object obj)
        {
            LinearSvmResult linearSvmResult = (LinearSvmResult) obj;
            
            return linearSvmResult._id == _id;
        }
    }
}