namespace Application.Common.Errors;

public class DuplicateEmailException : Exception
{
	public DuplicateEmailException(string message) : base(message) { }
}
