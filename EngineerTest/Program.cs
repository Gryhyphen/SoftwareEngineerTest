﻿using System.Text.Json;
using EngineerTest;



try
{
    IPharmacy pharmacy = new Pharmacy();
    pharmacy.AddDrug("Doliprane", 20, 30);
    pharmacy.AddDrug("Herbal Tea", 10, 5);
    pharmacy.AddDrug("Fervex", 12, 35);
    pharmacy.AddDrug("Magic Pill", 15, 40);

    var log = new List<Drug[]?>();

    for (var elapsedDays = 0; elapsedDays < 30; elapsedDays++) {
        log.Add(JsonSerializer.Deserialize<Drug[]>(JsonSerializer.Serialize(pharmacy.UpdateBenefitValue())));
    }

    File.WriteAllText(
        "output.json",
        JsonSerializer.Serialize(new { Result= log }, options: new JsonSerializerOptions { WriteIndented = true})
    );    
    Console.WriteLine("Success");

}
catch
{
    Console.WriteLine("Error");
}
