---
kind: method
id: M:Autodesk.Revit.DB.PartMakerMethodToDivideVolumes.AddIntersectingReference(Autodesk.Revit.DB.ElementId,System.Double)
source: html/d89e0f75-8a79-ed71-1c62-548009007c6f.htm
---
# Autodesk.Revit.DB.PartMakerMethodToDivideVolumes.AddIntersectingReference Method

Adds intersecting reference with an offset.

## Syntax (C#)
```csharp
public bool AddIntersectingReference(
	ElementId intersectingReference,
	double offset
)
```

## Parameters
- **intersectingReference** (`Autodesk.Revit.DB.ElementId`) - Id of the new intersecting reference.
- **offset** (`System.Double`) - The Offste for the new intersecting reference.

## Returns
True if the PartMaker did not already use this
 intersecting reference and it was added, false if the PartMaker
 already used this intersecting reference and this call
 only updated its offset.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The element id was not permitted as intersecting references.
 Intersecting references should be levels, grids, or reference planes.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

