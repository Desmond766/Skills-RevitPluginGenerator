---
kind: method
id: M:Autodesk.Revit.DB.View.GetPlacementOnSheetStatus
zh: 视图
source: html/bc769050-18b4-e147-b1ac-753c11b62c70.htm
---
# Autodesk.Revit.DB.View.GetPlacementOnSheetStatus Method

**中文**: 视图

Determines if this view placed on a sheet completely or partially.

## Syntax (C#)
```csharp
public ViewPlacementOnSheetStatus GetPlacementOnSheetStatus()
```

## Returns
A value indicating whether and how the View is placed on a Sheet.

## Remarks
Some Views can be placed on one or more Sheets completely or partially.
 For example, a Schedule divided in segments, and only some of them are placed on Sheets.

