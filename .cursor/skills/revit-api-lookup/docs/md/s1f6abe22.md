---
kind: method
id: M:Autodesk.Revit.DB.View.HideElementTemporary(Autodesk.Revit.DB.ElementId)
zh: 视图
source: html/df9e6656-eca7-b95c-0e50-05974d5a70fb.htm
---
# Autodesk.Revit.DB.View.HideElementTemporary Method

**中文**: 视图

Set one element to be temporarily hidden in the view.
 To hide a group completely, you must also include all members of all groups and nested groups in your input, therefore you should use the version of this method that accepts multiple element ids as input.

## Syntax (C#)
```csharp
public void HideElementTemporary(
	ElementId elementId
)
```

## Parameters
- **elementId** (`Autodesk.Revit.DB.ElementId`) - The id of the element to be temporarily hidden.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

