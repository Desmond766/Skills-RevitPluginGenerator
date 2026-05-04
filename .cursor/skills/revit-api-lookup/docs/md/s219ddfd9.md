---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarShapeConstraintChordLength.#ctor(Autodesk.Revit.DB.ElementId)
source: html/12e4485e-a41c-638b-c77c-effe9262fdeb.htm
---
# Autodesk.Revit.DB.Structure.RebarShapeConstraintChordLength.#ctor Method

Create a constraint to drive chord length.

## Syntax (C#)
```csharp
public RebarShapeConstraintChordLength(
	ElementId paramId
)
```

## Parameters
- **paramId** (`Autodesk.Revit.DB.ElementId`) - The Id of a Rebar Shape parameter.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - paramId is not a valid Element identifier.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

