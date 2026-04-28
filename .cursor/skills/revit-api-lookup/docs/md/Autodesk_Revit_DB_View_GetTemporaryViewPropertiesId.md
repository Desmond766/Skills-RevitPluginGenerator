---
kind: method
id: M:Autodesk.Revit.DB.View.GetTemporaryViewPropertiesId
zh: 视图
source: html/1fa3e6e9-9a09-2ffa-25e1-302ada24bb12.htm
---
# Autodesk.Revit.DB.View.GetTemporaryViewPropertiesId Method

**中文**: 视图

When Temporary View Properties mode is in progress it provides view id that overrode settings for current view.
 Outside Temporary View Properties mode InvalidElementId will be returned.

## Syntax (C#)
```csharp
public ElementId GetTemporaryViewPropertiesId()
```

## Remarks
Returned ElementId might refer to element that was deleted.
 It will happen when Temporary View Properties mode was applied basing on template that next was deleted.

