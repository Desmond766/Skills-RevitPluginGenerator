---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarShapeMultiplanarDefinition.#ctor(System.Double)
source: html/beae8365-4492-3cd3-f70c-d2e928396f61.htm
---
# Autodesk.Revit.DB.Structure.RebarShapeMultiplanarDefinition.#ctor Method

Create a RebarShapeMultiplanarDefinition for use in creating a RebarShape.

## Syntax (C#)
```csharp
public RebarShapeMultiplanarDefinition(
	double outOfPlaneBendDiameter
)
```

## Parameters
- **outOfPlaneBendDiameter** (`System.Double`) - Bend diameter to be used when the rebar bends out of its main plane.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The given value for outOfPlaneBendDiameter must be greater than 0 and no more than 30000 feet.

