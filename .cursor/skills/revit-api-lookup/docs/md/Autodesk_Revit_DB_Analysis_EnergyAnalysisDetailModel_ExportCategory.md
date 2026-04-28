---
kind: property
id: P:Autodesk.Revit.DB.Analysis.EnergyAnalysisDetailModel.ExportCategory
source: html/220c4962-8aa4-f5ad-14cc-20b463a07efe.htm
---
# Autodesk.Revit.DB.Analysis.EnergyAnalysisDetailModel.ExportCategory Property

Export elements of this category in energy analysis.

## Syntax (C#)
```csharp
public ElementId ExportCategory { get; set; }
```

## Remarks
Export will be based on the space type associated with the product creating it.
 Valid categories are Rooms or MEP Spaces.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

