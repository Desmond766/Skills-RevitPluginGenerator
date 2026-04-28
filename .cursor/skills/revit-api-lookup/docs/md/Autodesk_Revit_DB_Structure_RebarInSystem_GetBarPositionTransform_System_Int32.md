---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarInSystem.GetBarPositionTransform(System.Int32)
source: html/63195c82-5b20-91bd-9836-f259a1373418.htm
---
# Autodesk.Revit.DB.Structure.RebarInSystem.GetBarPositionTransform Method

Return a transform representing the relative position of any
 individual bar in the set.

## Syntax (C#)
```csharp
public Transform GetBarPositionTransform(
	int barPositionIndex
)
```

## Parameters
- **barPositionIndex** (`System.Int32`) - An index between 0 and (NumberOfBarPositions-1).

## Returns
The position of a bar in the set relative to the first position.

## Remarks
The transform is a translation along the distribution path.
 It can be applied to the results of GetCenterlineCurves() to
 produce any bar in the rebar set. For barPositionIndex=0,
 the identity transform is always returned.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - barPositionIndex is not in the range [ 0, NumberOfBarPositions-1 ].

