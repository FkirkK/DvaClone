namespace DvaAnalysis.Models
{
    public class ErrorResult : IResult
    {
        public string Message { get; }

        public ErrorResult(string message)
        {
            Message = message;
        }
    }
}