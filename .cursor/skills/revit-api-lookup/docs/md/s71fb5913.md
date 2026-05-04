---
kind: method
id: M:Autodesk.Revit.DB.CurveByPointsUtils.ValidateCurveElementIdArrayForFaceRegions(Autodesk.Revit.DB.Document,System.Collections.Generic.IList{Autodesk.Revit.DB.ElementId})
source: html/32b7739d-f1cf-2c6c-402b-6bd9c6751e47.htm
---
# Autodesk.Revit.DB.CurveByPointsUtils.ValidateCurveElementIdArrayForFaceRegions Method

Validates that the input CurveElements can define FaceRegions.
 The CurveElements must be CurveByPoints. Each curve must be entirely hosted by a single Face or hosts related to a common
 Face (for example, Edges of a common Face, other CurveElements hosted by a common Face). To be added to the FaceRegion definition,
 a CurveElement must have the SketchOnSurface attribute set.

## Syntax (C#)
```csharp
public static bool ValidateCurveElementIdArrayForFaceRegions(
	Document document,
	IList<ElementId> curveElemIds
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The Document.
- **curveElemIds** (`System.Collections.Generic.IList < ElementId >`) - The CurveElements.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

