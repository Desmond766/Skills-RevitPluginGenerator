---
kind: method
id: M:Autodesk.Revit.DB.CurveByPointsUtils.GetHostFace(Autodesk.Revit.DB.CurveElement)
source: html/19436661-0781-47be-8880-43f0eb451baf.htm
---
# Autodesk.Revit.DB.CurveByPointsUtils.GetHostFace Method

Gets the host face to which the CurveElement is added.

## Syntax (C#)
```csharp
public static Reference GetHostFace(
	CurveElement curveElem
)
```

## Parameters
- **curveElem** (`Autodesk.Revit.DB.CurveElement`) - The CurveElement.

## Returns
The host face to which the CurveElement is added, or an empty Reference if the host is not a face.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The input CurveElement is not a CurveByPoints.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

