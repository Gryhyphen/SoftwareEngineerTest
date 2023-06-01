// <copyright file="IPharmacy.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EngineerTest;

/// <summary>
/// An interface for an instance of a pharmacy.
/// Do not break the public API as it is used by other pieces of the software.
/// </summary>
public interface IPharmacy
{
    /// <summary>
    /// Mutation that triggers an update to the benefit value and returns the result.
    /// </summary>
    /// <returns>An updated list of IDrugs.</returns>
    IEnumerable<IDrug> UpdateBenefitValue();

    /// <summary>
    /// Mutation that creates and adds a drug to the pharmacy.
    /// </summary>
    /// <param name="name">Name of the drug.</param>
    /// <param name="expiresIn">The number of days until the item expires.</param>
    /// <param name="benefit">An integer that denotes how powerful the drug is.</param>
    /// <returns>Returns the newly added drug if the mutation was sucessful.</returns>
    IDrug AddDrug(string name, int expiresIn, int benefit);
}