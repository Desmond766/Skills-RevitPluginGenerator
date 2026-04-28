---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarCoupler.GetCouplerPositionTransform(System.Int32)
source: html/78db7785-7069-4511-747e-ea0de2702e8d.htm
---
# Autodesk.Revit.DB.Structure.RebarCoupler.GetCouplerPositionTransform Method

Return a transform representing the relative position of the coupler at index couplerPositionIndex in the set.

## Syntax (C#)
```csharp
public Transform GetCouplerPositionTransform(
	int couplerPositionIndex
)
```

## Parameters
- **couplerPositionIndex** (`System.Int32`) - An index between 0 and (CouplerQuantity-1).

## Returns
Returns a transformation that is composed from :
 - a translation from (0, 0, 0) to coupler origin
 - a rotation that will align the coupler with the bar segment on which it stays.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - couplerPositionIndex is not in the range [ 0, CouplerQuantity-1 ].

