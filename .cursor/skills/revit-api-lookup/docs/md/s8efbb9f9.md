---
kind: method
id: M:Autodesk.Revit.DB.PartMakerMethodToDivideVolumes.AreElementsValidIntersectingReferences(Autodesk.Revit.DB.Document,System.Collections.Generic.ICollection{Autodesk.Revit.DB.ElementId})
source: html/62fea5bb-3058-55da-0310-9ee3de1b23f9.htm
---
# Autodesk.Revit.DB.PartMakerMethodToDivideVolumes.AreElementsValidIntersectingReferences Method

Identifies if provided members are valid.

## Syntax (C#)
```csharp
public static bool AreElementsValidIntersectingReferences(
	Document document,
	ICollection<ElementId> elementIds
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **elementIds** (`System.Collections.Generic.ICollection < ElementId >`) - Element ids to be tested for validity for intersecting references.

## Returns
True if all references are valid, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

