using FluentAssertions;
using GoonMixer.Data;
using GoonMixer.Data.Enums;
using System;
using System.Collections.Generic;
using Xunit;

namespace GoonMixer.Tests;

public class SmoothMixingTechniqueTests
{
    [Fact]
    public void GivenListOfSongs_GetSuggestedSongs_ShouldReturnMatchingSongs()
    {
        //Arrange
        var mainSong = new Song("Solar System", "Sub Focus", "Solar System / Siren", "Drum & Bass", 
            174, new TimeSpan(0, 4, 48), new Key("F", Scale.Minor, Signature.None, new CamelotScale(4, "A")));
        var harmonicMatch = new Song("Devotion (feat. Cameron Hayes)", "Dimension", "Organ", "Drum & Bass", 
            174, new TimeSpan(0, 3, 10), new Key("F", Scale.Minor, Signature.None, new CamelotScale(4, "A")));
        var nonMatch = new Song("Afterglow", "Wilkinson", " Lazers Not Included", "Drum & Bass", 
            174, new TimeSpan(0, 3, 45), new Key("G", Scale.Major, Signature.None, new CamelotScale(9, "B")));
        var songs = new List<Song>{ mainSong, harmonicMatch, nonMatch };

        var mixingTechnique = new SmoothMixingTechnique();
        
        //Act
        var result = mixingTechnique.GetSuggestedSongs(mainSong, songs);

        //Assert
        result.Should().Contain(harmonicMatch);
        result.Should().NotContain(mainSong);
        result.Should().NotContain(nonMatch);
    }
    
    [Theory]
    [InlineData(1, 12)]
    [InlineData(12, 1)]
    public void GivenWraparoundKey_GetSuggestedSongs_ShouldReturnMatchingSong(int mainCamelotNumber, int matchingCamelotNumber)
    {
        //Arrange
        var mainSong = new Song("Solar System", "Sub Focus", "Solar System / Siren", "Drum & Bass", 
            174, new TimeSpan(0, 4, 48), new Key("F", Scale.Minor, Signature.None, new CamelotScale(mainCamelotNumber, "A")));
        var harmonicMatch = new Song("Devotion (feat. Cameron Hayes)", "Dimension", "Organ", "Drum & Bass", 
            174, new TimeSpan(0, 3, 10), new Key("F", Scale.Minor, Signature.None, new CamelotScale(matchingCamelotNumber, "A")));
        var songs = new List<Song>{ mainSong, harmonicMatch };

        var mixingTechnique = new SmoothMixingTechnique();
        
        //Act
        var result = mixingTechnique.GetSuggestedSongs(mainSong, songs);

        //Assert
        result.Should().Contain(harmonicMatch);
        result.Should().NotContain(mainSong);
    }
}