---
kind: type
id: T:Autodesk.Revit.DB.Analysis.Polyloop
source: html/207c5546-9116-fb85-8a7e-ff79654a7877.htm
---
# Autodesk.Revit.DB.Analysis.Polyloop

A Polyloop represent a planar polygon with ordered points.

## Syntax (C#)
```csharp
public class Polyloop : IDisposable
```

## Remarks
This class is a loop with straight edges bounding a planar region in space.
 The loop is represented by an ordered coplanar collection of points
 forming the vertices of the loop. The loop is composed of straight line segments
 joining a point in the collection to the succeeding point in the collection.
 The closing segment is from the last to the first point in the collection.
 The direction of the loop is in the direction of the line segments.
 All the points in the polygon defining the poly loop shall be coplanar.

