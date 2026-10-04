namespace Haveno.Exceptions;

public class HavenoException : Exception
{
    public HavenoException(string message) : base(message)
    {
    }

    public HavenoException(string message, Exception inner) : base(message, inner)
    {
    }
}
