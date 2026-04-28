---
kind: method
id: M:Autodesk.Revit.DB.PartMakerMethodToDivideVolumes.IsElementValidIntersectingReference(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
source: html/e12094d2-0ca5-74a9-33b4-3108e8b19bfd.htm
---
# Autodesk.Revit.DB.PartMakerMethodToDivideVolumes.IsElementValidIntersectingReference Method

Identifies if the provided member is valid.

## Syntax (C#)
```csharp
public static bool IsElementValidIntersectingReference(
	Document document,
	ElementId elementId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **elementId** (`Autodesk.Revit.DB.ElementId`) - Element ids to be tested for validity for intersecting references.

## Returns
True if the reference is valid, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

