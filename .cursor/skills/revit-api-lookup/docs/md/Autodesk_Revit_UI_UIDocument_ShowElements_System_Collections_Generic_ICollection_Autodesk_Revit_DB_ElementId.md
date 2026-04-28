---
kind: method
id: M:Autodesk.Revit.UI.UIDocument.ShowElements(System.Collections.Generic.ICollection{Autodesk.Revit.DB.ElementId})
source: html/4c3aaa9a-679a-b49a-f162-48e199cc5b4b.htm
---
# Autodesk.Revit.UI.UIDocument.ShowElements Method

Shows the elements by zoom to fit.

## Syntax (C#)
```csharp
public void ShowElements(
	ICollection<ElementId> elementIds
)
```

## Parameters
- **elementIds** (`System.Collections.Generic.ICollection < ElementId >`) - The set of element ids which will be shown.

## Remarks
Places all the elements on the screen by moving the view.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - elementIds is null.
- **Autodesk.Revit.Exceptions.ArgumentException** - Member of elementIds is null.
- **Autodesk.Revit.Exceptions.ArgumentException** - Member of elementIds is not valid.

