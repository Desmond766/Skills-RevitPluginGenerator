---
kind: method
id: M:Autodesk.Revit.DB.PartMakerMethodToDivideVolumes.AreElementsValidIntersectingReferences(System.Collections.Generic.ICollection{Autodesk.Revit.DB.ElementId})
source: html/8618a886-e9f8-b9d4-2760-7871f66e0ee3.htm
---
# Autodesk.Revit.DB.PartMakerMethodToDivideVolumes.AreElementsValidIntersectingReferences Method

Identifies if provided members are valid.

## Syntax (C#)
```csharp
public bool AreElementsValidIntersectingReferences(
	ICollection<ElementId> elementIds
)
```

## Parameters
- **elementIds** (`System.Collections.Generic.ICollection < ElementId >`) - Element ids to be tested for validity for intersecting references.

## Returns
True if all references are valid, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

