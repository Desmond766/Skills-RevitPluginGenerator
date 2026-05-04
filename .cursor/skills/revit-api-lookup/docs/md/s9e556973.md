---
kind: method
id: M:Autodesk.Revit.DB.PartMakerMethodToDivideVolumes.IsElementValidIntersectingReference(Autodesk.Revit.DB.ElementId)
source: html/66c65e99-b215-b2b8-ed77-246010a463b9.htm
---
# Autodesk.Revit.DB.PartMakerMethodToDivideVolumes.IsElementValidIntersectingReference Method

Identifies if the provided member is valid.

## Syntax (C#)
```csharp
public bool IsElementValidIntersectingReference(
	ElementId elementId
)
```

## Parameters
- **elementId** (`Autodesk.Revit.DB.ElementId`) - Element ids to be tested for validity for intersecting references.

## Returns
True if the reference is valid, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

