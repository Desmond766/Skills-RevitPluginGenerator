---
kind: method
id: M:Autodesk.Revit.DB.Analysis.RouteAnalysisSettings.IsLargeGeometryAllowed
source: html/1652ef5d-f6bb-2f50-57a4-69b5751ba671.htm
---
# Autodesk.Revit.DB.Analysis.RouteAnalysisSettings.IsLargeGeometryAllowed Method

Returns if large geometry is allowed for path of travel creation or not.

## Syntax (C#)
```csharp
public bool IsLargeGeometryAllowed()
```

## Remarks
The return value is based off the current setting for the AllowLargeGeometry Property as follows:
 If it is set to Prompt, then prompts the user to continue or not, if no ui is present, returns false. If it is set to DisAllaow, returns false. If it is set to Allow, returns true.

