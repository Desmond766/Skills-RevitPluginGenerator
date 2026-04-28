---
kind: method
id: M:Autodesk.Revit.DB.IFC.ExporterIFC.RegisterDoorWindowForUncreatedOpening(Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.IFC.IFCAnyHandle)
source: html/688b2144-693c-544c-45db-e6257d21430b.htm
---
# Autodesk.Revit.DB.IFC.ExporterIFC.RegisterDoorWindowForUncreatedOpening Method

Registers a door or window in the ExporterIFC's internal cache. The ids registered correspond to
 openings in walls which have not been processed and created yet.

## Syntax (C#)
```csharp
public void RegisterDoorWindowForUncreatedOpening(
	ElementId familyInstanceId,
	IFCAnyHandle instanceHandle
)
```

## Parameters
- **familyInstanceId** (`Autodesk.Revit.DB.ElementId`) - The id of the door or window.
- **instanceHandle** (`Autodesk.Revit.DB.IFC.IFCAnyHandle`) - The handle to the IfcDoor or IfcWindow created for this instance.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

