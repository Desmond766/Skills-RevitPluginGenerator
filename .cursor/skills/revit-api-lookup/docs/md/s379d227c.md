---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarInSystem.MoveBarInSet(System.Int32,Autodesk.Revit.DB.Transform)
source: html/abcc4709-c7cc-824b-1dcc-66ddb7b91aad.htm
---
# Autodesk.Revit.DB.Structure.RebarInSystem.MoveBarInSet Method

This method applies the transformation matrix to the rebar bar at the desired position in the rebar set.
 If the bar was already moved, the method will concatenate the transformation matrix with the existing movement.

## Syntax (C#)
```csharp
public void MoveBarInSet(
	int barPositionIndex,
	Transform moveTransform
)
```

## Parameters
- **barPositionIndex** (`System.Int32`) - The bar index of the rebar to apply the transformation.
- **moveTransform** (`Autodesk.Revit.DB.Transform`) - The transformation matrix to apply to the specified rebar bar.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - barPositionIndex is not in the range [ 0, NumberOfBarPositions-1 ].
- **Autodesk.Revit.Exceptions.InapplicableDataException** - For this RebarInSystem element individual bars can't be moved, excluded or included.

