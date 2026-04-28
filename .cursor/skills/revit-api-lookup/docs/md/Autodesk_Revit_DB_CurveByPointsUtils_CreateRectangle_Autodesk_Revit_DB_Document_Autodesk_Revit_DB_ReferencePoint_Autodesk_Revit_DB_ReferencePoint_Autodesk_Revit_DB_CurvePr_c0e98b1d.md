---
kind: method
id: M:Autodesk.Revit.DB.CurveByPointsUtils.CreateRectangle(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ReferencePoint,Autodesk.Revit.DB.ReferencePoint,Autodesk.Revit.DB.CurveProjectionType,System.Boolean,System.Boolean,System.Collections.Generic.IList{Autodesk.Revit.DB.ElementId}@,System.Collections.Generic.IList{Autodesk.Revit.DB.ElementId}@)
source: html/8d86256e-611d-0f81-e984-df9e0c6a6227.htm
---
# Autodesk.Revit.DB.CurveByPointsUtils.CreateRectangle Method

Creates rectangle on face or sketchplane for two given diagonal points.

## Syntax (C#)
```csharp
public static void CreateRectangle(
	Document document,
	ReferencePoint startPoint,
	ReferencePoint endPoint,
	CurveProjectionType projectionType,
	bool boundaryReferenceLines,
	bool boundaryCurvesFollowSurface,
	out IList<ElementId> createdCurvesIds,
	out IList<ElementId> createdCornersIds
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The Document.
- **startPoint** (`Autodesk.Revit.DB.ReferencePoint`) - First diagonal point of rectangle.
- **endPoint** (`Autodesk.Revit.DB.ReferencePoint`) - Second diagonal point of rectangle.
- **projectionType** (`Autodesk.Revit.DB.CurveProjectionType`) - Projection type of rectangle's boundary curves.
 If the rectangle input points are Face hosted, and CurveProjectionType::ParallelToLevel is requested,
 and the Face normal at the location of the start point is at a less than 45 degree angle with the level
 planes, then the projectionType will be set to FromTopDown, even if ParallelToLevel was requested.
- **boundaryReferenceLines** (`System.Boolean`) - True if rectangle's boundary curves should be reference lines, false otherwise.
- **boundaryCurvesFollowSurface** (`System.Boolean`) - True if rectangle's boundary curves should follow surface, false otherwise.
- **createdCurvesIds** (`System.Collections.Generic.IList < ElementId > %`) - Created rectangle's boundary curves ids.
- **createdCornersIds** (`System.Collections.Generic.IList < ElementId > %`) - Ids of two newly created corner points.

## Remarks
This array contains the ElementIds of the two additional corner points that are created to complete the rectangle.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - Unexpected projection type.
 -or-
 A value passed for an enumeration argument is not a member of that enumeration
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Unable to create rectangle.

