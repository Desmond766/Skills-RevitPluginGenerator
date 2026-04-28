---
kind: type
id: T:Autodesk.Revit.DB.PointClouds.PointIterator
source: html/0fba9730-8bb6-5f89-be4b-6132121b3058.htm
---
# Autodesk.Revit.DB.PointClouds.PointIterator

A class used to iterate individual points in a PointCollection.

## Syntax (C#)
```csharp
public class PointIterator : IEnumerator<CloudPoint>
```

## Remarks
Points may be iterated in two different ways:
 In the traditional IEnumerable interface, you can iterate the resulting points directly from the PointCollection. In an unsafe interface usable only from C# and C++/CLI, you can get a pointer to the point storage of the collection and access the points directly in memory.
 Although you must deal with pointers directly, there may be performance improvements when traversing large buffers of points. 
 Regardless of the approach used to obtain the points, the points are reported in the coordinate system of the point cloud. If you need the
 points in the coordinate system of the model, you will need to transform the point in those coordinates. The most direct way to do this
 is to obtain the transformation matrix from the PointCloudInstance (GetTransform()), convert the CloudPoint to an XYZ
 using the implicit conversion operator, and use Transform.OfPoint(XYZ).

