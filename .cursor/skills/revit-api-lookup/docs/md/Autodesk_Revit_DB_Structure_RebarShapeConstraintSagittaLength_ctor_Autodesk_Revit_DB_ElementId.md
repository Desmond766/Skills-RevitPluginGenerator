---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarShapeConstraintSagittaLength.#ctor(Autodesk.Revit.DB.ElementId)
source: html/d3c3d4db-9464-728c-4c28-6ac404878c43.htm
---
# Autodesk.Revit.DB.Structure.RebarShapeConstraintSagittaLength.#ctor Method

Create a constraint to drive sagitta length.

## Syntax (C#)
```csharp
public RebarShapeConstraintSagittaLength(
	ElementId paramId
)
```

## Parameters
- **paramId** (`Autodesk.Revit.DB.ElementId`) - The Id of a Rebar Shape parameter.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - paramId is not a valid Element identifier.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

