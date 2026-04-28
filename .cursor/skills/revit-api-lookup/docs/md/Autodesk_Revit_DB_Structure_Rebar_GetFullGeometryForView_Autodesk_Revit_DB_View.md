---
kind: method
id: M:Autodesk.Revit.DB.Structure.Rebar.GetFullGeometryForView(Autodesk.Revit.DB.View)
zh: 钢筋、配筋
source: html/83481a4d-861e-dd0f-bf8c-d0dbe11a18d5.htm
---
# Autodesk.Revit.DB.Structure.Rebar.GetFullGeometryForView Method

**中文**: 钢筋、配筋

Generates full geometry for the Rebar for a specific view.

## Syntax (C#)
```csharp
public GeometryElement GetFullGeometryForView(
	View view
)
```

## Parameters
- **view** (`Autodesk.Revit.DB.View`) - The view in which the geometry is generated.

## Returns
The generated geometry of the Rebar before cutting is applied.

## Remarks
The result of this method differs from Element.Geometry in that Element.Geometry will return
 the rebar geometry cut by the view extents (such as the section box). In this method the entire Rebar geometry
 is returned for the given view, before cutting.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

