---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarConstraint.GetPositiveOffsetDirectionForToOtherRebarConstraint
source: html/274367b0-af58-414a-e213-f600bdb2cb40.htm
---
# Autodesk.Revit.DB.Structure.RebarConstraint.GetPositiveOffsetDirectionForToOtherRebarConstraint Method

Returns the positive offset direction vector.

## Syntax (C#)
```csharp
public XYZ GetPositiveOffsetDirectionForToOtherRebarConstraint()
```

## Returns
The positive offset direction vector.

## Remarks
This is available only for constraints of type ToOtherRebar . Valid TargetRebarConstraintType are: RebarPlane Edge OutOfPlaneExtent StartOfBar , only if the RebarShape has a definition of RebarShapeMultiplanarDefinition with [!:RebarShapeMultiplanarDefinition::IsStartConnectorPressent] EndOfBar , only if the RebarShape has a definition of RebarShapeMultiplanarDefinition with [!:RebarShapeMultiplanarDefinition::IsEndConnectorPressent]

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - RebarConstraint is no longer valid.
 -or-
 The RebarConstraint is not of RebarConstraintType 'ToOtherRebar.'
 -or-
 The TargetRebarConstraintType is not valid.

