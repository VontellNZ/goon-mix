using FluentAssertions;
using GoonMixer.Data;
using GoonMixer.Data.Enums;
using System;
using System.Collections.Generic;
using Xunit;

namespace GoonMixer.Tests;

public class EnergyBoostMixingTechniqueTests
{
    [Fact]
    public void GivenListOfSongs_GetSuggestedSongs_ShouldReturnMatchingSongs()
    {
        //Arrange
        var mainSong = new Song("Solar System", "Sub Focus", "Solar System / Siren", "Drum & Bass", 
            174, new TimeSpan(0, 4, 48), new Key("F", Scale.Minor, Signature.None, new CamelotScale(4, "A")));
        var harmonicMatch = new Song("Devotion (feat. Cameron Hayes)", "Dimension", "Organ", "Drum & Bass", 
            174, new TimeSpan(0, 3, 10), new Key("F", Scale.Minor, Signature.None, new CamelotScale(6, "A")));
        var nonMatch = new Song("Afterglow", "Wilkinson", " Lazers Not Included", "Drum & Bass", 
            174, new TimeSpan(0, 3, 45), new Key("G", Scale.Major, Signature.None, new CamelotScale(6, "B")));
        var songs = new List<Song>{ mainSong, harmonicMatch, nonMatch };

        var mixingTechnique = new EnergyBoostMixingTechnique();
        
        //Act
        var result = mixingTechnique.GetSuggestedSongs(mainSong, songs);

        //Assert
        result.Should().Contain(harmonicMatch);
        result.Should().NotContain(mainSong);
        result.Should().NotContain(nonMatch);
    }
    
    [Theory]
    [InlineData(11, 1)]
    [InlineData(12, 2)]
    public void GivenWraparoundKey_GetSuggestedSongs_ShouldReturnMatchingSong(int mainCamelotNumber, int matchingCamelotNumber)
    {
        //Arrange
        var mainSong = new Song("Solar System", "Sub Focus", "Solar System / Siren", "Drum & Bass", 
            174, new TimeSpan(0, 4, 48), new Key("F", Scale.Minor, Signature.None, new CamelotScale(mainCamelotNumber, "A")));
        var harmonicMatch = new Song("Devotion (feat. Cameron Hayes)", "Dimension", "Organ", "Drum & Bass", 
            174, new TimeSpan(0, 3, 10), new Key("F", Scale.Minor, Signature.None, new CamelotScale(matchingCamelotNumber, "A")));
        var nonMatch = new Song("Afterglow", "Wilkinson", " Lazers Not Included", "Drum & Bass", 
            174, new TimeSpan(0, 3, 45), new Key("G", Scale.Major, Signature.None, new CamelotScale(matchingCamelotNumber, "B")));
        var songs = new List<Song>{ mainSong, harmonicMatch, nonMatch };

        var mixingTechnique = new EnergyBoostMixingTechnique();
        
        //Act
        var result = mixingTechnique.GetSuggestedSongs(mainSong, songs);

        //Assert
        result.Should().Contain(harmonicMatch);
        result.Should().NotContain(mainSong);
        result.Should().NotContain(nonMatch);
    }

    [Fact]
    public void GivenAvbVariation_GetSuggestedSongs_ShouldReturnMatchingSongs()
    {
        //Arrange
        var mainSong = new Song("Solar System", "Sub Focus", "Solar System / Siren", "Drum & Bass", 
            174, new TimeSpan(0, 4, 48), new Key("F", Scale.Minor, Signature.None, new CamelotScale(6, "A")));
        var harmonicMatch = new Song("Devotion (feat. Cameron Hayes)", "Dimension", "Organ", "Drum & Bass", 
            174, new TimeSpan(0, 3, 10), new Key("F", Scale.Minor, Signature.None, new CamelotScale(1, "A")));
        var nonMatch = new Song("Afterglow", "Wilkinson", " Lazers Not Included", "Drum & Bass", 
            174, new TimeSpan(0, 3, 45), new Key("G", Scale.Major, Signature.None, new CamelotScale(1, "B")));
        var songs = new List<Song>{ mainSong, harmonicMatch, nonMatch };

        var mixingTechnique = new EnergyBoostMixingTechnique();
        
        //Act
        var result = mixingTechnique.GetSuggestedSongs(mainSong, songs);

        //Assert
        result.Should().Contain(harmonicMatch);
        result.Should().NotContain(mainSong);
        result.Should().NotContain(nonMatch);
    }
    
    [Theory]
    [InlineData(5, 12)]
    [InlineData(4, 11)]
    [InlineData(3, 10)]
    [InlineData(2, 9)]
    [InlineData(1, 8)]
    public void GivenWraparoundAvbVariation_GetSuggestedSongs_ShouldReturnMatchingSong(int mainCamelotNumber, int matchingCamelotNumber)
    {
        //Arrange
        var mainSong = new Song("Solar System", "Sub Focus", "Solar System / Siren", "Drum & Bass", 
            174, new TimeSpan(0, 4, 48), new Key("F", Scale.Minor, Signature.None, new CamelotScale(mainCamelotNumber, "A")));
        var harmonicMatch = new Song("Devotion (feat. Cameron Hayes)", "Dimension", "Organ", "Drum & Bass", 
            174, new TimeSpan(0, 3, 10), new Key("F", Scale.Minor, Signature.None, new CamelotScale(matchingCamelotNumber, "A")));
        var nonMatch = new Song("Afterglow", "Wilkinson", " Lazers Not Included", "Drum & Bass", 
            174, new TimeSpan(0, 3, 45), new Key("G", Scale.Major, Signature.None, new CamelotScale(matchingCamelotNumber, "B")));
        var songs = new List<Song>{ mainSong, harmonicMatch, nonMatch };

        var mixingTechnique = new EnergyBoostMixingTechnique();
        
        //Act
        var result = mixingTechnique.GetSuggestedSongs(mainSong, songs);

        //Assert
        result.Should().Contain(harmonicMatch);
        result.Should().NotContain(mainSong);
        result.Should().NotContain(nonMatch);
    }
}