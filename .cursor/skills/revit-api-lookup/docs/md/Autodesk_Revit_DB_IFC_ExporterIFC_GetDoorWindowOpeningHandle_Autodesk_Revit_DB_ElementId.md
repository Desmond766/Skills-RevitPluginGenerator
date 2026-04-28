---
kind: method
id: M:Autodesk.Revit.DB.IFC.ExporterIFC.GetDoorWindowOpeningHandle(Autodesk.Revit.DB.ElementId)
source: html/aa17a626-7f33-0984-6b2d-e8ff8b7e6423.htm
---
# Autodesk.Revit.DB.IFC.ExporterIFC.GetDoorWindowOpeningHandle Method

Get the handle to the opening associated with a hosted (door/window) element from the internal cache.

## Syntax (C#)
```csharp
public IFCAnyHandle GetDoorWindowOpeningHandle(
	ElementId familyInstanceId
)
```

## Parameters
- **familyInstanceId** (`Autodesk.Revit.DB.ElementId`) - The id of the door or window.

## Returns
The opening handle.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

