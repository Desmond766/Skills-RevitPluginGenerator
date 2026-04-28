---
kind: method
id: M:Autodesk.Revit.DB.Architecture.TopographySurface.Create(Autodesk.Revit.DB.Document,System.Collections.Generic.IList{Autodesk.Revit.DB.XYZ},System.Collections.Generic.IList{Autodesk.Revit.DB.PolymeshFacet})
zh: 创建、新建、生成、建立、新增
source: html/5fa47ddd-7dbd-ae8a-69bc-9e260ec56d99.htm
---
# Autodesk.Revit.DB.Architecture.TopographySurface.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new topography surface element from facets and adds it to the document.

## Syntax (C#)
```csharp
[ObsoleteAttribute("This method is deprecated in Revit 2024 with the introduction of the new Toposolid elements.  It is recommended that Toposolid elements should be used in place of TopographySurface elements.")]
public static TopographySurface Create(
	Document document,
	IList<XYZ> points,
	IList<PolymeshFacet> facets
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document to be modified.
- **points** (`System.Collections.Generic.IList < XYZ >`) - A collection of points.
 The points represent an enclosed area in the XY plane.
- **facets** (`System.Collections.Generic.IList < PolymeshFacet >`) - Triangle facets composing a polygon mesh.
 Every facet contains 3 integers representing vertex indices.

## Returns
The new topography surface.

## Remarks
The document will be regenerated during the creation of this topography surface element.
 The topography surface created by facet cannot modify its triangle points and facets.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - document is not a project document.
 -or-
 There are invalid facets. Facets with more than two points with same x, y are not allowed.
 -or-
 There is(are) reference gap(s) between input arguments: points and facets.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - The document is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The document is being loaded, or is in the midst of another
 sensitive process.
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - The document has no open transaction.

