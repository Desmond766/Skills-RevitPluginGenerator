---
kind: method
id: M:Autodesk.Revit.DB.DividedSurface.AddIntersectionElement(Autodesk.Revit.DB.ElementId)
source: html/ac41d76c-ea3f-bb52-f9bb-c2cd064a25f8.htm
---
# Autodesk.Revit.DB.DividedSurface.AddIntersectionElement Method

Adds an intersection element to the divided surface.

## Syntax (C#)
```csharp
public void AddIntersectionElement(
	ElementId newIntersectionElemId
)
```

## Parameters
- **newIntersectionElemId** (`Autodesk.Revit.DB.ElementId`) - The intersection element to be added.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The element newIntersectionElemId is not a level, grid, reference plane,
 or a curve element whose category is lines and reference lines.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

