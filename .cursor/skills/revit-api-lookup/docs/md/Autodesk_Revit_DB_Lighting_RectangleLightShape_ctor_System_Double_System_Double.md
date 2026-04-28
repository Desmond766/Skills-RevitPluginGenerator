---
kind: method
id: M:Autodesk.Revit.DB.Lighting.RectangleLightShape.#ctor(System.Double,System.Double)
source: html/a22d32f7-0b21-2f3d-c616-9852142859ef.htm
---
# Autodesk.Revit.DB.Lighting.RectangleLightShape.#ctor Method

Creates a rectangle light shape object with the given emit length and width.

## Syntax (C#)
```csharp
public RectangleLightShape(
	double emitLength,
	double emitWidth
)
```

## Parameters
- **emitLength** (`System.Double`) - The emit length as a numerical value in feet between 1.0e-9 and 30000.0
- **emitWidth** (`System.Double`) - The emit width as a numerical value in feet between 1.0e-9 and 30000.0

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The shape dimension is not valid because it is not between 1.0e-9 and 30000.0.

