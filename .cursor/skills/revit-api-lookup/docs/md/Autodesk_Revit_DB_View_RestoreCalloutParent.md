---
kind: method
id: M:Autodesk.Revit.DB.View.RestoreCalloutParent
zh: 视图
source: html/a464c2cb-2e4c-6f3e-337e-4eb570cca658.htm
---
# Autodesk.Revit.DB.View.RestoreCalloutParent Method

**中文**: 视图

Restores callout parent ID to the original view ID if that view is still available.

## Syntax (C#)
```csharp
public void RestoreCalloutParent()
```

## Remarks
Nothing is done if the callout already has parent or if the original callout parent is deleted or is not parallel to the callout view.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This view is not a callout.

