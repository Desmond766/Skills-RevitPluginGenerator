---
kind: method
id: M:Autodesk.Revit.DB.FilteredElementCollector.IsViewValidForElementIteration(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
zh: 筛选、过滤
source: html/9c7f3f9c-aa8a-8077-9235-ff1058c8b20b.htm
---
# Autodesk.Revit.DB.FilteredElementCollector.IsViewValidForElementIteration Method

**中文**: 筛选、过滤

Identifies if the particular element is valid for iteration of drawn elements.

## Syntax (C#)
```csharp
public static bool IsViewValidForElementIteration(
	Document document,
	ElementId viewId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **viewId** (`Autodesk.Revit.DB.ElementId`) - The view id.

## Returns
True if the element is valid for iteration.

## Remarks
Views that have no way of representing drawn elements, such as many view templates, fail this check.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

