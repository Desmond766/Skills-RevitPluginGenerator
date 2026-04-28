---
kind: type
id: T:Autodesk.Revit.DB.Analysis.RouteAnalysisSettings
source: html/e6742b6a-9c35-5344-736b-7bf9af6f4254.htm
---
# Autodesk.Revit.DB.Analysis.RouteAnalysisSettings

RouteAnalysisSettings is an element which contains project-wide settings for route calculations.
 The PathOfTravel element uses these settings to calculate a route between two points in a plan view. By default, the route will go around the geometry of all visible model elements which have model geometry in the Route Analysis Zone. The Route Analysis Zone, determined per view, is the space between these two horizontal planes:
 a top plane vertically offset by AnalysisZoneTopOffset above the view's level and
 a bottom plane vertically offset by AnalysisZoneBottomOffset ft above the view's level. 
 By default, the route will ignore the following elements:
 elements outside of the crop region of the view; elements without any model geometry (annotations or view-specific elements); model lines (category OST_Lines); demolished elements; elements displayed in the underlay of the view. 
 There are a few ways to customize Route Analysis on a project-wide basis.
 You can adjust the Route Analysis Zone using AnalysisZoneTopOffset 
 and AnalysisZoneBottomOffset . You can specify a set of model categories you would like ignored during route calculation.
 To enable ignoring the set of specified categories, set EnableIgnoredCategoryIds to true.
 To change the set of ignored categories, use SetIgnoredCategoryIds method
 and IgnoreImports and IgnorePointClouds properties.
 To query the set of ignored categories, use GetIgnoredCategoryIds .

## Syntax (C#)
```csharp
public class RouteAnalysisSettings : Element
```

