---
kind: method
id: M:Autodesk.Revit.DB.ReferenceableViewUtils.GetReferencedViewId(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
source: html/055ef271-6d6f-1891-b8e4-275dbdeca9f9.htm
---
# Autodesk.Revit.DB.ReferenceableViewUtils.GetReferencedViewId Method

Gets the id of the view referenced by a reference view (such as a reference section or reference callout).

## Syntax (C#)
```csharp
public static ElementId GetReferencedViewId(
	Document document,
	ElementId referenceId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document containing the elements.
- **referenceId** (`Autodesk.Revit.DB.ElementId`) - The reference view that will be changed to refer to a different View.

## Returns
The id of the referenced view.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - referenceId is not a valid reference view.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

