namespace Fluxera.Guard.UnitTests
{
	using System;
	using FluentAssertions;
	using NUnit.Framework;

	[TestFixture]
	public class CustomGuardTests
	{
		[Test]
		public void ShouldThrowWhenHello()
		{
			Action action = () => Guard.Against.Hello("hello", "parameter");
			action.Should().Throw<ArgumentException>();
		}

		[Test]
		public void ShouldNotThrowWhenAnythingElse()
		{
			Guard.Against.Hello("world", "parameter");
		}
	}
}
