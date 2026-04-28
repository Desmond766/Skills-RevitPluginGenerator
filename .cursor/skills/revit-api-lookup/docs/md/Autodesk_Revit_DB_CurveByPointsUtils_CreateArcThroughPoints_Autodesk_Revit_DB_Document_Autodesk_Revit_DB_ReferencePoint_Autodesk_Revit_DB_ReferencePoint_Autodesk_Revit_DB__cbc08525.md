---
kind: method
id: M:Autodesk.Revit.DB.CurveByPointsUtils.CreateArcThroughPoints(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ReferencePoint,Autodesk.Revit.DB.ReferencePoint,Autodesk.Revit.DB.ReferencePoint)
source: html/04482533-93ab-d3e2-db15-5f700919ab81.htm
---
# Autodesk.Revit.DB.CurveByPointsUtils.CreateArcThroughPoints Method

Creates an arc through the given reference points.

## Syntax (C#)
```csharp
public static CurveElement CreateArcThroughPoints(
	Document document,
	ReferencePoint startPoint,
	ReferencePoint endPoint,
	ReferencePoint interiorPoint
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The Document.
- **startPoint** (`Autodesk.Revit.DB.ReferencePoint`) - The start point of the arc.
- **endPoint** (`Autodesk.Revit.DB.ReferencePoint`) - The end end of the arc.
- **interiorPoint** (`Autodesk.Revit.DB.ReferencePoint`) - The interior point on the arc.

## Returns
The CurveElement to be created.

## Remarks
The interiorPoint determines the orientation of the arc while startPoint and endPoint determine
 the angle parameters at the ends.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Can't create an arc from the given points

