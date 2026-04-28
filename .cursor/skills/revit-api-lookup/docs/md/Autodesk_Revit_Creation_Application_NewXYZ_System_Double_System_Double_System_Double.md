---
kind: method
id: M:Autodesk.Revit.Creation.Application.NewXYZ(System.Double,System.Double,System.Double)
source: html/4abe3b51-cbb9-90c8-1cdc-a87296dce802.htm
---
# Autodesk.Revit.Creation.Application.NewXYZ Method

Creates a XYZ object representing coordinates in 3-space with supplied values.

## Syntax (C#)
```csharp
public XYZ NewXYZ(
	double x,
	double y,
	double z
)
```

## Parameters
- **x** (`System.Double`) - The first coordinate.
- **y** (`System.Double`) - The second coordinate.
- **z** (`System.Double`) - The third coordinate.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when setting an infinite number to the X, Y or Z property.

