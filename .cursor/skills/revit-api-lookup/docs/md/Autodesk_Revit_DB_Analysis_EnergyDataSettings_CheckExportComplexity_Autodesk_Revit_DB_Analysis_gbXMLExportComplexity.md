---
kind: method
id: M:Autodesk.Revit.DB.Analysis.EnergyDataSettings.CheckExportComplexity(Autodesk.Revit.DB.Analysis.gbXMLExportComplexity)
source: html/44fe6f91-8845-b285-d31e-21a818418503.htm
---
# Autodesk.Revit.DB.Analysis.EnergyDataSettings.CheckExportComplexity Method

Checks that the export complexity falls within an appropriate range.

## Syntax (C#)
```csharp
public static bool CheckExportComplexity(
	gbXMLExportComplexity exportComplexity
)
```

## Parameters
- **exportComplexity** (`Autodesk.Revit.DB.Analysis.gbXMLExportComplexity`) - The export complexity to be checked.

## Returns
True if the export complexity falls within an appropriate range, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

