---
kind: method
id: M:Autodesk.Revit.DB.Fabrication.FabricationNetworkChangeService.ApplyChange
source: html/f9b261dc-80f8-00c9-425c-973d325a4379.htm
---
# Autodesk.Revit.DB.Fabrication.FabricationNetworkChangeService.ApplyChange Method

Applies the previously set changes to the selection of fabrication parts to change the size, change the service, or both.

## Syntax (C#)
```csharp
public FabricationNetworkChangeServiceResult ApplyChange()
```

## Remarks
After this method has been invoked, call:
 GetStraightsThatWereNotChanged () () () to get a set of fabrication part straight element identifiers that were not changed. GetElementsThatFailed () () () to get a set of fabrication part element identifiers that had failures.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The selection contains invalid elements to change.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - No fabrication configuration is loaded.

