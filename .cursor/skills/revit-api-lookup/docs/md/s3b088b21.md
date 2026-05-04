---
kind: method
id: M:Autodesk.Revit.DB.View.GetWorksetVisibility(Autodesk.Revit.DB.WorksetId)
zh: 视图
source: html/1c37557b-9bd4-12e2-dffb-c3a25cf9a375.htm
---
# Autodesk.Revit.DB.View.GetWorksetVisibility Method

**中文**: 视图

Returns the visibility settings of a workset for this particular view.

## Syntax (C#)
```csharp
public WorksetVisibility GetWorksetVisibility(
	WorksetId worksetId
)
```

## Parameters
- **worksetId** (`Autodesk.Revit.DB.WorksetId`) - Id of the workset.

## Returns
The visibility of a workset for this particular view.

## Remarks
The settings does not reflect the fact of whether a workset is currently closed or not.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - There is no workset with this Id in the document associated with this view.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

