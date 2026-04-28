---
kind: method
id: M:Autodesk.Revit.DB.PartMakerMethodToDivideVolumes.GetOffsetForIntersectingReference(Autodesk.Revit.DB.ElementId)
source: html/3b690620-3881-ee14-72dc-33e7df239417.htm
---
# Autodesk.Revit.DB.PartMakerMethodToDivideVolumes.GetOffsetForIntersectingReference Method

Gets offset for the intersecting reference.

## Syntax (C#)
```csharp
public double GetOffsetForIntersectingReference(
	ElementId intersectingReference
)
```

## Parameters
- **intersectingReference** (`Autodesk.Revit.DB.ElementId`) - The intersecting reference to obtain offset value from.

## Returns
The offset for the intersecting reference

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - PartMaker does not use the specified intersecting reference.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

