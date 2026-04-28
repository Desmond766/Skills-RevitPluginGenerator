---
kind: method
id: M:Autodesk.Revit.DB.View.SetWorksetVisibility(Autodesk.Revit.DB.WorksetId,Autodesk.Revit.DB.WorksetVisibility)
zh: 视图
source: html/fa6d4b89-a703-80ee-26a6-e88aa89b96a5.htm
---
# Autodesk.Revit.DB.View.SetWorksetVisibility Method

**中文**: 视图

Sets visibility for a workset in this view.

## Syntax (C#)
```csharp
public void SetWorksetVisibility(
	WorksetId worksetId,
	WorksetVisibility visible
)
```

## Parameters
- **worksetId** (`Autodesk.Revit.DB.WorksetId`) - Id of the workset.
- **visible** (`Autodesk.Revit.DB.WorksetVisibility`) - The visibility of the workset.

## Remarks
It works even when the workset is closed. This settings overrules implicit visibility of the workset (for this particular view only).

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - There is no workset with this Id in the document associated with this view.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

