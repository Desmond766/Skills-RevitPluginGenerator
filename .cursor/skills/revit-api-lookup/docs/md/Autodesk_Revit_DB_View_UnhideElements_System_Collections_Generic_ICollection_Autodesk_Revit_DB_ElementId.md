---
kind: method
id: M:Autodesk.Revit.DB.View.UnhideElements(System.Collections.Generic.ICollection{Autodesk.Revit.DB.ElementId})
zh: 视图
source: html/ff7695bc-b1b1-6cfd-bb74-9cf4ece27f18.htm
---
# Autodesk.Revit.DB.View.UnhideElements Method

**中文**: 视图

Sets the elements to be shown in the given view if they are currently hidden.

## Syntax (C#)
```csharp
public void UnhideElements(
	ICollection<ElementId> elementIdSet
)
```

## Parameters
- **elementIdSet** (`System.Collections.Generic.ICollection < ElementId >`) - A set of ElementIds to be unhidden.

## Remarks
This change is permanent until the elements are hidden again.
All elements in the set must be currently hidden.
An application can check this with IsHidden(View) .

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when argument is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when the set of elements to be unhidden is empty or one of the elements can not be unhidden.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when document regeneration failed.

