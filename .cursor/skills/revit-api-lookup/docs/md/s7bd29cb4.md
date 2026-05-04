---
kind: method
id: M:Autodesk.Revit.DB.Fabrication.FabricationNetworkChangeService.SetSelection(System.Collections.Generic.ISet{Autodesk.Revit.DB.ElementId})
source: html/f27088a0-3ee2-0a54-4051-e81b0e4a63f7.htm
---
# Autodesk.Revit.DB.Fabrication.FabricationNetworkChangeService.SetSelection Method

Set the element selection to change the service or size for.

## Syntax (C#)
```csharp
public FabricationNetworkChangeServiceResult SetSelection(
	ISet<ElementId> selection
)
```

## Parameters
- **selection** (`System.Collections.Generic.ISet < ElementId >`) - The set of element identifiers of fabrication parts to change the service or size for.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

