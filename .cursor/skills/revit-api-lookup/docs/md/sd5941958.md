---
kind: property
id: P:Autodesk.Revit.DB.Analysis.SystemsAnalysisOptions.WeatherFile
source: html/f5fae390-1c11-466e-766f-480c5e6d8c68.htm
---
# Autodesk.Revit.DB.Analysis.SystemsAnalysisOptions.WeatherFile Property

The file name of the EnergyPlus weather (*.epw).

## Syntax (C#)
```csharp
public string WeatherFile { get; set; }
```

## Remarks
When requesting a new system analysis, it is okay to have an empty weather file in the SystemsAnalysisOption. In that case,
 the ViewSystemsAnalysisReport would use the weather file at the current site location.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: The analysis requires a valid EnergyPlus weather (.epw) file.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

