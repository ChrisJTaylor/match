using System;
using System.IO;
using System.Text;
using FluentAssertions;
using Match.Domain;
using Moq;
using NUnit.Framework;

namespace Match.Tests;

public class WhenBuildingAPackOfCards
{
    private Cards _cards;

    [OneTimeSetUp]
    public void Setup()
    {
        _cards = new Cards();
    }

    [Test]
    public void ItShouldContainTheExpectedNumberOfCards()
    {
        _cards.Pack.Should().HaveCount(6);
    }

}