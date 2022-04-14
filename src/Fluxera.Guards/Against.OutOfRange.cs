namespace Fluxera.Guards
{
	using System;
	using System.ComponentModel;
	using JetBrains.Annotations;
	using static ExceptionHelpers;

	/// <summary>
	///     Contains common range guard extensions methods.
	/// </summary>
	[PublicAPI]
	public static class GuardAgainstOutOfRangeExtensions
	{
		/// <summary>
		///     Throws an <see cref="ArgumentException" /> if <paramref name="from" /> &gt; <paramref name="to" />. <br />
		///     Throws an <see cref="ArgumentOutOfRangeException" /> if <paramref name="input" /> &lt; <paramref name="from" /> or
		///     <paramref name="input" /> &gt; <paramref name="to" />.
		/// </summary>
		/// <typeparam name="T">The type of the input.</typeparam>
		/// <param name="guard">The extension endpoint.</param>
		/// <param name="input">The value of the input.</param>
		/// <param name="parameterName">The name of the input parameter.</param>
		/// <param name="from">The lower bound.</param>
		/// <param name="to">The upper bound.</param>
		/// <param name="message">The optional custom error message.</param>
		/// <returns>The <paramref name="input" />, if the checks were successful.</returns>
		/// <exception cref="ArgumentException">Thrown if <paramref name="from" /> &gt; <paramref name="to" />.</exception>
		/// <exception cref="ArgumentOutOfRangeException">
		///     Thrown if <paramref name="input" /> &lt; <paramref name="from" /> or
		///     <paramref name="input" /> &gt; <paramref name="to" />.
		/// </exception>
		public static T OutOfRange<T>(this IGuard guard, T input, [InvokerParameterName] string parameterName, T from, T to, string message = null)
			where T : IComparable, IComparable<T>
		{
			if(from.CompareTo(to) > 0)
			{
				throw CreateArgumentException(parameterName, message ?? "Value of the lower bound cannot be less or equal then the upper bound.");
			}

			if((input.CompareTo(from) < 0) || (input.CompareTo(to) > 0))
			{
				throw CreateArgumentOutOfRangeException(parameterName, message);
			}

			return input;
		}

		/// <summary>
		///     Throws an <see cref="InvalidEnumArgumentException" /> if <paramref name="input" /> is not a valid enum value.
		/// </summary>
		/// <typeparam name="T">The type of the input.</typeparam>
		/// <param name="guard">The extension endpoint.</param>
		/// <param name="input">The value of the input.</param>
		/// <param name="parameterName">The name of the input parameter.</param>
		/// <param name="message">The optional custom error message.</param>
		/// <returns>The <paramref name="input" />, if the checks were successful.</returns>
		/// <exception cref="InvalidEnumArgumentException">Thrown if <paramref name="input" /> is not a valid enum value.</exception>
		public static T OutOfRange<T>(this IGuard guard, T input, [InvokerParameterName] string parameterName, string message = null)
			where T : struct, Enum
		{
			if(!Enum.IsDefined(typeof(T), input))
			{
				throw CreateInvalidEnumArgumentException(input, parameterName, message);
			}

			return input;
		}

		/// <summary>
		///     Throws an <see cref="InvalidEnumArgumentException" /> if <paramref name="input" /> is not a valid enum value.
		/// </summary>
		/// <typeparam name="T">The type of the input.</typeparam>
		/// <param name="guard">The extension endpoint.</param>
		/// <param name="input">The value of the input.</param>
		/// <param name="parameterName">The name of the input parameter.</param>
		/// <param name="message">The optional custom error message.</param>
		/// <returns>The <paramref name="input" />, if the checks were successful.</returns>
		/// <exception cref="InvalidEnumArgumentException">Thrown if <paramref name="input" /> is not a valid enum value.</exception>
		public static int OutOfRange<T>(this IGuard guard, int input, [InvokerParameterName] string parameterName, string message = null)
			where T : struct, Enum
		{
			if(!Enum.IsDefined(typeof(T), input))
			{
				throw CreateInvalidEnumArgumentException<T>(input, parameterName, message);
			}

			return input;
		}
	}
}
