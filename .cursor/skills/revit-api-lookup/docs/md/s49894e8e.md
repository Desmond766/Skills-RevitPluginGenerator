---
kind: method
id: M:Autodesk.Revit.DB.View.RemoveCalloutParent
zh: 视图
source: html/558a9ad6-ba17-febd-5ad8-137ffe084156.htm
---
# Autodesk.Revit.DB.View.RemoveCalloutParent Method

**中文**: 视图

Replaces callout parent ID with InvalidElementId.

## Syntax (C#)
```csharp
public void RemoveCalloutParent()
```

## Remarks
Nothing is done if the callout has already no parent.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This view is not a callout.

