---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarShapeConstraintArcLength.#ctor(Autodesk.Revit.DB.ElementId)
source: html/b949a600-3225-3eca-05fd-6df4fc68709e.htm
---
# Autodesk.Revit.DB.Structure.RebarShapeConstraintArcLength.#ctor Method

Create an arc-length constraint.

## Syntax (C#)
```csharp
public RebarShapeConstraintArcLength(
	ElementId paramId
)
```

## Parameters
- **paramId** (`Autodesk.Revit.DB.ElementId`) - The Id of a Rebar Shape parameter.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - paramId is not a valid Element identifier.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

