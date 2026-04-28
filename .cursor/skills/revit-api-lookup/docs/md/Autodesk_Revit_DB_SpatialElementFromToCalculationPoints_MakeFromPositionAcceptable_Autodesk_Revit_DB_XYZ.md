---
kind: method
id: M:Autodesk.Revit.DB.SpatialElementFromToCalculationPoints.MakeFromPositionAcceptable(Autodesk.Revit.DB.XYZ)
source: html/c873f350-1aab-cba7-19a0-27a66ad68784.htm
---
# Autodesk.Revit.DB.SpatialElementFromToCalculationPoints.MakeFromPositionAcceptable Method

This function takes a potential "from" point and converts it to be a similar point on the opposite side of the family's host from
 the "to" point if necessary.

## Syntax (C#)
```csharp
public XYZ MakeFromPositionAcceptable(
	XYZ newFromLocation
)
```

## Parameters
- **newFromLocation** (`Autodesk.Revit.DB.XYZ`) - The desired "from" location

## Returns
The valid "from" location.

## Remarks
If the point is already an acceptable "from" location then the original point will be returned. Otherwise, the point's
 X and Y will be projected onto the centerline of the family's host.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

