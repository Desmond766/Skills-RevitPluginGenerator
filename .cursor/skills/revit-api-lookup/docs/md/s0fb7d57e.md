---
kind: method
id: M:Autodesk.Revit.DB.CurveElement.GetAdjoinedCurveElements(System.Int32)
source: html/5f3eaf8b-047e-d287-49a9-8777af3a67da.htm
---
# Autodesk.Revit.DB.CurveElement.GetAdjoinedCurveElements Method

Returns elements that are joining with this curve element at the given end point.

## Syntax (C#)
```csharp
public ISet<ElementId> GetAdjoinedCurveElements(
	int end
)
```

## Parameters
- **end** (`System.Int32`) - Id of one the curve's end. Value '0' indicates start and '1' indicates the end of the curve, respectively.

## Returns
Collection of Ids of Curve Elements.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given Id does not represent any of the two end-points of a curve element.
 A valid value of either '0' or '1' is expected.

