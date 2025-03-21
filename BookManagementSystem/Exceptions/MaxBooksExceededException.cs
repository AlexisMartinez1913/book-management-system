namespace BookManagementSystem.Exceptions
{
    public class MaxBooksExceededException : Exception
    {
        //Excepciones personalizadas
        public MaxBooksExceededException(string message) : base(message) 
        { 

        }
    }
}
