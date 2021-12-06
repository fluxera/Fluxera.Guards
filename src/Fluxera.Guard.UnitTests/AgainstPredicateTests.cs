namespace Fluxera.Guard.UnitTests
{
	using System;
	using System.Collections.Generic;
	using FluentAssertions;
	using NUnit.Framework;

	[TestFixture]
	public class AgainstPredicateTests
	{
		[Test]
		public void ShouldDoNothingWhenTrue()
		{
			Guard.Against.False(true, "bool");
		}

		[Test]
		public void ShouldDoNothingWhenFalse()
		{
			Guard.Against.True(false, "bool");
		}

		[Test]
		public void ShouldThrowWhenTrue()
		{
			Action action = () => Guard.Against.True(true, "bool");
			action.Should().Throw<ArgumentException>();
		}

		[Test]
		public void ShouldThrowWhenFalse()
		{
			Action action = () => Guard.Against.False(false, "bool");
			action.Should().Throw<ArgumentException>();
		}

		[Test]
		public void ShouldDoNothingWhenPredicateSatisfied()
		{
			Guard.Against.InvalidInput("hallo", "string", i => i.StartsWith("h"));
		}
		
		[Test]
		public void ShouldThrowWhenPredicateIsNotSatisfied()
		{
			Action action = () => Guard.Against.InvalidInput("hallo", "string", i => i.StartsWith("x"));
			action.Should().Throw<ArgumentException>();
		}

		[Test]
		[TestCaseSource(nameof(CorrectFormatTestCases))]
		public void ShouldDoNothingWhenFormatIsCorrect(string input, string regexPattern)
		{
			Guard.Against.InvalidFormat(input, nameof(input), regexPattern);
		}

		[Test]
		[TestCaseSource(nameof(IncorrectFormatTestCases))]
		public void ShouldThrowWhenFormatIsIncorrect(string input, string regexPattern)
		{
			Action action = () => Guard.Against.InvalidFormat(input, nameof(input), regexPattern);
			action.Should().Throw<ArgumentException>();
		}

		[Test]
		public void ShouldReturnInputOnSuccess()
		{
			Guard.Against.False(true, "bool").Should().BeTrue();
			Guard.Against.True(false, "bool").Should().BeFalse();
			Guard.Against.InvalidInput("hallo", "string", i => i.StartsWith("h")).Should().Be("hallo");
		}

		[Test]
		[TestCaseSource(nameof(CorrectFormatTestCases))]
		public void ShouldReturnInputOnSuccessFormat(string input, string regexPattern)
		{
			Guard.Against.InvalidFormat(input, nameof(input), regexPattern).Should().Be(input);
		}

		private static readonly IEnumerable<object[]> CorrectFormatTestCases = new List<object[]>
		{
			new object[] { "12345", @"\d{1,6}" },
			new object[] { "50FA", @"[0-9a-fA-F]{1,6}" },
			new object[] { "abfACD", @"[a-fA-F]{1,8}" },
			new object[] { "DHSTRY", @"[A-Z]+" },
			new object[] { "3498792", @"\d+" },
		};

		private static readonly IEnumerable<object[]> IncorrectFormatTestCases = new List<object[]>
		{
			new object[] { "aaa", @"\d{1,6}" },
			new object[] { "50XA", @"[0-9a-fA-F]{1,6}" },
			new object[] { "2GudhUtG", @"[a-fA-F]+" },
			new object[] { "sDHSTRY", @"[A-Z]+" },
			new object[] { "3F498792", @"\d+" },
		};
	}
}
