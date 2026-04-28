---
kind: method
id: M:Autodesk.Revit.DB.IFC.ExporterIFC.GetHostObjects
source: html/39ace44e-26a7-e530-2dc2-737a1e3f1479.htm
---
# Autodesk.Revit.DB.IFC.ExporterIFC.GetHostObjects Method

Returns a collection containing the host object handles in the document.

## Syntax (C#)
```csharp
public IList<IDictionary<ElementId, IFCAnyHandle>> GetHostObjects()
```

## Returns
The collection of host objects.

## Remarks
Host object handles is currently collected by RegisterSpaceBoundingElementHandle
 and exporting internal element and cached in the ExporterIFC object.
 This method returns the cached information which is needed to create wall connectivity objects.

