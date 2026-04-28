---
kind: property
id: P:Autodesk.Revit.DB.Structure.BoundaryConditions.AssociatedLoadId
source: html/9e8cd409-59af-6426-ac76-d2cccab1908d.htm
---
# Autodesk.Revit.DB.Structure.BoundaryConditions.AssociatedLoadId Property

The Id of the internal load element associated with a boundary conditions.

## Syntax (C#)
```csharp
public ElementId AssociatedLoadId { get; set; }
```

## Remarks
ElementId may be set if the internal load exists and it's type fit the BoundaryConditions type only (Point, Line and Area).

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: elementId is not a valid Element identifier.
 -or-
 When setting this property: Throws when the ElementId does not refer to the internal load with appropriate type.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

