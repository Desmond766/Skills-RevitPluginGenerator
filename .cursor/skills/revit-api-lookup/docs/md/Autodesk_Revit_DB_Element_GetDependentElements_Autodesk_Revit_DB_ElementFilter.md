---
kind: method
id: M:Autodesk.Revit.DB.Element.GetDependentElements(Autodesk.Revit.DB.ElementFilter)
zh: 构件、图元、元素
source: html/56e875d3-014b-a996-69c3-e6ed9b885f5c.htm
---
# Autodesk.Revit.DB.Element.GetDependentElements Method

**中文**: 构件、图元、元素

Get all elements that, from a logical point of view, are the children of this Element.

## Syntax (C#)
```csharp
public IList<ElementId> GetDependentElements(
	ElementFilter filter
)
```

## Parameters
- **filter** (`Autodesk.Revit.DB.ElementFilter`) - What type of elements we are interested of.
 Can be NULL to return all dependent elements.

## Returns
Logical children of this element

## Remarks
The elements that this method will return:
 Will be deleted if the input Element is deleted. Potentially could report the input Element as a host (there could be other type of
 parent/child relationship here: for example view/view-specific elements, etc.)

