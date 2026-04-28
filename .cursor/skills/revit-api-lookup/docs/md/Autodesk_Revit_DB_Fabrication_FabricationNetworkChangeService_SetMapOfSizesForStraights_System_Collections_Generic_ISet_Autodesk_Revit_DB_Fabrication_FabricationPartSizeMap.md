---
kind: method
id: M:Autodesk.Revit.DB.Fabrication.FabricationNetworkChangeService.SetMapOfSizesForStraights(System.Collections.Generic.ISet{Autodesk.Revit.DB.Fabrication.FabricationPartSizeMap})
source: html/3bf6d1da-663c-96e7-ec90-0b82f90efebb.htm
---
# Autodesk.Revit.DB.Fabrication.FabricationNetworkChangeService.SetMapOfSizesForStraights Method

Set the mapping for sizes of fabrication part straights to change the sizes to.

## Syntax (C#)
```csharp
public void SetMapOfSizesForStraights(
	ISet<FabricationPartSizeMap> fabricationPartSizeMaps
)
```

## Parameters
- **fabricationPartSizeMaps** (`System.Collections.Generic.ISet < FabricationPartSizeMap >`) - The map containing the original straights size to the mapped sizes.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

