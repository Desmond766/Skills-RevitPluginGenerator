---
kind: method
id: M:Autodesk.Revit.DB.Fabrication.FabricationNetworkChangeService.SetMapOfInLinePartTypes(System.Collections.Generic.IDictionary{Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId})
source: html/433425ef-b5ae-6049-e67c-8149736c51ef.htm
---
# Autodesk.Revit.DB.Fabrication.FabricationNetworkChangeService.SetMapOfInLinePartTypes Method

Set the mapping of fabrication part types for in-line parts for the service and palette to change to.

## Syntax (C#)
```csharp
public void SetMapOfInLinePartTypes(
	IDictionary<ElementId, ElementId> fabricationPartTypes
)
```

## Parameters
- **fabricationPartTypes** (`System.Collections.Generic.IDictionary < ElementId , ElementId >`) - The map containing the original fabrication part type to the fabrication part type to change to.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

