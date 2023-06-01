// <copyright file="ExpiryHelpers.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EngineerTest;

/// <summary>
/// Methods to calculate expiry.
/// In a more complex system this would probably need to be turned into a service that we DI in.
/// </summary>
public static class ExpiryHelpers
{
    /// <summary>
    /// Calculates the next expiry value given the current values of a drug.
    /// </summary>
    /// <param name="drug">The current values of a drug.</param>
    /// <returns>The next expiry value for that drug.</returns>
    public static int GetNextExpiresInValue(IDrug drug) => drug switch
    {
        { Name: "Magic Pill" } => drug.ExpiresIn,
        _ => drug.ExpiresIn - 1
    };
}