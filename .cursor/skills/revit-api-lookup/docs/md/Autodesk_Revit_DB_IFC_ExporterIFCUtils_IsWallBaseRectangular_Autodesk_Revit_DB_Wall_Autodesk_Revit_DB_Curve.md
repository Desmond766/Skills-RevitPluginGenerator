---
kind: method
id: M:Autodesk.Revit.DB.IFC.ExporterIFCUtils.IsWallBaseRectangular(Autodesk.Revit.DB.Wall,Autodesk.Revit.DB.Curve)
source: html/142a4cf2-35ee-3bfc-0a62-17485d4d4a2a.htm
---
# Autodesk.Revit.DB.IFC.ExporterIFCUtils.IsWallBaseRectangular Method

Identifies if the wall's base can be represented by a direct thickening of the wall's base curve.

## Syntax (C#)
```csharp
public static bool IsWallBaseRectangular(
	Wall wall,
	Curve curve
)
```

## Parameters
- **wall** (`Autodesk.Revit.DB.Wall`) - The wall.
- **curve** (`Autodesk.Revit.DB.Curve`) - The wall's base curve.

## Returns
True if the wall's base can be represented by a direct thickening of the wall's base curve.
 False if the wall's base shape is affected by other geometry, and thus cannot be represented
 by a direct thickening of the wall's base cure.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The input curve points to a helical curve and is not supported for this operation.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

