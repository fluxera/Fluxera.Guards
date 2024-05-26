namespace Fluxera.Guards
{
	using System;
	using System.Diagnostics;
	using System.Runtime.CompilerServices;
	using System.Text.RegularExpressions;
	using JetBrains.Annotations;
	using static ExceptionHelpers;

	/// <summary>
	///     Contains common boolean predicate guard extensions methods.
	/// </summary>
	[PublicAPI]
	public static class GuardAgainstPredicateExtensions
	{
		/// <summary>
		///     Throws an <see cref="ArgumentException" /> if <paramref name="input" /> is false.
		/// </summary>
		/// <param name="guard">The extension endpoint.</param>
		/// <param name="input">The value of the input.</param>
		/// <param name="parameterName">The name of the input parameter.</param>
		/// <param name="message">The optional custom error message.</param>
		/// <returns>The <paramref name="input" />, if the checks were successful.</returns>
		/// <exception cref="ArgumentException">Thrown if <paramref name="input" /> is false.</exception>
		[DebuggerNonUserCode]
		[DebuggerStepThrough]
		[ContractAnnotation("input:false => halt")]
		public static bool False(this IGuard guard, bool input, [InvokerParameterName] [CallerArgumentExpression(nameof(input))] string parameterName = null, string message = null)
		{
			ArgumentNullException.ThrowIfNull(guard);

			if(!input)
			{
				throw CreateArgumentException(parameterName, message ?? "Value cannot be false.");
			}

			return true;
		}

		/// <summary>
		///     Throws an <see cref="ArgumentException" /> if <paramref name="input" /> is true.
		/// </summary>
		/// <param name="guard">The extension endpoint.</param>
		/// <param name="input">The value of the input.</param>
		/// <param name="parameterName">The name of the input parameter.</param>
		/// <param name="message">The optional custom error message.</param>
		/// <returns>The <paramref name="input" />, if the checks were successful.</returns>
		/// <exception cref="ArgumentException">Thrown if <paramref name="input" /> is true.</exception>
		[DebuggerNonUserCode]
		[DebuggerStepThrough]
		[ContractAnnotation("input:true => halt")]
		public static bool True(this IGuard guard, bool input, [InvokerParameterName] [CallerArgumentExpression(nameof(input))] string parameterName = null, string message = null)
		{
			ArgumentNullException.ThrowIfNull(guard);

			if(input)
			{
				throw CreateArgumentException(parameterName, message ?? "Value cannot be true.");
			}

			return false;
		}

		/// <summary>
		///     Throws an <see cref="ArgumentException" /> if <paramref name="input" /> doesn't satisfy the
		///     <paramref name="predicate" /> function.
		/// </summary>
		/// <typeparam name="T">The type of the input.</typeparam>
		/// <param name="guard">The extension endpoint.</param>
		/// <param name="input">The value of the input.</param>
		/// <param name="parameterName">The name of the input parameter.</param>
		/// <param name="predicate">The predicate function to satisfy.</param>
		/// <param name="message">The optional custom error message.</param>
		/// <returns>The <paramref name="input" />, if the checks were successful.</returns>
		/// <exception cref="ArgumentException">
		///     Thrown if <paramref name="input" /> doesn't satisfy the
		///     <paramref name="predicate" /> function.
		/// </exception>
		public static T InvalidInput<T>(this IGuard guard, T input, Predicate<T> predicate, [InvokerParameterName] [CallerArgumentExpression(nameof(input))] string parameterName = null, string message = null)
		{
			ArgumentNullException.ThrowIfNull(guard);

			if(!predicate(input))
			{
				throw CreateArgumentException(parameterName, message ?? "Value cannot be satisfy the predicate.");
			}

			return input;
		}

		/// <summary>
		///     Throws an <see cref="ArgumentException" /> if <paramref name="input" /> doesn't match the
		///     regular expression of <paramref name="regexPattern" />.
		/// </summary>
		/// <param name="guard">The extension endpoint.</param>
		/// <param name="input">The value of the input.</param>
		/// <param name="regexPattern">The regex pattern to match.</param>
		/// <param name="parameterName">The name of the input parameter.</param>
		/// <param name="message">The optional custom error message.</param>
		/// <returns>The <paramref name="input" />, if the checks were successful.</returns>
		/// <exception cref="ArgumentException">
		///     Thrown if <paramref name="input" /> doesn't match the
		///     <paramref name="regexPattern" />.
		/// </exception>
		public static string InvalidFormat(this IGuard guard, string input, [RegexPattern] string regexPattern, [InvokerParameterName] [CallerArgumentExpression(nameof(input))] string parameterName = null, string message = null)
		{
			ArgumentNullException.ThrowIfNull(guard);

			if(input != Regex.Match(input, regexPattern).Value)
			{
				throw CreateArgumentException(parameterName, message ?? "Value cannot be matched by the regex.");
			}

			return input;
		}
	}
}
