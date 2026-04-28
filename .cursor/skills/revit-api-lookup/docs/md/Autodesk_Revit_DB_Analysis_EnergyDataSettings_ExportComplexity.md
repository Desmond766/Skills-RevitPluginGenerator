---
kind: property
id: P:Autodesk.Revit.DB.Analysis.EnergyDataSettings.ExportComplexity
source: html/422b9c1f-76ba-788b-9a32-2b7f063a8a7b.htm
---
# Autodesk.Revit.DB.Analysis.EnergyDataSettings.ExportComplexity Property

Value determines Export Complexity for GreenBuildingXML detailed model export.

## Syntax (C#)
```csharp
public gbXMLExportComplexity ExportComplexity { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: The export complexity does not fall within an appropriate range.
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: A value passed for an enumeration argument is not a member of that enumeration

