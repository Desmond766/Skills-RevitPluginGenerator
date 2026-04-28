---
kind: method
id: M:Autodesk.Revit.DB.IExportContext2D.OnElementBegin2D(Autodesk.Revit.DB.ElementNode)
source: html/e0c2beae-ebbd-f39d-2ce5-6700bd52b885.htm
---
# Autodesk.Revit.DB.IExportContext2D.OnElementBegin2D Method

This method marks the beginning of an element to be exported.

## Syntax (C#)
```csharp
RenderNodeAction OnElementBegin2D(
	ElementNode node
)
```

## Parameters
- **node** (`Autodesk.Revit.DB.ElementNode`) - Node representing the element that is about to start being exported. Contains element ID and document.

## Returns
Return RenderNodeAction.Skip if you wish to skip exporting this element,
 or return RenderNodeAction.Proceed otherwise.

## Remarks
For views having non-Wireframe display style, geometry of elements is output outside of view, instance and link begin/end brackets.
 Therefore the argument to this method is ElementNode that has both element ID and the host document.

