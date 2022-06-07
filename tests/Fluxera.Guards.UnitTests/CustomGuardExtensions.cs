// ReSharper disable once CheckNamespace

namespace Fluxera.Guards
{
	// Note: Using the namespace 'Fluxera.Guard' will ensure that your
	//       custom guard is available throughout your projects.

	using JetBrains.Annotations;
	using static ExceptionHelpers;

	public static class CustomGuardExtensions
	{
		public static void Hello(this IGuard guard, string input, [InvokerParameterName] string parameterName, string message = null)
		{
			if(input.ToLower() == "hello")
			{
				throw CreateArgumentException(parameterName, message);
			}
		}
	}
}
