---
kind: method
id: M:Autodesk.Revit.DB.DetailElementOrderUtils.IsDetailElement(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.View,Autodesk.Revit.DB.ElementId)
source: html/8c7d0547-19ec-6ee0-5e96-02bbf717c54e.htm
---
# Autodesk.Revit.DB.DetailElementOrderUtils.IsDetailElement Method

Indicates if the element is a detail element that participates in detail draw ordering in the view.

## Syntax (C#)
```csharp
public static bool IsDetailElement(
	Document document,
	View view,
	ElementId detailElementId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **view** (`Autodesk.Revit.DB.View`) - The view in which the detail appears.
- **detailElementId** (`Autodesk.Revit.DB.ElementId`) - The detail element.

## Returns
True if the detail element is orderable in the view, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

