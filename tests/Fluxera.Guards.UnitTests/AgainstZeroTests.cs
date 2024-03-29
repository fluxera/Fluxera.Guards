﻿namespace Fluxera.Guards.UnitTests
{
	using System;
	using FluentAssertions;
	using NUnit.Framework;

	[TestFixture]
	public class AgainstZeroTests
	{
		[Test]
		public void ShouldNotThrowWhenNotZero()
		{
			Guard.Against.Zero(byte.MaxValue, "byte");
			Guard.Against.Zero(short.MinValue, "short");
			Guard.Against.Zero(short.MaxValue, "short");
			Guard.Against.Zero(int.MinValue, "int");
			Guard.Against.Zero(int.MaxValue, "int");
			Guard.Against.Zero(long.MinValue, "long");
			Guard.Against.Zero(long.MaxValue, "long");
			Guard.Against.Zero(decimal.MinValue, "decimal");
			Guard.Against.Zero(decimal.MaxValue, "decimal");
			Guard.Against.Zero(float.MinValue, "float");
			Guard.Against.Zero(float.MaxValue, "float");
			Guard.Against.Zero(double.MinValue, "double");
			Guard.Against.Zero(double.MaxValue, "double");
			Guard.Against.Zero(TimeSpan.MinValue, "timespan");
			Guard.Against.Zero(TimeSpan.MaxValue, "timespan");
		}

		[Test]
		public void ShouldReturnInputOnSuccess()
		{
			Guard.Against.Zero((byte)1, "byte").Should().Be(1);
			Guard.Against.Zero((short)-1, "short").Should().Be(-1);
			Guard.Against.Zero((short)1, "short").Should().Be(1);
			Guard.Against.Zero(-1, "int").Should().Be(-1);
			Guard.Against.Zero(1, "int").Should().Be(1);
			Guard.Against.Zero((long)-1, "long").Should().Be(-1);
			Guard.Against.Zero((long)1, "long").Should().Be(1);
			Guard.Against.Zero((decimal)-1, "decimal").Should().Be(-1);
			Guard.Against.Zero((decimal)1, "decimal").Should().Be(1);
			Guard.Against.Zero((float)-1, "float").Should().Be(-1);
			Guard.Against.Zero((float)1, "float").Should().Be(1);
			Guard.Against.Zero((double)-1, "double").Should().Be(-1);
			Guard.Against.Zero((double)1, "double").Should().Be(1);
			Guard.Against.Zero(TimeSpan.FromSeconds(-1), "timespan").Should().Be(TimeSpan.FromSeconds(-1));
			Guard.Against.Zero(TimeSpan.FromSeconds(1), "timespan").Should().Be(TimeSpan.FromSeconds(1));
		}

		[Test]
		public void ShouldThrowWhenZeroByte()
		{
			Action action = () => Guard.Against.Zero(byte.MinValue, "byte");
			action.Should().Throw<ArgumentException>().WithParameterName("byte");
		}

		[Test]
		public void ShouldThrowWhenZeroDecimal()
		{
			Action action = () => Guard.Against.Zero((decimal)0, "decimal");
			action.Should().Throw<ArgumentException>().WithParameterName("decimal");
		}

		[Test]
		public void ShouldThrowWhenZeroDouble()
		{
			Action action = () => Guard.Against.Zero((double)0, "double");
			action.Should().Throw<ArgumentException>().WithParameterName("double");
		}

		[Test]
		public void ShouldThrowWhenZeroFloat()
		{
			Action action = () => Guard.Against.Zero((float)0, "float");
			action.Should().Throw<ArgumentException>().WithParameterName("float");
		}

		[Test]
		public void ShouldThrowWhenZeroInt()
		{
			Action action = () => Guard.Against.Zero(0, "int");
			action.Should().Throw<ArgumentException>().WithParameterName("int");
		}

		[Test]
		public void ShouldThrowWhenZeroInt_WithCallerArgumentExpression()
		{
			int integer = 0;
			Action action = () => Guard.Against.Zero(integer);
			action.Should().Throw<ArgumentException>().WithParameterName("integer");
		}

		[Test]
		public void ShouldThrowWhenZeroLong()
		{
			Action action = () => Guard.Against.Zero((long)0, "long");
			action.Should().Throw<ArgumentException>().WithParameterName("long");
		}

		[Test]
		public void ShouldThrowWhenZeroShort()
		{
			Action action = () => Guard.Against.Zero((short)0, "short");
			action.Should().Throw<ArgumentException>().WithParameterName("short");
		}

		[Test]
		public void ShouldThrowWhenZeroTimeSpan()
		{
			Action action = () => Guard.Against.Zero(TimeSpan.Zero, "timespan");
			action.Should().Throw<ArgumentException>().WithParameterName("timespan");
		}
	}
}
