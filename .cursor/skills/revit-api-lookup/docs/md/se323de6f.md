---
kind: method
id: M:Autodesk.Revit.DB.ContourSetting.GetItemIndex(Autodesk.Revit.DB.ContourSettingItem)
source: html/767624bf-19ce-e506-7d36-27faeb22a60a.htm
---
# Autodesk.Revit.DB.ContourSetting.GetItemIndex Method

Get the index of a contour setting item of the current contour setting

## Syntax (C#)
```csharp
public int GetItemIndex(
	ContourSettingItem item
)
```

## Parameters
- **item** (`Autodesk.Revit.DB.ContourSettingItem`) - The contour setting item.

## Returns
The index of the input contour setting item.
 -1 if the item is not found.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

