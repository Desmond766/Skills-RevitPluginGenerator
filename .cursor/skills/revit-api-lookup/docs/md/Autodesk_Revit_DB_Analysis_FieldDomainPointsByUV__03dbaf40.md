---
kind: other
id: Methods.T:Autodesk.Revit.DB.Analysis.FieldDomainPointsByUV
source: html/49b328f4-ea98-9d9a-e594-047ca48c2cb4.htm
---
# FieldDomainPointsByUV Methods

Set u and v coordinates that specify a grid on the surface.
 The display of the grid is controlled by AnalysisDisplayColoredSurfaceSettings::getShowGridLines().
 If AnalysisDisplayColoredSurfaceSettings::getShowGridLines() returns true and both sets are empty
 then a grid will be displayed using a default spacing; if only one of the sets is non-empty, then
 only the corresponding set of grid lines will be displayed, i.e. the grid will consist solely of
 parallel lines at the specified coordinates.

