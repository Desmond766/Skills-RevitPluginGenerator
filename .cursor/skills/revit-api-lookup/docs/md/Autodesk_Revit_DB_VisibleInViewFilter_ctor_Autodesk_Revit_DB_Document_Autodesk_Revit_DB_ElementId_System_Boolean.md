---
kind: method
id: M:Autodesk.Revit.DB.VisibleInViewFilter.#ctor(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,System.Boolean)
source: html/59bb7117-1e7e-3567-1885-df33df9a71a0.htm
---
# Autodesk.Revit.DB.VisibleInViewFilter.#ctor Method

Constructs a new instance of a VisibleInViewFilter, with the option to pass all non-visible elements.

## Syntax (C#)
```csharp
public VisibleInViewFilter(
	Document document,
	ElementId viewId,
	bool inverted
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document that owns the view.
- **viewId** (`Autodesk.Revit.DB.ElementId`) - The view id.
- **inverted** (`System.Boolean`) - True if the filter should match all elements not visible in the given view.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - viewId is not a view.
 -or-
 viewId is not valid for element iteration, because it has no way of representing drawn elements. Many view templates
 will fail this check.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

