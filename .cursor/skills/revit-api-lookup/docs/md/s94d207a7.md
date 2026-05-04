---
kind: method
id: M:Autodesk.Revit.DB.Lighting.CircleLightShape.#ctor(System.Double)
source: html/9dd751b4-2912-b87e-c083-14c453e6f590.htm
---
# Autodesk.Revit.DB.Lighting.CircleLightShape.#ctor Method

Creates a circle light shape object with the given emit diameter.

## Syntax (C#)
```csharp
public CircleLightShape(
	double emitDiameter
)
```

## Parameters
- **emitDiameter** (`System.Double`) - The emit diameter as a numerical value in feet between 1.0e-9 and 30000.0

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The shape dimension is not valid because it is not between 1.0e-9 and 30000.0.

