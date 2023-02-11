namespace RecipeApp.Domain.Exceptions
{
    public class RoboflowApiException : Exception
    {
        private const string MESSAGE = "An exception occurred during sending request to RoboflowAPI";

        public RoboflowApiException()
            : base(MESSAGE) { }

        public RoboflowApiException(string message)
            : base(message) { }
    }
}
