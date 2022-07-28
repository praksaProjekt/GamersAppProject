namespace GamersApp.DTO
{
    public class CustomException : Exception
    {
        public int StatusCode { get; }

        public CustomException(string Message, int Code) : base(Message) 
        {
            StatusCode = Code;
        }
    }
}



