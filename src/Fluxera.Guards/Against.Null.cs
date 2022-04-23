namespace Fluxera.Guards
{
	using System;
	using System.Collections.Generic;
	using System.Diagnostics;
	using System.Linq;
	using System.Runtime.CompilerServices;
	using JetBrains.Annotations;
	using static ExceptionHelpers;

	/// <summary>
	///     Contains common null-checking guard extensions methods.
	/// </summary>
	[PublicAPI]
	public static class GuardAgainstNullExtensions
	{
		/// <summary>
		///     Throws an <see cref="ArgumentNullException" /> if <paramref name="input" /> is null.
		/// </summary>
		/// <typeparam name="T">The type of the input.</typeparam>
		/// <param name="guard">The extension endpoint.</param>
		/// <param name="input">The value of the input.</param>
		/// <param name="parameterName">The name of the input parameter.</param>
		/// <param name="message">The optional custom error message.</param>
		/// <returns>The <paramref name="input" />, if the checks were successful.</returns>
		/// <exception cref="ArgumentNullException">Thrown if <paramref name="input" /> is null.</exception>
		[DebuggerNonUserCode]
		[DebuggerStepThrough]
		[ContractAnnotation("input:null => halt")]
		public static T Null<T>(this IGuard guard, T input, [InvokerParameterName] [CallerArgumentExpression("input")] string parameterName = null, string message = null)
		{
			if(input is null)
			{
				throw CreateArgumentNullException(parameterName, message);
			}

			return input;
		}

		/// <summary>
		///     Throws an <see cref="ArgumentException" /> if <paramref name="input" /> is default for that type.
		/// </summary>
		/// <typeparam name="T">The type of the input.</typeparam>
		/// <param name="guard">The extension endpoint.</param>
		/// <param name="input">The value of the input.</param>
		/// <param name="parameterName">The name of the input parameter.</param>
		/// <param name="message">The optional custom error message.</param>
		/// <returns>The <paramref name="input" />, if the checks were successful.</returns>
		/// <exception cref="ArgumentException">Thrown if <paramref name="input" /> is default for that type.</exception>
		[DebuggerNonUserCode]
		[DebuggerStepThrough]
		[ContractAnnotation("input:null => halt")]
		public static T Default<T>(this IGuard guard, T input, [InvokerParameterName] [CallerArgumentExpression("input")] string parameterName = null, string message = null)
		{
			if(EqualityComparer<T>.Default.Equals(input, default!) || input is null)
			{
				throw CreateArgumentException(parameterName, message ?? "Value cannot be default.");
			}

			return input;
		}

		/// <summary>
		///     Throws an <see cref="ArgumentNullException" /> if <paramref name="input" /> is null. <br />
		///     Throws an <see cref="ArgumentException" /> if <paramref name="input" /> is an empty string.
		/// </summary>
		/// <param name="guard">The extension endpoint.</param>
		/// <param name="input">The value of the input.</param>
		/// <param name="parameterName">The name of the input parameter.</param>
		/// <param name="message">TThe optional custom error message.</param>
		/// <returns>The <paramref name="input" />, if the checks were successful.</returns>
		/// <exception cref="ArgumentNullException">Thrown if <paramref name="input" /> is null.</exception>
		/// <exception cref="ArgumentException">Thrown if <paramref name="input" /> is an empty string.</exception>
		[DebuggerNonUserCode]
		[DebuggerStepThrough]
		[ContractAnnotation("input:null => halt")]
		public static string NullOrEmpty(this IGuard guard, string input, [InvokerParameterName] [CallerArgumentExpression("input")] string parameterName = null, string message = null)
		{
			Guard.Against.Null(input, parameterName);
			if(string.IsNullOrEmpty(input))
			{
				throw CreateArgumentException(parameterName, message ?? "Value cannot be empty.");
			}

			return input;
		}

		/// <summary>
		///     Throws an <see cref="ArgumentNullException" /> if <paramref name="input" /> is null. <br />
		///     Throws an <see cref="ArgumentException" /> if <paramref name="input" /> is an empty or whitespace-only string.
		/// </summary>
		/// <param name="guard">The extension endpoint.</param>
		/// <param name="input">The value of the input.</param>
		/// <param name="parameterName">The name of the input parameter.</param>
		/// <param name="message">The optional custom error message.</param>
		/// <returns>The <paramref name="input" />, if the checks were successful.</returns>
		/// <exception cref="ArgumentNullException">Thrown if <paramref name="input" /> is null.</exception>
		/// <exception cref="ArgumentException">Thrown if <paramref name="input" /> is an empty or whitespace-only string.</exception>
		[DebuggerNonUserCode]
		[DebuggerStepThrough]
		[ContractAnnotation("input:null => halt")]
		public static string NullOrWhiteSpace(this IGuard guard, string input, [InvokerParameterName] [CallerArgumentExpression("input")] string parameterName = null, string message = null)
		{
			Guard.Against.NullOrEmpty(input, parameterName);
			if(string.IsNullOrWhiteSpace(input))
			{
				throw CreateArgumentException(parameterName, message ?? "Value cannot be whitespace-only.");
			}

			return input;
		}

		/// <summary>
		///     Throws an <see cref="ArgumentException" /> if <paramref name="input" /> is an empty guid.
		/// </summary>
		/// <param name="guard">The extension endpoint.</param>
		/// <param name="input">The value of the input.</param>
		/// <param name="parameterName">The name of the input parameter.</param>
		/// <param name="message">The optional custom error message.</param>
		/// <returns>The <paramref name="input" />, if the checks were successful.</returns>
		/// <exception cref="ArgumentException">Thrown if <paramref name="input" /> is an empty guid.</exception>
		[DebuggerNonUserCode]
		[DebuggerStepThrough]
		[ContractAnnotation("input:null => halt")]
		public static Guid Empty(this IGuard guard, Guid input, [InvokerParameterName] [CallerArgumentExpression("input")] string parameterName = null, string message = null)
		{
			if(input == Guid.Empty)
			{
				throw CreateArgumentException(parameterName, message ?? "Value cannot be empty.");
			}

			return input;
		}

		/// <summary>
		///     Throws an <see cref="ArgumentNullException" /> if <paramref name="input" /> is null. <br />
		///     Throws an <see cref="ArgumentException" /> if <paramref name="input" /> is an empty guid.
		/// </summary>
		/// <param name="guard">The extension endpoint.</param>
		/// <param name="input">The value of the input.</param>
		/// <param name="parameterName">The name of the input parameter.</param>
		/// <param name="message">The optional custom error message.</param>
		/// <returns>The <paramref name="input" />, if the checks were successful.</returns>
		/// <exception cref="ArgumentNullException">Thrown if <paramref name="input" /> is null.</exception>
		/// <exception cref="ArgumentException">Thrown if <paramref name="input" /> is an empty guid.</exception>
		[DebuggerNonUserCode]
		[DebuggerStepThrough]
		[ContractAnnotation("input:null => halt")]
		public static Guid NullOrEmpty(this IGuard guard, Guid? input, [InvokerParameterName] [CallerArgumentExpression("input")] string parameterName = null, string message = null)
		{
			Guard.Against.Null(input, parameterName);
			Guard.Against.Empty(input!.Value, parameterName);

			return input.Value;
		}

		/// <summary>
		///     Throws an <see cref="ArgumentNullException" /> if <paramref name="input" /> is null. <br />
		///     Throws an <see cref="ArgumentException" /> if <paramref name="input" /> is an empty enumerable.
		/// </summary>
		/// <param name="guard">The extension endpoint.</param>
		/// <param name="input">The value of the input's items.</param>
		/// <param name="parameterName">The name of the input parameter.</param>
		/// <param name="message">The optional custom error message.</param>
		/// <returns>The <paramref name="input" />, if the checks were successful.</returns>
		/// <exception cref="ArgumentNullException">Thrown if <paramref name="input" /> is null.</exception>
		/// <exception cref="ArgumentException">Thrown if <paramref name="input" /> is an empty enumerable.</exception>
		[DebuggerNonUserCode]
		[DebuggerStepThrough]
		[ContractAnnotation("input:null => halt")]
		public static IEnumerable<T> NullOrEmpty<T>(this IGuard guard, IEnumerable<T> input, [InvokerParameterName] [CallerArgumentExpression("input")] string parameterName = null, string message = null)
		{
			// ReSharper disable PossibleMultipleEnumeration
			Guard.Against.Null(input, parameterName);
			if(!input.Any())
			{
				throw CreateArgumentException(parameterName, message ?? "Enumerable cannot be empty.");
			}

			return input!;
			// ReSharper enable PossibleMultipleEnumeration
		}
	}
}
