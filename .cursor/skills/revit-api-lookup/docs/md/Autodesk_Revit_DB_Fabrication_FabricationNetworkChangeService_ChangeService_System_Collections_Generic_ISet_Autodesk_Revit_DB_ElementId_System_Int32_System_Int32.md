---
kind: method
id: M:Autodesk.Revit.DB.Fabrication.FabricationNetworkChangeService.ChangeService(System.Collections.Generic.ISet{Autodesk.Revit.DB.ElementId},System.Int32,System.Int32)
source: html/17ab8b80-947b-8205-a8d9-11e033a06b08.htm
---
# Autodesk.Revit.DB.Fabrication.FabricationNetworkChangeService.ChangeService Method

Changes the service of the selection of fabrication parts.

## Syntax (C#)
```csharp
public FabricationNetworkChangeServiceResult ChangeService(
	ISet<ElementId> selection,
	int serviceId,
	int paletteId
)
```

## Parameters
- **selection** (`System.Collections.Generic.ISet < ElementId >`) - The set of element identifiers of fabrication parts to change the service for.
- **serviceId** (`System.Int32`) - The identifier of the fabrication service.
- **paletteId** (`System.Int32`) - The identifier of the fabrication palette.

## Remarks
After this method has been invoked, call:
 GetStraightsThatWereNotChanged () () () to get a set of fabrication part straight element identifiers that were not changed. GetElementsThatFailed () () () to get a set of fabrication part element identifiers that had failures.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The selection contains invalid elements to change.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - No fabrication configuration is loaded.

