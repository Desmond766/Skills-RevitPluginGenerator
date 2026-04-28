---
kind: method
id: M:Autodesk.Revit.DB.IFC.ExporterIFC.RegisterSpaceBoundingElementHandle(Autodesk.Revit.DB.IFC.IFCAnyHandle,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId)
source: html/9e2dc4fb-c062-f68d-af7f-fbbe7bd359e1.htm
---
# Autodesk.Revit.DB.IFC.ExporterIFC.RegisterSpaceBoundingElementHandle Method

Stores a handle representing a space bounding element to the ExporterIFC's internal cache.

## Syntax (C#)
```csharp
public void RegisterSpaceBoundingElementHandle(
	IFCAnyHandle instanceHandle,
	ElementId id,
	ElementId levelId
)
```

## Parameters
- **instanceHandle** (`Autodesk.Revit.DB.IFC.IFCAnyHandle`) - The handle to the space bounding element.
- **id** (`Autodesk.Revit.DB.ElementId`) - The Revit element id associated to this handle.
- **levelId** (`Autodesk.Revit.DB.ElementId`) - The level id assigned to the space bounding object.

## Remarks
The cache of space bounding elements will be used during completion of export to create
 relationship objects such as IfcRelSpaceBoundary and IfcRelConnectsPathElements.
 The types of Revit elements accepted by this function are:
 Walls Curtain walls Roofs Floors Doors Windows

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

