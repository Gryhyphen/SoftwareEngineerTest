using EngineerTest;
using Xunit;

namespace EngineerTestTest;

public class PharmacyTest
{
    [Fact]
    public void TestShouldDecreaseBenefitAndExpiresIn()
    {
        var pharmacy = new Pharmacy();
        pharmacy.AddDrug("test", 2, 3);

        Assert.Equal(new Drug[] { new Drug("test", 1, 2) },
            pharmacy.UpdateBenefitValue());
    }

    // Once the expiration date has passed, Benefit degrades twice as fast.
    [Fact]
    public void TestExpiredDrugShouldDecreaseBenefitTwiceAsFast()
    {
        var pharmacy = new Pharmacy();
        pharmacy.AddDrug("test", 0, 4);

        var expectedDrugs = new Drug[] { new Drug("test", -1, 2) };
        Assert.Equal(expectedDrugs, pharmacy.UpdateBenefitValue());
    }

    // The Benefit of an item is never negative.
    [Fact]
    public void TestBenefitNeverNegative()
    {
        var pharmacy = new Pharmacy();
        pharmacy.AddDrug("test", 2, 0);

        var expectedDrugs = new Drug[] { new Drug("test", 1, 0) };
        Assert.Equal(expectedDrugs, pharmacy.UpdateBenefitValue());
    }

    // "Herbal Tea" actually increases in Benefit the older it gets.
    [Fact]
    public void TestHerbalTeaIncreasesBenefitWithAge()
    {
        var pharmacy = new Pharmacy();
        pharmacy.AddDrug("Herbal Tea", 5, 3);

        var expectedDrugs = new Drug[] { new Drug("Herbal Tea", 4, 4) };
        Assert.Equal(expectedDrugs, pharmacy.UpdateBenefitValue());
    }

    // "Herbal Tea" benefit increases twice as fast after the expiration date.
    [Fact]
    public void TestHerbalTeaIncreasesBenefitTwiceAsFastAfterExpiration()
    {
        var pharmacy = new Pharmacy();
        pharmacy.AddDrug("Herbal Tea", 0, 3);

        var expectedDrugs = new Drug[] { new Drug("Herbal Tea", -1, 5) };
        Assert.Equal(expectedDrugs, pharmacy.UpdateBenefitValue());
    }

    // The Benefit of an item is never more than 50.
    [Fact]
    public void TestNoDrugHaveBenefitNeverMoreThan50()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            var drug = new Drug("test", 10, 51);
        });
    }

    // "Herbal tea" benefit doesn't increase over 50.
    [Fact]
    public void TestHerbalTeaBenefitNeverMoreThan50()
    {
        var pharmacy = new Pharmacy();
        pharmacy.AddDrug("Herbal Tea", 10, 49);

        var expectedDrugs = new Drug[] { new Drug("Herbal Tea", 9, 50) };
        Assert.Equal(expectedDrugs, pharmacy.UpdateBenefitValue());
    }

    // "Magic Pill" never expires nor decreases in Benefit.
    [Fact]
    public void TestMagicPillNeverExpiresOrDecreasesBenefit()
    {
        var pharmacy = new Pharmacy();
        pharmacy.AddDrug("Magic Pill", 10, 30);

        var expectedDrugs = new Drug[] { new Drug("Magic Pill", 10, 30) };
        Assert.Equal(expectedDrugs, pharmacy.UpdateBenefitValue());
    }

    // "Fervex" Benefit increases by 1 when there are more then 10 days
    // I'm making the assumption that is is desired behavior, but it is not stated
    [Fact]
    public void TestFervexIncreasesBenefitBy1WhenExpirationDateGreaterThen10()
    {
        var pharmacy = new Pharmacy();
        pharmacy.AddDrug("Fervex", 20, 20);

        var expectedDrugs = new Drug[] { new Drug("Fervex", 19, 21) };
        Assert.Equal(expectedDrugs, pharmacy.UpdateBenefitValue());
    }

    // "Fervex" Benefit increases by 2 when there are 10 days or less
    [Fact]
    public void TestFervexIncreasesBenefitBy2WhenExpirationDateApproaches()
    {
        var pharmacy = new Pharmacy();
        pharmacy.AddDrug("Fervex", 10, 20);

        var expectedDrugs = new Drug[] { new Drug("Fervex", 9, 22) };
        Assert.Equal(expectedDrugs, pharmacy.UpdateBenefitValue());
    }

    // "Fervex" Benefit increases by 3 when there are 5 days or less
    [Fact]
    public void TestFervexIncreasesBenefitBy3WhenExpirationDateIs5DaysOrLess()
    {
        var pharmacy = new Pharmacy();
        pharmacy.AddDrug("Fervex", 5, 25);

        var expectedDrugs = new Drug[] { new Drug("Fervex", 4, 28) };
        Assert.Equal(expectedDrugs, pharmacy.UpdateBenefitValue());
    }

    // "Fervex" Benefit drops to 0 after the expiration date
    [Fact]
    public void TestFervexBenefitDropsToZeroAfterExpirationDate()
    {
        var pharmacy = new Pharmacy();
        pharmacy.AddDrug("Fervex", 0, 30);

        var expectedDrugs = new Drug[] { new Drug("Fervex", -1, 0) };
        Assert.Equal(expectedDrugs, pharmacy.UpdateBenefitValue());
    }

    // "Dafalgan" degrades in Benefit twice as fast as normal drugs.
    [Fact]
    public void TestDafalganDegradesInBenefitTwiceThatOfANormalDrugFast()
    {
        var pharmacy = new Pharmacy();
        pharmacy.AddDrug("Dafalgan", 5, 10);

        var expectedDrugs = new Drug[] { new Drug("Dafalgan", 4, 8) };
        Assert.Equal(expectedDrugs, pharmacy.UpdateBenefitValue());
    }

    // "Dafalgan" should degrade 2x it's base degrading when past it's expiry date
    [Fact]
    public void TestDafalganDegradesInBenefitTwiceAsFastWhenExpired()
    {
        var pharmacy = new Pharmacy();
        pharmacy.AddDrug("Dafalgan", -2, 10);

        var expectedDrugs = new Drug[] { new Drug("Dafalgan", -3, 6) };
        Assert.Equal(expectedDrugs, pharmacy.UpdateBenefitValue());
    }
}