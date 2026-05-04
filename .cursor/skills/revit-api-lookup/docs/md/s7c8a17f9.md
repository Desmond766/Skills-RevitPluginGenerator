---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarShapeConstraint.GetParamId
source: html/bfb42a51-8d55-41f3-aea9-21f60b228923.htm
---
# Autodesk.Revit.DB.Structure.RebarShapeConstraint.GetParamId Method

Return the Id of the parameter associated with this constraint.

## Syntax (C#)
```csharp
public ElementId GetParamId()
```

## Returns
The Id of the parameter, or InvalidElementId if the constraint
 does not have one.

## Remarks
Most subclasses of RebarShapeConstraint require a parameter.

