﻿namespace Fluxera.Guards
{
	using System;
	using System.Numerics;
	using System.Runtime.CompilerServices;
	using JetBrains.Annotations;
	using static ExceptionHelpers;

	/// <summary>
	///     Contains common numeric guard extensions methods.
	/// </summary>
	[PublicAPI]
	public static class GuardAgainstNegativeExtensions
	{
		/// <summary>
		///     Throws an <see cref="ArgumentException" /> if <paramref name="input" /> is negative.
		/// </summary>
		/// <param name="guard">The extension endpoint.</param>
		/// <param name="input">The value of the input.</param>
		/// <param name="parameterName">The name of the input parameter.</param>
		/// <param name="message">The optional custom error message.</param>
		/// <returns>The <paramref name="input" />, if the checks were successful.</returns>
		/// <exception cref="ArgumentException">Thrown if <paramref name="input" /> is negative.</exception>
		public static T Negative<T>(this IGuard guard, T input, [InvokerParameterName] [CallerArgumentExpression(nameof(input))] string parameterName = null, string message = null) where T : INumber<T>
		{
			ArgumentNullException.ThrowIfNull(guard);

			if(T.IsNegative(input))
			{
				throw CreateArgumentException(parameterName, message ?? "Value cannot be negative.");
			}

			return input;
		}

		/// <summary>
		///     Throws an <see cref="ArgumentException" /> if <paramref name="input" /> is negative.
		/// </summary>
		/// <param name="guard">The extension endpoint.</param>
		/// <param name="input">The value of the input.</param>
		/// <param name="parameterName">The name of the input parameter.</param>
		/// <param name="message">The optional custom error message.</param>
		/// <returns>The <paramref name="input" />, if the checks were successful.</returns>
		/// <exception cref="ArgumentException">Thrown if <paramref name="input" /> is negative.</exception>
		public static TimeSpan Negative(this IGuard guard, TimeSpan input, [InvokerParameterName] [CallerArgumentExpression(nameof(input))] string parameterName = null, string message = null)
		{
			ArgumentNullException.ThrowIfNull(guard);

			if(input < TimeSpan.Zero)
			{
				throw CreateArgumentException(parameterName, message ?? "Value cannot be negative.");
			}

			return input;
		}
	}
}
