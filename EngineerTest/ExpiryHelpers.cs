namespace EngineerTest;

static class ExpiryHelpers
{
    public static int GetNextExpiresInValue(IDrug drug) => drug switch
    {
        { Name: "Magic Pill" } => drug.ExpiresIn,
        _ => drug.ExpiresIn - 1
    };
}