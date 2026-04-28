---
kind: method
id: M:Autodesk.Revit.DB.View.HideElements(System.Collections.Generic.ICollection{Autodesk.Revit.DB.ElementId})
zh: 视图
source: html/6b0ae8d1-776a-ad0d-577d-ffdc11673019.htm
---
# Autodesk.Revit.DB.View.HideElements Method

**中文**: 视图

Sets the elements to be hidden in the view.

## Syntax (C#)
```csharp
public void HideElements(
	ICollection<ElementId> elementIdSet
)
```

## Parameters
- **elementIdSet** (`System.Collections.Generic.ICollection < ElementId >`) - A set of ElementIds to be hidden.

## Remarks
This change is permanent until the elements are unhidden.
All elements in the set must be currently unhidden and must be allowed to be hidden. 
An application can check this with IsHidden(View) and CanBeHidden(View) .
 Some elements cannot be hidden directly. Examples include: group, array, constraint, edit cut profile, face splitter and link to external documents. Also, elements cannot be hidden in Revit family documents (but they can be hidden temporarily using [M:Autodesk.Revit.DB.View.HideElementsTemporary(System.Collections.Generic.ICollection`1{Autodesk.Revit.DB.ElementId})] ). To hide a group completely, you must also include all members of all groups and nested groups in your input.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when argument is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when the set of elements to be hidden is empty or one of the elements can not be hidden.
Also thrown when the set of elements to be hidden includes the view itself.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when document regeneration failed.

