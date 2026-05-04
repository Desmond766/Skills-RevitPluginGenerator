---
kind: method
id: M:Autodesk.Revit.DB.ContourSetting.AddContourRange(System.Double,System.Double,System.Double,Autodesk.Revit.DB.ElementId)
source: html/078c56cd-c445-c4a0-1c75-0822639a90b6.htm
---
# Autodesk.Revit.DB.ContourSetting.AddContourRange Method

Add a set of contours as a contour setting item to the current contour setting.

## Syntax (C#)
```csharp
public ContourSettingItem AddContourRange(
	double start,
	double stop,
	double step,
	ElementId subcategoryId
)
```

## Parameters
- **start** (`System.Double`) - The contour range start elevation.
- **stop** (`System.Double`) - The contour range stop elevation.
 Should be greater than start elevation.
- **step** (`System.Double`) - The increment elevation of the contour range.
 Should be greater than zero.
- **subcategoryId** (`Autodesk.Revit.DB.ElementId`) - The contour line style subcategory id.

## Returns
The newly added contour setting item.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given value for start is not finite
 -or-
 The given value for stop is not finite
 -or-
 The given value for step is not finite
 -or-
 The input subcategory id is not valid.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The input contour spacing information is not valid.

