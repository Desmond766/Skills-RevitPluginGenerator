---
kind: property
id: P:Autodesk.Revit.DB.Solid.SurfaceArea
source: html/16498219-5449-68e0-1438-8467f4b0fa38.htm
---
# Autodesk.Revit.DB.Solid.SurfaceArea Property

Returns the total surface area of this solid.

## Syntax (C#)
```csharp
public double SurfaceArea { get; }
```

## Returns
The real number equal to the total area of this solid.

## Remarks
Calculates the surface area by adding together the areas of faces comprising this solid.
Will slightly underestimate if curved surfaces are present.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when this solid is not a valid Geometry object.

