---
kind: method
id: M:Autodesk.Revit.UI.UIDocument.ShowElements(Autodesk.Revit.DB.ElementSet)
source: html/97a4f04c-5e3e-b2d5-f15c-d802bafd0dc3.htm
---
# Autodesk.Revit.UI.UIDocument.ShowElements Method

Shows the elements by zoom to fit.

## Syntax (C#)
```csharp
public void ShowElements(
	ElementSet elements
)
```

## Parameters
- **elements** (`Autodesk.Revit.DB.ElementSet`) - The set of elements that will be shown.

## Remarks
Places all the elements on the screen by moving the view.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Elements is null.
- **Autodesk.Revit.Exceptions.ArgumentException** - Member of elements is null.

