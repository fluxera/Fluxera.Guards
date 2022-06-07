namespace Fluxera.Guards.UnitTests
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using FluentAssertions;
	using NUnit.Framework;

	[TestFixture]
	public class AgainstNullTests
	{
		[Test]
		public void ShouldDoNothingWhenNotDefault()
		{
			Guard.Against.Default(string.Empty, "string");
			Guard.Against.Default(1, "int");
			Guard.Against.Default(Guid.NewGuid(), "guid");
			Guard.Against.Default(DateTime.MaxValue, "datetime");
			Guard.Against.Default(new object(), "object");
		}

		[Test]
		public void ShouldDoNothingWhenNotEmptyEnumerable()
		{
			Guard.Against.NullOrEmpty(new List<string> { "hello", "world" }, "enumerable");
			Guard.Against.NullOrEmpty(new string[] { "hello", "world" }, "enumerable");
		}

		[Test]
		public void ShouldDoNothingWhenNotEmptyGuid()
		{
			Guard.Against.NullOrEmpty(Guid.NewGuid(), "guid");
		}

		[Test]
		public void ShouldDoNothingWhenNotEmptyOrWhitespaceString()
		{
			Guard.Against.NullOrWhiteSpace("hello", "string");
			Guard.Against.NullOrWhiteSpace("hello world", "string");
			Guard.Against.NullOrWhiteSpace(" leading whitespace", "string");
			Guard.Against.NullOrWhiteSpace("trailing whitespace ", "string");
		}

		[Test]
		public void ShouldDoNothingWhenNotEmptyString()
		{
			Guard.Against.NullOrEmpty("hello", "string");
		}

		[Test]
		public void ShouldDoNothingWhenNotNull()
		{
			Guard.Against.Null(string.Empty, "string");
			Guard.Against.Null(1, "int");
			Guard.Against.Null(Guid.Empty, "guid");
			Guard.Against.Null(DateTime.MinValue, "datetime");
			Guard.Against.Null(new object(), "object");
		}

		[Test]
		public void ShouldReturnInputOnSuccessDefault()
		{
			Guard.Against.Default(string.Empty, "string").Should().Be(string.Empty);
			Guard.Against.Default(1, "int").Should().Be(1);

			Guid guid = Guid.NewGuid();
			Guard.Against.Default(guid).Should().Be(guid);

			DateTime now = DateTime.Now;
			Guard.Against.Default(now, "datetime").Should().Be(now);

			object obj = new object();
			Guard.Against.Default(obj, "object").Should().Be(obj);
		}

		[Test]
		public void ShouldReturnInputOnSuccessNull()
		{
			Guard.Against.Null(string.Empty, "string").Should().Be(string.Empty);
			Guard.Against.Null(1, "int").Should().Be(1);

			Guid guid = Guid.NewGuid();
			Guard.Against.Null(guid).Should().Be(guid);

			DateTime now = DateTime.Now;
			Guard.Against.Null(now, "datetime").Should().Be(now);

			object obj = new object();
			Guard.Against.Null(obj, "object").Should().Be(obj);
		}

		[Test]
		public void ShouldReturnInputOnSuccessNullOrEmpty()
		{
			Guard.Against.NullOrEmpty("hello", "string").Should().Be("hello");

			Guid guid = Guid.NewGuid();
			Guard.Against.NullOrEmpty(guid).Should().Be(guid);

			IList<string> enumerable = new List<string> { "hello", "world" };
			Guard.Against.NullOrEmpty(enumerable).Should().BeEquivalentTo(enumerable);
		}

		[Test]
		public void ShouldReturnInputOnSuccessNullOrWhitespace()
		{
			Guard.Against.NullOrWhiteSpace("hello", "string").Should().Be("hello");
			Guard.Against.NullOrWhiteSpace("hello world", "string").Should().Be("hello world");
			Guard.Against.NullOrWhiteSpace(" leading whitespace", "string").Should().Be(" leading whitespace");
			Guard.Against.NullOrWhiteSpace("trailing whitespace ", "string").Should().Be("trailing whitespace ");
		}

		[Test]
		public void ShouldThrowWhenDefault()
		{
			Action stringAction = () => Guard.Against.Default(default(string), "string");
			stringAction.Should().Throw<ArgumentException>();

			Action intAction = () => Guard.Against.Default(default(int), "int");
			intAction.Should().Throw<ArgumentException>();

			Action guidAction = () => Guard.Against.Default(default(Guid), "guid");
			guidAction.Should().Throw<ArgumentException>();

			Action datetimeAction = () => Guard.Against.Default(default(DateTime), "datetime");
			datetimeAction.Should().Throw<ArgumentException>();

			Action objectAction = () => Guard.Against.Default(default(object), "object");
			objectAction.Should().Throw<ArgumentException>();
		}

		[Test]
		public void ShouldThrowWhenEmptyEnumerable()
		{
			Action action = () => Guard.Against.NullOrEmpty(Enumerable.Empty<string>(), "enumerable");
			action.Should().Throw<ArgumentException>().WithParameterName("enumerable");
		}

		[Test]
		public void ShouldThrowWhenEmptyGuid()
		{
			Action action = () => Guard.Against.NullOrEmpty(Guid.Empty, "guid");
			action.Should().Throw<ArgumentException>().WithParameterName("guid");
		}

		[Test]
		public void ShouldThrowWhenEmptyString()
		{
			Action action = () => Guard.Against.NullOrEmpty(string.Empty, "string");
			action.Should().Throw<ArgumentException>().WithParameterName("string");
		}

		[Test]
		public void ShouldThrowWhenEmptyStringNullOrWhiteSpace()
		{
			Action action = () => Guard.Against.NullOrWhiteSpace(string.Empty, "string");
			action.Should().Throw<ArgumentException>().WithParameterName("string");
		}

		[Test]
		public void ShouldThrowWhenNull()
		{
			Action action = () => Guard.Against.Null((object)null, "object");
			action.Should().Throw<ArgumentNullException>().WithParameterName("object");
		}

		[Test]
		public void ShouldThrowWhenNull_WithCallerArgumentExpression()
		{
			object obj = null;
			Action action = () => Guard.Against.Null(obj);
			action.Should().Throw<ArgumentNullException>().WithParameterName("obj");
		}

		[Test]
		public void ShouldThrowWhenNullGuid()
		{
			Action action = () => Guard.Against.NullOrEmpty((Guid?)null, "guid");
			action.Should().Throw<ArgumentNullException>().WithParameterName("guid");
		}

		[Test]
		public void ShouldThrowWhenNullString()
		{
			Action action = () => Guard.Against.NullOrEmpty((string)null, "string");
			action.Should().Throw<ArgumentNullException>().WithParameterName("string");
		}

		[Test]
		public void ShouldThrowWhenNullStringNullOrWhiteSpace()
		{
			Action action = () => Guard.Against.NullOrWhiteSpace(null, "string");
			action.Should().Throw<ArgumentNullException>().WithParameterName("string");
		}

		[Test]
		public void ShouldThrowWhenWhiteSpaceString()
		{
			Action actionSingle = () => Guard.Against.NullOrWhiteSpace(" ", "string");
			actionSingle.Should().Throw<ArgumentException>().WithParameterName("string");

			Action actionMultiple = () => Guard.Against.NullOrWhiteSpace("   ", "string");
			actionMultiple.Should().Throw<ArgumentException>().WithParameterName("string");
		}
	}
}
