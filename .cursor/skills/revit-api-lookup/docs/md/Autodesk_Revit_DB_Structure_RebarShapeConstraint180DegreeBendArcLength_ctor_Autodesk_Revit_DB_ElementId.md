---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarShapeConstraint180DegreeBendArcLength.#ctor(Autodesk.Revit.DB.ElementId)
source: html/15798325-41ca-6fcf-d299-6421ad500f52.htm
---
# Autodesk.Revit.DB.Structure.RebarShapeConstraint180DegreeBendArcLength.#ctor Method

Create a 180-degree bend constraint driven by arc length.

## Syntax (C#)
```csharp
public RebarShapeConstraint180DegreeBendArcLength(
	ElementId paramId
)
```

## Parameters
- **paramId** (`Autodesk.Revit.DB.ElementId`) - The Id of a Rebar Shape parameter.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - paramId is not a valid Element identifier.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

