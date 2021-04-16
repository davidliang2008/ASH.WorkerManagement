using FluentAssertions;
using FluentAssertions.Execution;
using System;
using Xunit;

namespace ASH.WorkerManagement.Domain.UnitTests
{
    public class FullNameTest
    {
        public class Create
        {
            [Theory]
            [InlineData(null, null)]
            [InlineData("", null)]
            [InlineData(null, "")]
            [InlineData(" ", null)]
            [InlineData(null, " ")]
            [InlineData(null, "Liang")]
            [InlineData("David", null)]

            public void WhenMissingRequiredField_ThrowsException(string firstName, string lastName)
            {
                Action act = () => FullName.Create(firstName, lastName);

                act.Should().Throw<ArgumentNullException>();
            }

            [Theory]
            [InlineData("David", "Liang")]
            [InlineData("Someone", "Else")]
            public void WhenFilledWithValidNames_CreatedWithoutException(string firstName, string lastName)
            {
                var fullName = FullName.Create(firstName, lastName);

                using (new AssertionScope())
                {
                    fullName.Should().NotBeNull();
                    fullName.FirstName.Should().Equals(firstName);
                    fullName.LastName.Should().Equals(lastName);
                }
            }
        }

        public class GetEqualityComponents
        {
            [Theory]
            [InlineData("David", "Liang")]
            public void WhenCreatedWithSameNames_Equals(string firstName, string lastName)
            {
                var fullName1 = FullName.Create(firstName, lastName);
                var fullName2 = FullName.Create(firstName, lastName);

                using (new AssertionScope())
                {
                    fullName1.Should().Be(fullName2);
                    (fullName1 == fullName2).Should().BeTrue();
                }
            }

            [Theory]
            [InlineData("David", "Liang", "Simon", "Cheng")]
            public void WhenCreatedWithDifferentNames_NotEqual(string firstName1, string lastName1,
                string firstName2, string lastName2)
            {
                var fullName1 = FullName.Create(firstName1, lastName1);
                var fullName2 = FullName.Create(firstName2, lastName2);

                using (new AssertionScope())
                {
                    fullName1.Should().NotBe(fullName2);
                    (fullName1 != fullName2).Should().BeTrue();
                }
            }
        }
    }
}
