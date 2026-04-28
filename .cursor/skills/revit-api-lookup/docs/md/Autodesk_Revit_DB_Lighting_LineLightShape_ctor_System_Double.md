---
kind: method
id: M:Autodesk.Revit.DB.Lighting.LineLightShape.#ctor(System.Double)
source: html/1fdbec29-e0ca-ed2e-7bac-56b61e96b0a4.htm
---
# Autodesk.Revit.DB.Lighting.LineLightShape.#ctor Method

Creates a line light shape object with the given emit length.

## Syntax (C#)
```csharp
public LineLightShape(
	double emitLength
)
```

## Parameters
- **emitLength** (`System.Double`) - The emit length as a numerical value in feet between 1.0e-9 and 30000.0

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The shape dimension is not valid because it is not between 1.0e-9 and 30000.0.

