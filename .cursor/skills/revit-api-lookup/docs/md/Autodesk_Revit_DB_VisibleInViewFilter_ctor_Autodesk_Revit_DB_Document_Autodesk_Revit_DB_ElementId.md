---
kind: method
id: M:Autodesk.Revit.DB.VisibleInViewFilter.#ctor(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
source: html/e6535fb3-da90-3e01-ff5b-b08a0d1e9feb.htm
---
# Autodesk.Revit.DB.VisibleInViewFilter.#ctor Method

Constructs a new instance of a VisibleInViewFilter.

## Syntax (C#)
```csharp
public VisibleInViewFilter(
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

