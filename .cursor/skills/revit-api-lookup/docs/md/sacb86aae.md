---
kind: method
id: M:Autodesk.Revit.DB.View.IsWorksetVisible(Autodesk.Revit.DB.WorksetId)
zh: 视图
source: html/b3eb5b95-5d39-5f77-ef86-b2db00d247cd.htm
---
# Autodesk.Revit.DB.View.IsWorksetVisible Method

**中文**: 视图

Indicates whether the workset is visible in this view.

## Syntax (C#)
```csharp
public bool IsWorksetVisible(
	WorksetId worksetId
)
```

## Parameters
- **worksetId** (`Autodesk.Revit.DB.WorksetId`) - Id of the workset.

## Returns
Whether the workset is visible.

## Remarks
It will take into account whether the workset is opened or closed.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - There is no workset with this Id in the document associated with this view.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

