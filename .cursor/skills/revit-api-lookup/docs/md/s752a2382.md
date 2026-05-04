---
kind: method
id: M:Autodesk.Revit.DB.Structure.IRebarUpdateServer.GenerateCurves(Autodesk.Revit.DB.Structure.RebarCurvesData)
source: html/2b83cc23-076c-1843-f078-46d0c1f2dc74.htm
---
# Autodesk.Revit.DB.Structure.IRebarUpdateServer.GenerateCurves Method

This function is supposed to calculate the bars in set based on data received in curvesData parameter.

## Syntax (C#)
```csharp
bool GenerateCurves(
	RebarCurvesData curvesData
)
```

## Parameters
- **curvesData** (`Autodesk.Revit.DB.Structure.RebarCurvesData`) - Use the members of this class to access the inputs and define the output curves that make up the free form rebar.

## Returns
Returns true if the curve generation was successful, false otherwise.

## Remarks
This function is called in the regeneration context when at least one data in curvesData parameter was changed.

