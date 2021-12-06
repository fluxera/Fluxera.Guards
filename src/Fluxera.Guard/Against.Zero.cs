namespace Fluxera.Guard
{
	using System;
	using System.Collections.Generic;
	using JetBrains.Annotations;
	using static ExceptionHelpers;

	/// <summary>
	///     Contains common numeric guard extensions methods.
	/// </summary>
	[PublicAPI]
	public static class GuardAgainstZeroExtensions
	{
		/// <summary>
		///     Throws an <see cref="ArgumentException" /> if <paramref name="input" /> is zero.
		/// </summary>
		/// <param name="guard">The extension endpoint.</param>
		/// <param name="input">The value of the input.</param>
		/// <param name="parameterName">The name of the input parameter.</param>
		/// <param name="message">The optional custom error message.</param>
		/// <returns>The <paramref name="input" />, if the checks were successful.</returns>
		/// <exception cref="ArgumentException">Thrown if <paramref name="input" /> is zero.</exception>
		public static byte Zero(this IGuard guard, byte input, [InvokerParameterName] string parameterName, string? message = null)
		{
			return Zero(input, parameterName, message);
		}

		/// <summary>
		///     Throws an <see cref="ArgumentException" /> if <paramref name="input" /> is zero.
		/// </summary>
		/// <param name="guard">The extension endpoint.</param>
		/// <param name="input">The value of the input.</param>
		/// <param name="parameterName">The name of the input parameter.</param>
		/// <param name="message">The optional custom error message.</param>
		/// <returns>The <paramref name="input" />, if the checks were successful.</returns>
		/// <exception cref="ArgumentException">Thrown if <paramref name="input" /> is zero.</exception>
		public static short Zero(this IGuard guard, short input, [InvokerParameterName] string parameterName, string? message = null)
		{
			return Zero(input, parameterName, message);
		}

		/// <summary>
		///     Throws an <see cref="ArgumentException" /> if <paramref name="input" /> is zero.
		/// </summary>
		/// <param name="guard">The extension endpoint.</param>
		/// <param name="input">The value of the input.</param>
		/// <param name="parameterName">The name of the input parameter.</param>
		/// <param name="message">The optional custom error message.</param>
		/// <returns>The <paramref name="input" />, if the checks were successful.</returns>
		/// <exception cref="ArgumentException">Thrown if <paramref name="input" /> is zero.</exception>
		public static int Zero(this IGuard guard, int input, [InvokerParameterName] string parameterName, string? message = null)
		{
			return Zero(input, parameterName, message);
		}

		/// <summary>
		///     Throws an <see cref="ArgumentException" /> if <paramref name="input" /> is zero.
		/// </summary>
		/// <param name="guard">The extension endpoint.</param>
		/// <param name="input">The value of the input.</param>
		/// <param name="parameterName">The name of the input parameter.</param>
		/// <param name="message">The optional custom error message.</param>
		/// <returns>The <paramref name="input" />, if the checks were successful.</returns>
		/// <exception cref="ArgumentException">Thrown if <paramref name="input" /> is zero.</exception>
		public static long Zero(this IGuard guard, long input, [InvokerParameterName] string parameterName, string? message = null)
		{
			return Zero(input, parameterName, message);
		}

		/// <summary>
		///     Throws an <see cref="ArgumentException" /> if <paramref name="input" /> is zero.
		/// </summary>
		/// <param name="guard">The extension endpoint.</param>
		/// <param name="input">The value of the input.</param>
		/// <param name="parameterName">The name of the input parameter.</param>
		/// <param name="message">The optional custom error message.</param>
		/// <returns>The <paramref name="input" />, if the checks were successful.</returns>
		/// <exception cref="ArgumentException">Thrown if <paramref name="input" /> is zero.</exception>
		public static decimal Zero(this IGuard guard, decimal input, [InvokerParameterName] string parameterName, string? message = null)
		{
			return Zero(input, parameterName, message);
		}

		/// <summary>
		///     Throws an <see cref="ArgumentException" /> if <paramref name="input" /> is zero.
		/// </summary>
		/// <param name="guard">The extension endpoint.</param>
		/// <param name="input">The value of the input.</param>
		/// <param name="parameterName">The name of the input parameter.</param>
		/// <param name="message">The optional custom error message.</param>
		/// <returns>The <paramref name="input" />, if the checks were successful.</returns>
		/// <exception cref="ArgumentException">Thrown if <paramref name="input" /> is zero.</exception>
		public static float Zero(this IGuard guard, float input, [InvokerParameterName] string parameterName, string? message = null)
		{
			return Zero(input, parameterName, message);
		}

		/// <summary>
		///     Throws an <see cref="ArgumentException" /> if <paramref name="input" /> is zero.
		/// </summary>
		/// <param name="guard">The extension endpoint.</param>
		/// <param name="input">The value of the input.</param>
		/// <param name="parameterName">The name of the input parameter.</param>
		/// <param name="message">The optional custom error message.</param>
		/// <returns>The <paramref name="input" />, if the checks were successful.</returns>
		/// <exception cref="ArgumentException">Thrown if <paramref name="input" /> is zero.</exception>
		public static double Zero(this IGuard guard, double input, [InvokerParameterName] string parameterName, string? message = null)
		{
			return Zero(input, parameterName, message);
		}

		/// <summary>
		///     Throws an <see cref="ArgumentException" /> if <paramref name="input" /> is zero.
		/// </summary>
		/// <param name="guard">The extension endpoint.</param>
		/// <param name="input">The value of the input.</param>
		/// <param name="parameterName">The name of the input parameter.</param>
		/// <param name="message">The optional custom error message.</param>
		/// <returns>The <paramref name="input" />, if the checks were successful.</returns>
		/// <exception cref="ArgumentException">Thrown if <paramref name="input" /> is zero.</exception>
		public static TimeSpan Zero(this IGuard guard, TimeSpan input, [InvokerParameterName] string parameterName, string? message = null)
		{
			return Zero(input, parameterName, message);
		}

		/// <summary>
		///     Checks if the input is zero.
		/// </summary>
		private static T Zero<T>(T input, string parameterName, string? message = null)
			where T : struct, IComparable, IComparable<T>
		{
			if(EqualityComparer<T>.Default.Equals(input, default))
			{
				throw CreateArgumentException(parameterName, message ?? "Value cannot be zero.");
			}

			return input;
		}
	}
}
