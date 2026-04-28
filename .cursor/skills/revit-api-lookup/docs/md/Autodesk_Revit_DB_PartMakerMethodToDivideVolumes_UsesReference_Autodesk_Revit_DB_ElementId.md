---
kind: method
id: M:Autodesk.Revit.DB.PartMakerMethodToDivideVolumes.UsesReference(Autodesk.Revit.DB.ElementId)
source: html/6a15b8fb-e999-bf80-c362-d028cd10976f.htm
---
# Autodesk.Revit.DB.PartMakerMethodToDivideVolumes.UsesReference Method

Identifies if the PartMaker uses the intersecting reference.

## Syntax (C#)
```csharp
public bool UsesReference(
	ElementId intersectingReference
)
```

## Parameters
- **intersectingReference** (`Autodesk.Revit.DB.ElementId`) - Intersecting reference to be tested.

## Returns
True if the intersecting reference is used by the PartMaker.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

