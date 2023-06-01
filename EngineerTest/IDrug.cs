// <copyright file="IDrug.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EngineerTest;

/// <summary>
/// An interface for an instance of a drug.
/// Do not break the public API as it is used by other pieces of the software.
/// </summary>
public interface IDrug
{
    /// <summary>
    /// Gets name.
    /// </summary>
    string Name { get; }

    /// <summary>
    /// Gets or sets ExpiresIn which denotes the number of days we have until the item expires.
    /// </summary>
    int ExpiresIn { get; set; }

    /// <summary>
    /// Gets or sets benefit which denotes how powerful the drug is.
    /// </summary>
    int Benefit { get; set; }
}