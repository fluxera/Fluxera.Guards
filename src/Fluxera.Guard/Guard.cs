namespace Fluxera.Guard
{
	using JetBrains.Annotations;

	/// <summary>
	///     An entry point to all guard methods defined as extension methods on
	///		the <see cref="IGuard" /> interface.
	/// </summary>
	[PublicAPI]
	public sealed class Guard : IGuard
	{
		private Guard()
		{
		}

		/// <summary>
		///     An entry point to all defined guard methods.
		/// </summary>
		public static IGuard Against { get; } = new Guard();
	}
}
