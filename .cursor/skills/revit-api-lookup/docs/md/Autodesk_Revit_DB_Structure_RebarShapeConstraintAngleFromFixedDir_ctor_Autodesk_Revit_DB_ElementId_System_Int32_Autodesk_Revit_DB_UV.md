---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarShapeConstraintAngleFromFixedDir.#ctor(Autodesk.Revit.DB.ElementId,System.Int32,Autodesk.Revit.DB.UV)
source: html/276b3991-2c0e-da22-e7f2-21eaab0a7cf4.htm
---
# Autodesk.Revit.DB.Structure.RebarShapeConstraintAngleFromFixedDir.#ctor Method

Create an angular constraint.

## Syntax (C#)
```csharp
public RebarShapeConstraintAngleFromFixedDir(
	ElementId paramId,
	int sign,
	UV direction
)
```

## Parameters
- **paramId** (`Autodesk.Revit.DB.ElementId`) - A Rebar Shape parameter of type UT_Angle.
- **sign** (`System.Int32`) - The sign of the angle relative to the direction.
- **direction** (`Autodesk.Revit.DB.UV`) - A fixed direction in UV-space.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - sign is not 1 or -1.
 -or-
 paramId is not a valid Element identifier.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - direction has zero length.

