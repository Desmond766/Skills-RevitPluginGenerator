---
kind: method
id: M:Autodesk.Revit.DB.IExportContext.OnElementBegin(Autodesk.Revit.DB.ElementId)
source: html/d218b0b3-bb24-0f73-806c-2ef90b16d882.htm
---
# Autodesk.Revit.DB.IExportContext.OnElementBegin Method

This method marks the beginning of an element to be exported.

## Syntax (C#)
```csharp
RenderNodeAction OnElementBegin(
	ElementId elementId
)
```

## Parameters
- **elementId** (`Autodesk.Revit.DB.ElementId`) - The Id of the element that is about to be processed.

## Returns
Return RenderNodeAction.Skip if you wish to skip exporting this element,
 or return RenderNodeAction.Proceed otherwise.

## Remarks
This method is never called for 2D export (see cref="Autodesk::Revit::DB::IExportContext2D").

