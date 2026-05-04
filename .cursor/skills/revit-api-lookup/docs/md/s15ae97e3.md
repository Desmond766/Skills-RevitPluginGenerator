---
kind: method
id: M:Autodesk.Revit.DB.SpatialElementFromToCalculationPoints.MakeToPositionAcceptable(Autodesk.Revit.DB.XYZ)
source: html/638f8627-4f0a-9873-5012-6f6aef4e2c66.htm
---
# Autodesk.Revit.DB.SpatialElementFromToCalculationPoints.MakeToPositionAcceptable Method

This function takes a potential "to" point and converts it to be a similar point on the opposite side of the family's host from
 the "from" point if necessary.

## Syntax (C#)
```csharp
public XYZ MakeToPositionAcceptable(
	XYZ newToLocation
)
```

## Parameters
- **newToLocation** (`Autodesk.Revit.DB.XYZ`) - The desired "to" location

## Returns
The valid "to" location.

## Remarks
If the point is already an acceptable "to" location then the original point will be returned. Otherwise, the point's
 X and Y will be projected onto the centerline of the family's host.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

