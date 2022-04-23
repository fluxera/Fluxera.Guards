namespace Fluxera.Guards.UnitTests
{
	using System;
	using FluentAssertions;
	using NUnit.Framework;

	[TestFixture]
	public class AgainstNegativeTests
	{
		[Test]
		public void ShouldNotThrowWhenPositive()
		{
			Guard.Against.Negative((byte)1, "byte");
			Guard.Against.Negative((short)1, "short");
			Guard.Against.Negative(1, "int");
			Guard.Against.Negative((long)1, "long");
			Guard.Against.Negative((decimal)1, "decimal");
			Guard.Against.Negative((float)1, "float");
			Guard.Against.Negative((double)1, "double");
			Guard.Against.Negative(TimeSpan.FromSeconds(1), "timespan");
		}

		[Test]
		public void ShouldNotThrowWhenZero()
		{
			Guard.Against.Negative((byte)0, "byte");
			Guard.Against.Negative((short)0, "short");
			Guard.Against.Negative(0, "int");
			Guard.Against.Negative((long)0, "long");
			Guard.Against.Negative((decimal)0, "decimal");
			Guard.Against.Negative((float)0, "float");
			Guard.Against.Negative((double)0, "double");
			Guard.Against.Negative(TimeSpan.Zero, "timespan");
		}

		[Test]
		public void ShouldReturnInputOnSuccess()
		{
			Guard.Against.Negative((byte)0, "byte").Should().Be(0);
			Guard.Against.Negative((byte)1, "byte").Should().Be(1);
			Guard.Against.Negative((short)0, "short").Should().Be(0);
			Guard.Against.Negative((short)1, "short").Should().Be(1);
			Guard.Against.Negative(0, "int").Should().Be(0);
			Guard.Against.Negative(1, "int").Should().Be(1);
			Guard.Against.Negative((long)0, "long").Should().Be(0);
			Guard.Against.Negative((long)1, "long").Should().Be(1);
			Guard.Against.Negative((decimal)0, "decimal").Should().Be(0);
			Guard.Against.Negative((decimal)1, "decimal").Should().Be(1);
			Guard.Against.Negative((float)0, "float").Should().Be(0);
			Guard.Against.Negative((float)1, "float").Should().Be(1);
			Guard.Against.Negative((double)0, "double").Should().Be(0);
			Guard.Against.Negative((double)1, "double").Should().Be(1);
			Guard.Against.Negative(TimeSpan.Zero, "timespan").Should().Be(TimeSpan.Zero);
			Guard.Against.Negative(TimeSpan.FromSeconds(1), "timespan").Should().Be(TimeSpan.FromSeconds(1));
		}

		[Test]
		public void ShouldThrowWhenNegative_WithCallerArgumentExpression()
		{
			int integer = -1;
			Action action = () => Guard.Against.Negative(integer);
			action.Should().Throw<ArgumentException>().WithParameterName("integer");
		}

		[Test]
		public void ShouldThrowWhenNegativeDecimal()
		{
			Action action = () => Guard.Against.Negative((decimal)-1, "decimal");
			action.Should().Throw<ArgumentException>().WithParameterName("decimal");
		}

		[Test]
		public void ShouldThrowWhenNegativeDouble()
		{
			Action action = () => Guard.Against.Negative((double)-1, "double");
			action.Should().Throw<ArgumentException>().WithParameterName("double");
		}

		[Test]
		public void ShouldThrowWhenNegativeFloat()
		{
			Action action = () => Guard.Against.Negative((float)-1, "float");
			action.Should().Throw<ArgumentException>().WithParameterName("float");
		}

		[Test]
		public void ShouldThrowWhenNegativeInt()
		{
			Action action = () => Guard.Against.Negative(-1, "int");
			action.Should().Throw<ArgumentException>().WithParameterName("int");
		}

		[Test]
		public void ShouldThrowWhenNegativeLong()
		{
			Action action = () => Guard.Against.Negative((long)-1, "long");
			action.Should().Throw<ArgumentException>().WithParameterName("long");
		}

		[Test]
		public void ShouldThrowWhenNegativeShort()
		{
			Action action = () => Guard.Against.Negative((short)-1, "short");
			action.Should().Throw<ArgumentException>().WithParameterName("short");
		}

		[Test]
		public void ShouldThrowWhenNegativeTimeSpan()
		{
			Action action = () => Guard.Against.Negative(TimeSpan.FromSeconds(-1), "timespan");
			action.Should().Throw<ArgumentException>().WithParameterName("timespan");
		}
	}
}
