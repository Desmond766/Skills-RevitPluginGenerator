---
kind: method
id: M:Autodesk.Revit.DB.ContourSetting.EnableItem(Autodesk.Revit.DB.ContourSettingItem)
source: html/cccac315-c3a5-9379-0382-249eb94ee1df.htm
---
# Autodesk.Revit.DB.ContourSetting.EnableItem Method

Enable a contour setting item of the current contour setting so that the item will be used to draw contours.

## Syntax (C#)
```csharp
public void EnableItem(
	ContourSettingItem item
)
```

## Parameters
- **item** (`Autodesk.Revit.DB.ContourSettingItem`) - The contour setting item to be enabled.

## Remarks
Contour setting will not be changed if the item could not be found.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

