namespace EngineerTest;

public interface IPharmacy
{
    IEnumerable<IDrug> UpdateBenefitValue();
    IDrug AddDrug(string name, int expiresIn, int benefit);
}