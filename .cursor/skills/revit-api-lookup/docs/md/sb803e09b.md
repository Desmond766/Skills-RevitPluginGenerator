---
kind: method
id: M:Autodesk.Revit.UI.UIDocument.ShowElements(Autodesk.Revit.DB.Element)
source: html/6c40c35b-1b2b-1741-dafa-5ab6b1744634.htm
---
# Autodesk.Revit.UI.UIDocument.ShowElements Method

Shows the element by zoom to fit.

## Syntax (C#)
```csharp
public void ShowElements(
	Element element
)
```

## Parameters
- **element** (`Autodesk.Revit.DB.Element`) - Element that will be shown.

## Remarks
Places the element in the center of screen by moving the view.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Element is null.

