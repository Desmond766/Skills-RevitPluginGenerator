---
kind: property
id: P:Autodesk.Revit.DB.Analysis.AnalysisDisplayColorEntry.IsValidObject
source: html/90b4e1f7-8509-eb98-fb2f-1bac72a7208b.htm
---
# Autodesk.Revit.DB.Analysis.AnalysisDisplayColorEntry.IsValidObject Property

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

