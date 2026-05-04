---
kind: method
id: M:Autodesk.Revit.DB.ContourSetting.AddSingleContour(System.Double,Autodesk.Revit.DB.ElementId)
source: html/f7e5c3d5-8ef1-42fe-8f0d-eb3c9f2d3964.htm
---
# Autodesk.Revit.DB.ContourSetting.AddSingleContour Method

Add a single contour as a contour setting item to the current contour setting.

## Syntax (C#)
```csharp
public ContourSettingItem AddSingleContour(
	double elevation,
	ElementId subcategoryId
)
```

## Parameters
- **elevation** (`System.Double`) - The contour elevation.
- **subcategoryId** (`Autodesk.Revit.DB.ElementId`) - The contour line style subcategory id.

## Returns
The newly added contour setting item.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given value for elevation is not finite
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

