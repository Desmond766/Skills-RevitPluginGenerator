---
kind: method
id: M:Autodesk.Revit.UI.Selection.SelectableInViewFilter.#ctor(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,System.Boolean)
source: html/34a7e09c-5733-6062-c155-00e823708b54.htm
---
# Autodesk.Revit.UI.Selection.SelectableInViewFilter.#ctor Method

Constructs a new instance of an SelectableInViewFilter, with the option to pass all non-selectable elements.

## Syntax (C#)
```csharp
public SelectableInViewFilter(
	Document document,
	ElementId viewId,
	bool inverted
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document that owns the view.
- **viewId** (`Autodesk.Revit.DB.ElementId`) - The view id.
- **inverted** (`System.Boolean`) - True if the filter should match all elements not selectable in the given view.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - viewId is not a view.
 -or-
 viewId is not valid for element iteration, because it has no way of representing drawn elements. Many view templates
 will fail this check.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

