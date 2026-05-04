---
kind: property
id: P:Autodesk.Revit.DB.Structure.RebarCurvesData.IsValidObject
source: html/d81bf889-02c0-38c7-f01e-55d8c5817575.htm
---
# Autodesk.Revit.DB.Structure.RebarCurvesData.IsValidObject Property

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

