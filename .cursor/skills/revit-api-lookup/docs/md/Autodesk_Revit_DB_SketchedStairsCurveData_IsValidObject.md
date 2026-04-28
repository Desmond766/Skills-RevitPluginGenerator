---
kind: property
id: P:Autodesk.Revit.DB.SketchedStairsCurveData.IsValidObject
source: html/7c5babd9-40f7-15a3-1588-caa3196fdf19.htm
---
# Autodesk.Revit.DB.SketchedStairsCurveData.IsValidObject Property

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

