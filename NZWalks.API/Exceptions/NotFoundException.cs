namespace NZWalks.API.Exceptions
{
    public class NotFoundException:Exception
    {
        private readonly string message;
        public NotFoundException(string message):base(message)
        {    
            this.message = message;
        }

    }
}
