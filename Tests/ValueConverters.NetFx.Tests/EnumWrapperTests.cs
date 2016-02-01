﻿using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;

using ValueConverters.NetFx.Tests.TestData;

using Xunit;
using FluentAssertions;

namespace ValueConverters.NetFx.Tests
{
    public class EnumWrapperTests
    {
        [Fact]
        public void ShouldReturnLocalizedValue()
        {
            // Arrange
            var enumWrapper = EnumWrapper.CreateWrapper(TestEnum.Lorem);

            const string ExpectedLocalizationLorem = "Lorem text";

            // Act
            var localizedValue = enumWrapper.LocalizedValue;

            // Assert
           localizedValue.Should().Be(ExpectedLocalizationLorem);
        }

        [Fact]
        public void ShouldThrowInvalidOperationExpectionIfDisplayNameResourceCannotBeFound()
        {
            // Arrange
            var enumWrapper = EnumWrapper.CreateWrapper(TestEnum.Ipsum);

            // Act
            Action action = () => { var x = enumWrapper.LocalizedValue;  };

            // Assert
            action.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void ShouldReturnEnumToStringIfNoDisplayAttributeIsSet()
        {
            // Arrange
            var enumWrapper = EnumWrapper.CreateWrapper(TestEnum.Dolor);

            string expectedLocalizationDolor = TestEnum.Dolor.ToString();

            // Act
            var localizedValue = enumWrapper.LocalizedValue;

            // Assert
            localizedValue.Should().Be(expectedLocalizationDolor);
        }

        [Fact]
        public void ShouldCreateWrappers()
        {
            // Act
            var enumWrappers = EnumWrapper.CreateWrappers<TestEnum>().ToArray();

            // Assert
            enumWrappers.Should().HaveCount(3);

            enumWrappers[0].Value.Should().Be(TestEnum.Lorem);
            enumWrappers[1].Value.Should().Be(TestEnum.Ipsum);
            enumWrappers[2].Value.Should().Be(TestEnum.Dolor);
        }
    }
}