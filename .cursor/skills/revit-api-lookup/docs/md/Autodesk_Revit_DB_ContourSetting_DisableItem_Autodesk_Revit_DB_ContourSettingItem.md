---
kind: method
id: M:Autodesk.Revit.DB.ContourSetting.DisableItem(Autodesk.Revit.DB.ContourSettingItem)
source: html/65fc1643-089a-760b-d4f9-a101ea48b8a7.htm
---
# Autodesk.Revit.DB.ContourSetting.DisableItem Method

Disable a contour setting item of the current contour setting so that the item will not be used to draw contours.

## Syntax (C#)
```csharp
public void DisableItem(
	ContourSettingItem item
)
```

## Parameters
- **item** (`Autodesk.Revit.DB.ContourSettingItem`) - The contour setting item to be disabled.

## Remarks
Contour setting will not be changed if the item could not be found.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

