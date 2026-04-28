---
kind: method
id: M:Autodesk.Revit.DB.DividedSurface.CanBeIntersectionElement(Autodesk.Revit.DB.ElementId)
source: html/208f7d38-eea3-5676-1eb6-d5ccaee8eda7.htm
---
# Autodesk.Revit.DB.DividedSurface.CanBeIntersectionElement Method

Checks if the element can be an intersection reference.

## Syntax (C#)
```csharp
public bool CanBeIntersectionElement(
	ElementId id
)
```

## Parameters
- **id** (`Autodesk.Revit.DB.ElementId`) - The element to be checked.

## Returns
True if the element can be an intersection reference., false otherwise.

## Remarks
The element must be a level, grid, reference plane,
 or a curve element whose category is lines and reference lines.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

