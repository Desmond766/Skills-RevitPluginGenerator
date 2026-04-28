---
kind: property
id: P:Autodesk.Revit.DB.DimensionSegment.IsLocked
source: html/eaad4211-0ffc-981f-5bb5-f095bd564897.htm
---
# Autodesk.Revit.DB.DimensionSegment.IsLocked Property

Indicates if this segment is locked.

## Syntax (C#)
```csharp
public bool IsLocked { get; set; }
```

## Remarks
This property always returns false if the dimension 
is a radial or spot dimension. 
This property cannot be set if the segment has been labeled, or
the dimension shape is a radial or spot dimension.

