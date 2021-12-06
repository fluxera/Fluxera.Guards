namespace Fluxera.Guards.UnitTests
{
	using System;
	using FluentAssertions;
	using NUnit.Framework;

	[TestFixture]
	public class AgainstNegativeOrZeroTests
	{
		[Test]
		public void ShouldNotThrowWhenPositive()
		{
			Guard.Against.NegativeOrZero((byte)1, "byte");
			Guard.Against.NegativeOrZero((short)1, "short");
			Guard.Against.NegativeOrZero((int)1, "int");
			Guard.Against.NegativeOrZero((long)1, "long");
			Guard.Against.NegativeOrZero((decimal)1, "decimal");
			Guard.Against.NegativeOrZero((float)1, "float");
			Guard.Against.NegativeOrZero((double)1, "double");
			Guard.Against.NegativeOrZero(TimeSpan.FromSeconds(1), "timespan");
		}

		[Test]
		public void ShouldThrowWhenNegativeShort()
		{
			Action action = () => Guard.Against.NegativeOrZero((short)-1, "short");
			action.Should().Throw<ArgumentException>();
		}

		[Test]
		public void ShouldThrowWhenNegativeInt()
		{
			Action action = () => Guard.Against.NegativeOrZero((int)-1, "int");
			action.Should().Throw<ArgumentException>();
		}

		[Test]
		public void ShouldThrowWhenNegativeLong()
		{
			Action action = () => Guard.Against.NegativeOrZero((long)-1, "long");
			action.Should().Throw<ArgumentException>();
		}

		[Test]
		public void ShouldThrowWhenNegativeDecimal()
		{
			Action action = () => Guard.Against.NegativeOrZero((decimal)-1, "decimal");
			action.Should().Throw<ArgumentException>();
		}

		[Test]
		public void ShouldThrowWhenNegativeFloat()
		{
			Action action = () => Guard.Against.NegativeOrZero((float)-1, "float");
			action.Should().Throw<ArgumentException>();
		}

		[Test]
		public void ShouldThrowWhenNegativeDouble()
		{
			Action action = () => Guard.Against.NegativeOrZero((double)-1, "double");
			action.Should().Throw<ArgumentException>();
		}

		[Test]
		public void ShouldThrowWhenNegativeTimeSpan()
		{
			Action action = () => Guard.Against.NegativeOrZero(TimeSpan.FromSeconds(-1), "timespan");
			action.Should().Throw<ArgumentException>();
		}

		[Test]
		public void ShouldThrowWhenZeroByte()
		{
			Action action = () => Guard.Against.NegativeOrZero(byte.MinValue, "byte");
			action.Should().Throw<ArgumentException>();
		}

		[Test]
		public void ShouldThrowWhenZeroShort()
		{
			Action action = () => Guard.Against.NegativeOrZero((short)0, "short");
			action.Should().Throw<ArgumentException>();
		}

		[Test]
		public void ShouldThrowWhenZeroInt()
		{
			Action action = () => Guard.Against.NegativeOrZero((int)0, "int");
			action.Should().Throw<ArgumentException>();
		}

		[Test]
		public void ShouldThrowWhenZeroLong()
		{
			Action action = () => Guard.Against.NegativeOrZero((long)0, "long");
			action.Should().Throw<ArgumentException>();
		}

		[Test]
		public void ShouldThrowWhenZeroDecimal()
		{
			Action action = () => Guard.Against.NegativeOrZero((decimal)0, "decimal");
			action.Should().Throw<ArgumentException>();
		}

		[Test]
		public void ShouldThrowWhenZeroFloat()
		{
			Action action = () => Guard.Against.NegativeOrZero((float)0, "float");
			action.Should().Throw<ArgumentException>();
		}

		[Test]
		public void ShouldThrowWhenZeroDouble()
		{
			Action action = () => Guard.Against.NegativeOrZero((double)0, "double");
			action.Should().Throw<ArgumentException>();
		}

		[Test]
		public void ShouldThrowWhenZeroTimeSpan()
		{
			Action action = () => Guard.Against.NegativeOrZero(TimeSpan.Zero, "timespan");
			action.Should().Throw<ArgumentException>();
		}

		[Test]
		public void ShouldReturnInputOnSuccess()
		{
			Guard.Against.NegativeOrZero((byte)1, "byte").Should().Be((byte)1);
			Guard.Against.NegativeOrZero((short)1, "short").Should().Be((short)1);
			Guard.Against.NegativeOrZero((int)1, "int").Should().Be((int)1);
			Guard.Against.NegativeOrZero((long)1, "long").Should().Be((long)1);
			Guard.Against.NegativeOrZero((decimal)1, "decimal").Should().Be((decimal)1);
			Guard.Against.NegativeOrZero((float)1, "float").Should().Be((float)1);
			Guard.Against.NegativeOrZero((double)1, "double").Should().Be((double)1);
			Guard.Against.NegativeOrZero(TimeSpan.FromSeconds(1), "timespan").Should().Be(TimeSpan.FromSeconds(1));
		}
	}
}
