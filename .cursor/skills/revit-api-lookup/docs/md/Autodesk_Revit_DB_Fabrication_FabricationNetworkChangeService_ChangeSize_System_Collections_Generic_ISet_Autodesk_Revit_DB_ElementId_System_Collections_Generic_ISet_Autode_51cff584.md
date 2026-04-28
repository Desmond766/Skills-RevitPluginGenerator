---
kind: method
id: M:Autodesk.Revit.DB.Fabrication.FabricationNetworkChangeService.ChangeSize(System.Collections.Generic.ISet{Autodesk.Revit.DB.ElementId},System.Collections.Generic.ISet{Autodesk.Revit.DB.Fabrication.FabricationPartSizeMap})
source: html/0b1e1aab-20f8-9de3-bbe7-9f5b5ab9c1ed.htm
---
# Autodesk.Revit.DB.Fabrication.FabricationNetworkChangeService.ChangeSize Method

Changes the size of the selection of fabrication parts.

## Syntax (C#)
```csharp
public FabricationNetworkChangeServiceResult ChangeSize(
	ISet<ElementId> selection,
	ISet<FabricationPartSizeMap> fabricationPartSizeMaps
)
```

## Parameters
- **selection** (`System.Collections.Generic.ISet < ElementId >`) - The set of element identifiers of fabrication parts to change the size for.
- **fabricationPartSizeMaps** (`System.Collections.Generic.ISet < FabricationPartSizeMap >`) - The map containing the original sizes for the straights to the new sizes.

## Remarks
After this method has been invoked, call:
 GetStraightsThatWereNotChanged () () () to get a set of fabrication part straight element identifiers that were not changed. GetElementsThatFailed () () () to get a set of fabrication part element identifiers that had failures.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The selection contains invalid elements to change.
 -or-
 The fabrication size map is empty.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - No fabrication configuration is loaded.

