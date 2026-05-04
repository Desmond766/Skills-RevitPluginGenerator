---
kind: method
id: M:Autodesk.Revit.DB.Architecture.TopographySurface.IsValidFaceSet(System.Collections.Generic.IList{Autodesk.Revit.DB.PolymeshFacet},System.Collections.Generic.IList{Autodesk.Revit.DB.XYZ})
source: html/327b0f6c-951f-93aa-f22a-271ebb118f89.htm
---
# Autodesk.Revit.DB.Architecture.TopographySurface.IsValidFaceSet Method

Identifies whether the facets can construct a valid topography surface.

## Syntax (C#)
```csharp
public static bool IsValidFaceSet(
	IList<PolymeshFacet> facets,
	IList<XYZ> points
)
```

## Parameters
- **facets** (`System.Collections.Generic.IList < PolymeshFacet >`) - The facets to be checked.
- **points** (`System.Collections.Generic.IList < XYZ >`) - A collection of points.

## Returns
True if the facets are valid, otherwise false.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - There are no points in the input points set.
 -or-
 There were not enough points to form a valid region (at least 3 are required), or the points were collinear ignoring elevation.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

