---
kind: property
id: P:Autodesk.Revit.DB.Analysis.AnalysisDisplayLegendSettings.IsValidObject
source: html/f16a0147-e0bd-19d8-26dc-401776980dd5.htm
---
# Autodesk.Revit.DB.Analysis.AnalysisDisplayLegendSettings.IsValidObject Property

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

