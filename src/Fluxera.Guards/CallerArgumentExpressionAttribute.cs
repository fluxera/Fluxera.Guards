// ReSharper disable once CheckNamespace

namespace System.Runtime.CompilerServices
{
	using JetBrains.Annotations;

#if !NET5_0_OR_GREATER

	/// <summary>
	///     An attribute that allows parameters to receive the expression of other parameters.
	/// </summary>
	/// <remarks>Internal copy from the BCL attribute.</remarks>
	[AttributeUsage(AttributeTargets.Parameter)]
	internal sealed class CallerArgumentExpressionAttribute : Attribute
	{
		/// <summary>
		///     Creates a new instance of the <see cref="CallerArgumentExpressionAttribute" /> type.
		/// </summary>
		/// <param name="parameterName">The condition parameter value.</param>
		public CallerArgumentExpressionAttribute(string parameterName)
		{
			this.ParameterName = parameterName;
		}

		/// <summary>
		///     Gets the parameter name the expression is retrieved from.
		/// </summary>
		[UsedImplicitly]
		public string ParameterName { get; }
	}

#endif
}
