---
kind: type
id: T:Autodesk.Revit.DB.ReferenceIntersector
zh: 射线、射线相交
source: html/36f82b40-1065-2305-e260-18fc618e756f.htm
---
# Autodesk.Revit.DB.ReferenceIntersector

**中文**: 射线、射线相交

A class used to find and return elements that intersect a ray created from an origin point and direction.

## Syntax (C#)
```csharp
public class ReferenceIntersector : IDisposable
```

## Remarks
An instance of this class can be constructed to return any 3D geometric element that intersects the
 ray created by the origin and direction, or to return a subset of elements based on filtering and flags.
 The caller can opt to filter the results using an ElementFilter, or by applying a specific list of
 acceptable elements. The caller can also specify the type of object to be returned, which might be
 whole elements, geometry objects, or a combination. In all cases the caller is required to supply
 a 3D view for evaluation; the view and visibility settings on the input view will determine if a
 particular element is returned (for example, hidden elements will never be returned by this tool, nor
 will elements whose geometry is outside the section box of the view). The class is configured so that a single instance can be constructed and used for multiple evaluations of
 different rays. The results of the evaluation are not preserved between invocations on the same ReferenceIntersector. The class also offers an option to return element results encountered in Revit Links. When the
 FindReferencesInRevitLinks flag
 is set, the results may include elements in the host document and in any RevitLinkInstance encountered, depending
 on the other flags set. See the remarks for FindReferencesInRevitLinks for details on how the
 flags affect the results obtained from links.

