---
kind: method
id: M:Autodesk.Revit.UI.Selection.SelectableInViewFilter.#ctor(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
source: html/c1edf8ba-2d99-78cf-ab50-e1e0de4006f3.htm
---
# Autodesk.Revit.UI.Selection.SelectableInViewFilter.#ctor Method

Constructs a new instance of an SelectableInViewFilter.

## Syntax (C#)
```csharp
public SelectableInViewFilter(
	Document document,
	ElementId viewId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document that owns the view.
- **viewId** (`Autodesk.Revit.DB.ElementId`) - The view id.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - viewId is not a view.
 -or-
 viewId is not valid for element iteration, because it has no way of representing drawn elements. Many view templates
 will fail this check.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

