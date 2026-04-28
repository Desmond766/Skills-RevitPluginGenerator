---
kind: method
id: M:Autodesk.Revit.DB.PartMakerMethodToDivideVolumes.SetOffsetForIntersectingReference(Autodesk.Revit.DB.ElementId,System.Double)
source: html/279c15d1-4da8-aba2-4a1a-fc298b5ed987.htm
---
# Autodesk.Revit.DB.PartMakerMethodToDivideVolumes.SetOffsetForIntersectingReference Method

Sets offset for the intersecting reference.

## Syntax (C#)
```csharp
public void SetOffsetForIntersectingReference(
	ElementId intersectingReference,
	double offset
)
```

## Parameters
- **intersectingReference** (`Autodesk.Revit.DB.ElementId`) - The intersecting reference that will be offset.
- **offset** (`System.Double`) - The new offset.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - PartMaker does not use the specified intersecting reference.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

