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
        
        Assert.Equal(new Drug[] { new Drug("test", 1, 2)}, 
            pharmacy.UpdateBenefitValue());
    }
}