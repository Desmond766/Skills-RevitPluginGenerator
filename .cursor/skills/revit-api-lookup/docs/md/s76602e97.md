---
kind: method
id: M:Autodesk.Revit.Creation.Application.NewUV(System.Double,System.Double)
source: html/c90505ea-a5d7-11f4-035f-adbf6187b1f7.htm
---
# Autodesk.Revit.Creation.Application.NewUV Method

Creates a UV object representing coordinates in 2-space with supplied values.

## Syntax (C#)
```csharp
public UV NewUV(
	double u,
	double v
)
```

## Parameters
- **u** (`System.Double`) - The first coordinate.
- **v** (`System.Double`) - The second coordinate.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when setting an infinite number to the U or V property.

