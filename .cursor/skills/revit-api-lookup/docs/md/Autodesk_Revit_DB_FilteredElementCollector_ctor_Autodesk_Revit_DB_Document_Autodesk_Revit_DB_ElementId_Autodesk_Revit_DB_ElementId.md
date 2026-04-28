---
kind: method
id: M:Autodesk.Revit.DB.FilteredElementCollector.#ctor(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId)
zh: 筛选、过滤
source: html/968b52a0-de55-2f96-de40-968812bc41c7.htm
---
# Autodesk.Revit.DB.FilteredElementCollector.#ctor Method

**中文**: 筛选、过滤

Constructs a new FilteredElementCollector that will search and filter the visible elements from
 a Revit link in a host document view.

## Syntax (C#)
```csharp
public FilteredElementCollector(
	Document hostDocument,
	ElementId viewId,
	ElementId linkId
)
```

## Parameters
- **hostDocument** (`Autodesk.Revit.DB.Document`) - The document that owns the view.
- **viewId** (`Autodesk.Revit.DB.ElementId`) - The view id in the host document.
- **linkId** (`Autodesk.Revit.DB.ElementId`) - The Revit link instance id in the host document.

## Remarks
Only visible elements belonging to the link instance will be returned. Other instances of
 that link may have different element visibility in a given view. Elements that will be passed by the collector have graphics that may be visible in
 the input view. Some elements may still be hidden because they are obscured by other elements. For elements which are outside of a crop region, they may still be passed by the collector because
 Revit relies on later processing to eliminate the elements hidden by the crop.
 This effect may more easily occur for non-rectangular crop regions, but may also happen even for rectangular crops.
 You can compare the boundary of the region with the element's boundary if more precise results are required. Accessing these visible elements may require Revit to rebuild the geometry of the view.
 The first time your code constructs a collector for a given view, or the first time
 your code constructs a collector for a view whose display settings have just been changed,
 you may experience a significant performance degradation.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - viewId is not a view.
 -or-
 linkId does not refer to a valid link document.
 -or-
 viewId is not valid for element iteration, because it has no way of representing drawn elements. Many view templates
 will fail this check.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

