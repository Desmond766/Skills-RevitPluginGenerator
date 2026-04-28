---
kind: method
id: M:Autodesk.Revit.UI.Selection.ISelectionFilter.AllowElement(Autodesk.Revit.DB.Element)
source: html/9c967926-c396-6e6b-97a2-b6882d71b69e.htm
---
# Autodesk.Revit.UI.Selection.ISelectionFilter.AllowElement Method

Override this pre-filter method to specify if the element should be permitted to be selected.

## Syntax (C#)
```csharp
bool AllowElement(
	Element elem
)
```

## Parameters
- **elem** (`Autodesk.Revit.DB.Element`) - A candidate element in selection operation.

## Returns
Return true to allow the user to select this candidate element. Return false to prevent selection of this element.

## Remarks
If prompting the user to select an element from a Revit Link instance, the element passed here will be the link instance, not the selected linked element.
Access the linked element from Reference passed to the AllowReference() callback of ISelectionFilter. If an exception is thrown from this method, the element will not be permitted to be selected.

