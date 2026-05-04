---
kind: type
id: T:Autodesk.Revit.DB.BoundingBoxXYZ
zh: 包围盒
source: html/3c452286-57b1-40e2-2795-c90bff1fcec2.htm
---
# Autodesk.Revit.DB.BoundingBoxXYZ

**中文**: 包围盒

A three-dimensional rectangular box at an arbitrary location and orientation within the Revit model.

## Syntax (C#)
```csharp
public class BoundingBoxXYZ : APIObject
```

## Remarks
BoundingBoxXYZ objects are used in Revit in several places related to views (for example, the section box of a
3D view or the definition of a section or detail view). BoundingBoxXYZ objects can also be obtained from elements representing the 
boundary of the element in a given view. The extents of the box are determined by three orthogonal planes extended through the minimum ( Min ) 
and maximum ( Max ) points, but the coordinates of these points and the orientation of the planes
in relation to the coordinates of the source model is determined by the box Transform ( Transform ). This class also has the ability to detect and mark certain extents as disabled. Note that in the current Revit API uses
of this class it is not expected that Revit will give objects with disabled extents, and disabled extents in objects
sent to Revit will likely be ignored.

