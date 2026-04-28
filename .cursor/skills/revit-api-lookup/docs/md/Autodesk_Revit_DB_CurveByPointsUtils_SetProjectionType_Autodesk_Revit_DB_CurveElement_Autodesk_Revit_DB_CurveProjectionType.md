---
kind: method
id: M:Autodesk.Revit.DB.CurveByPointsUtils.SetProjectionType(Autodesk.Revit.DB.CurveElement,Autodesk.Revit.DB.CurveProjectionType)
source: html/4ca5d8c8-bb4a-71b2-57e7-4cda32c043b9.htm
---
# Autodesk.Revit.DB.CurveByPointsUtils.SetProjectionType Method

Sets the projection type of the CurveElement.

## Syntax (C#)
```csharp
public static void SetProjectionType(
	CurveElement curveElem,
	CurveProjectionType value
)
```

## Parameters
- **curveElem** (`Autodesk.Revit.DB.CurveElement`) - The CurveElement.
- **value** (`Autodesk.Revit.DB.CurveProjectionType`) - The input projection type.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The input CurveElement is not a CurveByPoints.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

