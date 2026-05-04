---
kind: method
id: M:Autodesk.Revit.DB.ContourSetting.RemoveItem(Autodesk.Revit.DB.ContourSettingItem)
source: html/63b5a3f9-062e-4821-3783-9a53663e5fe8.htm
---
# Autodesk.Revit.DB.ContourSetting.RemoveItem Method

Remove a contour setting item from the current contour setting.

## Syntax (C#)
```csharp
public void RemoveItem(
	ContourSettingItem item
)
```

## Parameters
- **item** (`Autodesk.Revit.DB.ContourSettingItem`) - The contour setting item to be removed.

## Remarks
Contour setting will not be changed if the item could not be found.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

