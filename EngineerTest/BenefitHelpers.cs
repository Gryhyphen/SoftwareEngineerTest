namespace EngineerTest;

static class BenefitHelpers
{
    const int MAX_BENEFIT = 50;
    const int MIN_BENEFIT = 0;
    const int NORMAL_DRUG_DECREASE = 1;

    public static int GetNextBenefitValue(IDrug drug)
    {
        var newBenefitValue = drug switch
        {
            { Name: "Herbal Tea" } => GetNextBenefitValue_HerbalTea(drug),
            { Name: "Magic Pill" } => GetNextBenefitValue_MagicPill(drug),
            { Name: "Fervex" } => GetNextBenefitValue_Fervex(drug),
            { Name: "Dafalgan" } => GetNextBenefitValue_Dafalgan(drug),
            _ => GetNextBenefitValue_NormalDrug(drug)
        };
        return ClipValueToRange(newBenefitValue);
    }

    private static int ClipValueToRange(int value)
    {
        if (value > MAX_BENEFIT) return MAX_BENEFIT;
        if (value < MIN_BENEFIT) return MIN_BENEFIT;
        return value;
    }

    private static int GetNextBenefitValue_NormalDrug(IDrug drug) => drug switch
    {
        { ExpiresIn: > 0 } => drug.Benefit - NORMAL_DRUG_DECREASE,
        _ => drug.Benefit - (NORMAL_DRUG_DECREASE * 2)
    };

    private static int GetNextBenefitValue_HerbalTea(IDrug drug)
    {
        const int HERBAL_TEA_BASE_INCREASE = 1;
        if (drug.ExpiresIn > 0) return drug.Benefit + HERBAL_TEA_BASE_INCREASE;
        return drug.Benefit + (HERBAL_TEA_BASE_INCREASE * 2);
    }

    private static int GetNextBenefitValue_MagicPill(IDrug drug) => drug.Benefit;

    private static int GetNextBenefitValue_Fervex(IDrug drug) => drug switch
    {
        { ExpiresIn: > 10 } => drug.Benefit + 1,
        { ExpiresIn: > 5 } => drug.Benefit + 2,
        { ExpiresIn: > 0 } => drug.Benefit + 3,
        _ => 0
    };

    private static int GetNextBenefitValue_Dafalgan(IDrug drug) => drug switch
    {
        { ExpiresIn: > 0 } => drug.Benefit - (NORMAL_DRUG_DECREASE * 2),
        _ => drug.Benefit - (NORMAL_DRUG_DECREASE * 2 * 2)
    };
}