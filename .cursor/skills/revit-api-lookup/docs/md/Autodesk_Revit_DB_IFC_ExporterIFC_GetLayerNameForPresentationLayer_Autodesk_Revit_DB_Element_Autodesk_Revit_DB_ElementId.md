---
kind: method
id: M:Autodesk.Revit.DB.IFC.ExporterIFC.GetLayerNameForPresentationLayer(Autodesk.Revit.DB.Element,Autodesk.Revit.DB.ElementId)
source: html/9bb2d5c4-40ef-661b-b49e-720e74a1ca57.htm
---
# Autodesk.Revit.DB.IFC.ExporterIFC.GetLayerNameForPresentationLayer Method

Get the layer name associated with an element from the default layer mapping table.

## Syntax (C#)
```csharp
public string GetLayerNameForPresentationLayer(
	Element pElement,
	ElementId categoryId
)
```

## Parameters
- **pElement** (`Autodesk.Revit.DB.Element`) - The element.
- **categoryId** (`Autodesk.Revit.DB.ElementId`) - The category id of the element.

## Returns
The layer name.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

