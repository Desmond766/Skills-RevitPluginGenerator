---
kind: method
id: M:Autodesk.Revit.DB.CurveByPointsUtils.AddCurvesToFaceRegion(Autodesk.Revit.DB.Document,System.Collections.Generic.IList{Autodesk.Revit.DB.ElementId})
source: html/d63740d4-6052-12cd-a9f5-5915103562a6.htm
---
# Autodesk.Revit.DB.CurveByPointsUtils.AddCurvesToFaceRegion Method

Adds The CurveElements to one or more FaceRegions.

## Syntax (C#)
```csharp
public static void AddCurvesToFaceRegion(
	Document document,
	IList<ElementId> curveElemIds
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The Document.
- **curveElemIds** (`System.Collections.Generic.IList < ElementId >`) - The ElementIds of CurveElements which are to define the FaceRegion.

## Remarks
The CurveElements that are input may produce an arbitrary number of regions.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - All the input CurveElements must be CurveByPoints, with the sketchOnSurface attribute set to True, and for each CurveElement, the defining
 ReferencePoints must be hosted on References related to a common Face or Edge.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Failed to add curves to FaceRegion.

