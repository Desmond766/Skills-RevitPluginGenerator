---
kind: property
id: P:Autodesk.Revit.DB.Analysis.EnergyAnalysisDetailModelOptions.IsValidObject
source: html/42896fca-db3d-9b7e-7cde-51a45a6e6b60.htm
---
# Autodesk.Revit.DB.Analysis.EnergyAnalysisDetailModelOptions.IsValidObject Property

Specifies whether the .NET object represents a valid Revit entity.

## Syntax (C#)
```csharp
public bool IsValidObject { get; }
```

## Returns
True if the API object holds a valid Revit native object, false otherwise.

## Remarks
If the corresponding Revit native object is destroyed, or creation of the corresponding object is undone,
 a managed API object containing it is no longer valid. API methods cannot be called on invalidated wrapper objects.

