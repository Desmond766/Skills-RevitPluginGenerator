---
kind: method
id: M:Autodesk.Revit.DB.SketchEditScope.IsElementWithoutSketch(Autodesk.Revit.DB.ElementId)
source: html/ca9debb4-73b6-ce7c-742a-f7a8ab0588da.htm
---
# Autodesk.Revit.DB.SketchEditScope.IsElementWithoutSketch Method

Validates if an element can have a sketch but currently does not.

## Syntax (C#)
```csharp
public bool IsElementWithoutSketch(
	ElementId elementId
)
```

## Parameters
- **elementId** (`Autodesk.Revit.DB.ElementId`) - The element id to be checked.

## Returns
True if the element doesn't have a sketch, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

