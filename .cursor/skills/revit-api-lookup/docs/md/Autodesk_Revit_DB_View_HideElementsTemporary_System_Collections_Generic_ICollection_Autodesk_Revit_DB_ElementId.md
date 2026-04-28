---
kind: method
id: M:Autodesk.Revit.DB.View.HideElementsTemporary(System.Collections.Generic.ICollection{Autodesk.Revit.DB.ElementId})
zh: 视图
source: html/7d391972-0fd8-622c-1b9b-50255fbec92c.htm
---
# Autodesk.Revit.DB.View.HideElementsTemporary Method

**中文**: 视图

Set multiple elements to be temporarily hidden in the view.
 To hide a group completely, you must also include all members of all groups and nested groups in your input.

## Syntax (C#)
```csharp
public void HideElementsTemporary(
	ICollection<ElementId> elementIdSet
)
```

## Parameters
- **elementIdSet** (`System.Collections.Generic.ICollection < ElementId >`) - Ids of the elements to be temporarily hidden.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

