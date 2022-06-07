namespace Fluxera.Guards
{
	using System;
	using System.ComponentModel;
	using JetBrains.Annotations;

	/// <summary>
	///     Helpers to create the exception instances.
	/// </summary>
	[PublicAPI]
	public static class ExceptionHelpers
	{
		private const string MissingParameterName = "(missing param)";

		/// <summary>
		///     Helper to create an instance of <see cref="ArgumentNullException" />.
		/// </summary>
		public static ArgumentNullException CreateArgumentNullException(string parameterName, string message)
		{
			parameterName = EnsureParameterName(parameterName);

			return string.IsNullOrWhiteSpace(message)
				? new ArgumentNullException(parameterName)
				: new ArgumentNullException(parameterName, message);
		}

		/// <summary>
		///     Helper to create an instance of <see cref="ArgumentException" />.
		/// </summary>
		public static ArgumentException CreateArgumentException(string parameterName, string message)
		{
			parameterName = EnsureParameterName(parameterName);

			return string.IsNullOrWhiteSpace(message)
				? new ArgumentException(null, parameterName)
				: new ArgumentException(message, parameterName);
		}

		/// <summary>
		///     Helper to create an instance of <see cref="ArgumentOutOfRangeException" />.
		/// </summary>
		public static ArgumentOutOfRangeException CreateArgumentOutOfRangeException(string parameterName, string message)
		{
			parameterName = EnsureParameterName(parameterName);

			return string.IsNullOrWhiteSpace(message)
				? new ArgumentOutOfRangeException(parameterName)
				: new ArgumentOutOfRangeException(parameterName, message);
		}

		/// <summary>
		///     Helper to create an instance of <see cref="InvalidEnumArgumentException" />.
		/// </summary>
		public static InvalidEnumArgumentException CreateInvalidEnumArgumentException<T>(T input, string parameterName, string message)
			where T : struct, Enum
		{
			parameterName = EnsureParameterName(parameterName);

			return string.IsNullOrWhiteSpace(message)
				? new InvalidEnumArgumentException(parameterName, Convert.ToInt32(input), typeof(T))
				: new InvalidEnumArgumentException(message);
		}

		/// <summary>
		///     Helper to create an instance of <see cref="InvalidEnumArgumentException" />.
		/// </summary>
		public static InvalidEnumArgumentException CreateInvalidEnumArgumentException<T>(int input, string parameterName, string message)
			where T : struct, Enum
		{
			parameterName = EnsureParameterName(parameterName);

			return string.IsNullOrWhiteSpace(message)
				? new InvalidEnumArgumentException(parameterName, input, typeof(T))
				: new InvalidEnumArgumentException(message);
		}

		/// <summary>
		///     Ensures that the parameter name will always have a value.
		/// </summary>
		public static string EnsureParameterName(string parameterName)
		{
			if(string.IsNullOrWhiteSpace(parameterName))
			{
				parameterName = MissingParameterName;
			}

			return parameterName;
		}
	}
}
