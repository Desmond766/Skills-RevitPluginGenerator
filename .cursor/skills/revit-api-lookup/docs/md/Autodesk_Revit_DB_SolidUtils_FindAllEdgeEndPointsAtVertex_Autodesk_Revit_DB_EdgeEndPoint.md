---
kind: method
id: M:Autodesk.Revit.DB.SolidUtils.FindAllEdgeEndPointsAtVertex(Autodesk.Revit.DB.EdgeEndPoint)
source: html/4a7c822c-3be0-52b6-cdca-3cd6496759c5.htm
---
# Autodesk.Revit.DB.SolidUtils.FindAllEdgeEndPointsAtVertex Method

Find all EdgeEndPoints at a vertex identified by the input EdgeEndPoint.

## Syntax (C#)
```csharp
public static IList<EdgeEndPoint> FindAllEdgeEndPointsAtVertex(
	EdgeEndPoint edgeEndPoint
)
```

## Parameters
- **edgeEndPoint** (`Autodesk.Revit.DB.EdgeEndPoint`) - The input EdgeEndPoint that identifies the vertex.

## Returns
All EdgeEndPoints at the vertex. The input EdgeEndPoint is also included.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Failed to find all EdgeEndPoints at a vertex identified by the input EdgeEndPoint.

