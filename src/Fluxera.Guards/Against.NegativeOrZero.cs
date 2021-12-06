namespace Fluxera.Guards
{
	using System;
	using JetBrains.Annotations;
	using static ExceptionHelpers;

	/// <summary>
	///     Contains common numeric guard extensions methods.
	/// </summary>
	[PublicAPI]
	public static class GuardAgainstNegativeOrZeroExtensions
	{
		/// <summary>
		///     Throws an <see cref="ArgumentException" /> if <paramref name="input" /> is negative or zero.
		/// </summary>
		/// <param name="guard">The extension endpoint.</param>
		/// <param name="input">The value of the input.</param>
		/// <param name="parameterName">The name of the input parameter.</param>
		/// <param name="message">The optional custom error message.</param>
		/// <returns>The <paramref name="input" />, if the checks were successful.</returns>
		/// <exception cref="ArgumentException">Thrown if <paramref name="input" /> is negative or zero.</exception>
		public static byte NegativeOrZero(this IGuard guard, byte input, [InvokerParameterName] string parameterName, string? message = null)
		{
			return NegativeOrZero(input, parameterName, message);
		}

		/// <summary>
		///     Throws an <see cref="ArgumentException" /> if <paramref name="input" /> is negative or zero.
		/// </summary>
		/// <param name="guard">The extension endpoint.</param>
		/// <param name="input">The value of the input.</param>
		/// <param name="parameterName">The name of the input parameter.</param>
		/// <param name="message">The optional custom error message.</param>
		/// <returns>The <paramref name="input" />, if the checks were successful.</returns>
		/// <exception cref="ArgumentException">Thrown if <paramref name="input" /> is negative or zero.</exception>
		public static short NegativeOrZero(this IGuard guard, short input, [InvokerParameterName] string parameterName, string? message = null)
		{
			return NegativeOrZero(input, parameterName, message);
		}

		/// <summary>
		///     Throws an <see cref="ArgumentException" /> if <paramref name="input" /> is negative or zero.
		/// </summary>
		/// <param name="guard">The extension endpoint.</param>
		/// <param name="input">The value of the input.</param>
		/// <param name="parameterName">The name of the input parameter.</param>
		/// <param name="message">The optional custom error message.</param>
		/// <returns>The <paramref name="input" />, if the checks were successful.</returns>
		/// <exception cref="ArgumentException">Thrown if <paramref name="input" /> is negative or zero.</exception>
		public static int NegativeOrZero(this IGuard guard, int input, [InvokerParameterName] string parameterName, string? message = null)
		{
			return NegativeOrZero(input, parameterName, message);
		}

		/// <summary>
		///     Throws an <see cref="ArgumentException" /> if <paramref name="input" /> is negative or zero.
		/// </summary>
		/// <param name="guard">The extension endpoint.</param>
		/// <param name="input">The value of the input.</param>
		/// <param name="parameterName">The name of the input parameter.</param>
		/// <param name="message">The optional custom error message.</param>
		/// <returns>The <paramref name="input" />, if the checks were successful.</returns>
		/// <exception cref="ArgumentException">Thrown if <paramref name="input" /> is negative or zero.</exception>
		public static long NegativeOrZero(this IGuard guard, long input, [InvokerParameterName] string parameterName, string? message = null)
		{
			return NegativeOrZero(input, parameterName, message);
		}

		/// <summary>
		///     Throws an <see cref="ArgumentException" /> if <paramref name="input" /> is negative or zero.
		/// </summary>
		/// <param name="guard">The extension endpoint.</param>
		/// <param name="input">The value of the input.</param>
		/// <param name="parameterName">The name of the input parameter.</param>
		/// <param name="message">The optional custom error message.</param>
		/// <returns>The <paramref name="input" />, if the checks were successful.</returns>
		/// <exception cref="ArgumentException">Thrown if <paramref name="input" /> is negative or zero.</exception>
		public static decimal NegativeOrZero(this IGuard guard, decimal input, [InvokerParameterName] string parameterName, string? message = null)
		{
			return NegativeOrZero(input, parameterName, message);
		}

		/// <summary>
		///     Throws an <see cref="ArgumentException" /> if <paramref name="input" /> is negative or zero.
		/// </summary>
		/// <param name="guard">The extension endpoint.</param>
		/// <param name="input">The value of the input.</param>
		/// <param name="parameterName">The name of the input parameter.</param>
		/// <param name="message">The optional custom error message.</param>
		/// <returns>The <paramref name="input" />, if the checks were successful.</returns>
		/// <exception cref="ArgumentException">Thrown if <paramref name="input" /> is negative or zero.</exception>
		public static float NegativeOrZero(this IGuard guard, float input, [InvokerParameterName] string parameterName, string? message = null)
		{
			return NegativeOrZero(input, parameterName, message);
		}

		/// <summary>
		///     Throws an <see cref="ArgumentException" /> if <paramref name="input" /> is negative or zero.
		/// </summary>
		/// <param name="guard">The extension endpoint.</param>
		/// <param name="input">The value of the input.</param>
		/// <param name="parameterName">The name of the input parameter.</param>
		/// <param name="message">The optional custom error message.</param>
		/// <returns>The <paramref name="input" />, if the checks were successful.</returns>
		/// <exception cref="ArgumentException">Thrown if <paramref name="input" /> is negative or zero.</exception>
		public static double NegativeOrZero(this IGuard guard, double input, [InvokerParameterName] string parameterName, string? message = null)
		{
			return NegativeOrZero(input, parameterName, message);
		}

		/// <summary>
		///     Throws an <see cref="ArgumentException" /> if <paramref name="input" /> is negative or zero.
		/// </summary>
		/// <param name="guard">The extension endpoint.</param>
		/// <param name="input">The value of the input.</param>
		/// <param name="parameterName">The name of the input parameter.</param>
		/// <param name="message">The optional custom error message.</param>
		/// <returns>The <paramref name="input" />, if the checks were successful.</returns>
		/// <exception cref="ArgumentException">Thrown if <paramref name="input" /> is negative or zero.</exception>
		public static TimeSpan NegativeOrZero(this IGuard guard, TimeSpan input, [InvokerParameterName] string parameterName, string? message = null)
		{
			return NegativeOrZero(input, parameterName, message);
		}

		/// <summary>
		///     Checks if the input is negative or zero.
		/// </summary>
		private static T NegativeOrZero<T>(T input, string parameterName, string? message = null) 
			where T : struct, IComparable, IComparable<T>
		{
			if (input.CompareTo(default) <= 0)
			{
				throw CreateArgumentException(parameterName, message ?? "Value cannot be negative or zero.");
			}

			return input;
		}
	}
}
