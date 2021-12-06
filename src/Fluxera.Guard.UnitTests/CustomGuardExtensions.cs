namespace Fluxera.Guard.UnitTests
{
	using static ExceptionHelpers;

	public static class CustomGuardExtensions
	{
		public static void Hello(this IGuard guard, string input, string parameterName, string? message = null)
		{
			if(input.ToLower() == "hello")
			{
				throw CreateArgumentException(parameterName, message);
			}
		}
	}
}
