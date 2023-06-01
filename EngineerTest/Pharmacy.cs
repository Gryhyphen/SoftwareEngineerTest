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
        for (var i = 0; i < this._drugs.Count; i++)
        {
            if (
                this._drugs[i].Name != "Herbal Tea" &&
                this._drugs[i].Name != "Fervex")
            {
                if (this._drugs[i].Benefit > 0)
                {
                    if (this._drugs[i].Name != "Magic Pill")
                    {
                        this._drugs[i].Benefit--;
                    }
                }
            }
            else
            {
                if (this._drugs[i].Benefit < 50)
                {
                    this._drugs[i].Benefit++;
                    if (this._drugs[i].Name == "Fervex")
                    {
                        if (this._drugs[i].ExpiresIn < 11)
                        {
                            if (this._drugs[i].Benefit < 50)
                            {
                                this._drugs[i].Benefit++;
                            }
                        }

                        if (this._drugs[i].ExpiresIn < 6)
                        {
                            if (this._drugs[i].Benefit < 50)
                            {
                                this._drugs[i].Benefit++;
                            }
                        }
                    }
                }
            }

            if (this._drugs[i].Name != "Magic Pill")
            {
                this._drugs[i].ExpiresIn--;
            }

            if (this._drugs[i].ExpiresIn < 0)
            {
                if (this._drugs[i].Name != "Herbal Tea")
                {
                    if (this._drugs[i].Name != "Fervex")
                    {
                        if (this._drugs[i].Benefit > 0)
                        {
                            if (this._drugs[i].Name != "Magic Pill")
                            {
                                this._drugs[i].Benefit--;
                            }
                        }
                    }
                    else
                    {
                        this._drugs[i].Benefit -= this._drugs[i].Benefit;
                    }
                }
                else
                {
                    if (this._drugs[i].Benefit < 50)
                    {
                        this._drugs[i].Benefit++;
                    }
                }
            }
        }

        return this._drugs;
    }
}