// <copyright file="Pharmacy.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EngineerTest;

/// <summary>
/// An instance of a Pharamcy.
/// </summary>
public class Pharmacy : IPharmacy
{
    /// <summary>
    /// Backing field for the collection of drugs being tracked by Pharmacy.
    /// Candidate for repository pattern.
    /// </summary>
    private readonly List<IDrug> _drugs = new ();

    /// <inheritdoc/>
    public IDrug AddDrug(string name, int expiresIn, int benefit)
    {
        var drug = new Drug(name, expiresIn, benefit);
        this._drugs.Add(drug);
        return drug;
    }

    /// <inheritdoc/>
    public IEnumerable<IDrug> UpdateBenefitValue()
    {
        this._drugs.ForEach(drug =>
        {
            // Calculate values BEFORE mutating the drug
            var (benefit, expiresIn) = (BenefitHelpers.GetNextBenefitValue(drug), ExpiryHelpers.GetNextExpiresInValue(drug));
            drug.Benefit = benefit;
            drug.ExpiresIn = expiresIn;
        });
        return this._drugs;
    }
}