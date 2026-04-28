---
kind: method
id: M:Autodesk.Revit.DB.PartMakerMethodToDivideVolumes.RemoveIntersectingReference(Autodesk.Revit.DB.ElementId)
source: html/3873a75b-0c76-3c03-fd4e-390f8e83e2c5.htm
---
# Autodesk.Revit.DB.PartMakerMethodToDivideVolumes.RemoveIntersectingReference Method

Removed intersecting reference.

## Syntax (C#)
```csharp
public bool RemoveIntersectingReference(
	ElementId intersectingReference
)
```

## Parameters
- **intersectingReference** (`Autodesk.Revit.DB.ElementId`) - Id of the intersecting reference to remove.

## Returns
True if the PartMaker used this intersecting reference and
 this call removed it, false if the PartMaker did not use this
 intersecting reference.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The element id was not permitted as intersecting references.
 Intersecting references should be levels, grids, or reference planes.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

