---
kind: method
id: M:Autodesk.Revit.DB.Analysis.FieldDomainPointsByUV.SetGridCoordinates(System.Collections.Generic.ICollection{System.Double},System.Collections.Generic.ICollection{System.Double})
source: html/09df1ba9-a23c-4564-884b-d93eac3fd8d2.htm
---
# Autodesk.Revit.DB.Analysis.FieldDomainPointsByUV.SetGridCoordinates Method

Set u and v coordinates that specify a grid on the surface.
 The display of the grid is controlled by AnalysisDisplayColoredSurfaceSettings::getShowGridLines().
 If AnalysisDisplayColoredSurfaceSettings::getShowGridLines() returns true and both sets are empty
 then a grid will be displayed using a default spacing; if only one of the sets is non-empty, then
 only the corresponding set of grid lines will be displayed, i.e. the grid will consist solely of
 parallel lines at the specified coordinates.

## Syntax (C#)
```csharp
public void SetGridCoordinates(
	ICollection<double> uCoordinates,
	ICollection<double> vCoordinates
)
```

## Parameters
- **uCoordinates** (`System.Collections.Generic.ICollection < Double >`) - Set of u coordinates at which to draw grid lines
- **vCoordinates** (`System.Collections.Generic.ICollection < Double >`) - Set of v coordinates at which to draw grid lines

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

