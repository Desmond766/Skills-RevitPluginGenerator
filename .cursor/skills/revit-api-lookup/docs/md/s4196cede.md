---
kind: method
id: M:Autodesk.Revit.DB.View.GetCalloutParentId
zh: 视图
source: html/aa470950-40bc-6ec8-2c91-f6f423b8cc2e.htm
---
# Autodesk.Revit.DB.View.GetCalloutParentId Method

**中文**: 视图

Gets ID of the callout parent view.

## Syntax (C#)
```csharp
public ElementId GetCalloutParentId()
```

## Returns
ID of a view in which this callout was created or InvalidElementId if there is no parent.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This view is not a callout.

