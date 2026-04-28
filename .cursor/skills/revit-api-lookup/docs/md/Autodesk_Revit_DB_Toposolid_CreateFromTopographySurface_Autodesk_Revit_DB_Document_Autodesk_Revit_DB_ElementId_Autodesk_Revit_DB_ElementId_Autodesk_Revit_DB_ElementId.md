---
kind: method
id: M:Autodesk.Revit.DB.Toposolid.CreateFromTopographySurface(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId)
source: html/662a7ccb-63b9-a106-1b3e-659af6a35c70.htm
---
# Autodesk.Revit.DB.Toposolid.CreateFromTopographySurface Method

Creates a toposolid element from a host TopographySurface, and toposolid sub-divisions from its subregions.

## Syntax (C#)
```csharp
public static Toposolid CreateFromTopographySurface(
	Document document,
	ElementId hostSurfaceId,
	ElementId topoTypeId,
	ElementId levelId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document in which the new toposolid is created.
- **hostSurfaceId** (`Autodesk.Revit.DB.ElementId`) - Id of the host TopogarphySurface element.
- **topoTypeId** (`Autodesk.Revit.DB.ElementId`) - Id of the toposolid type to be used by the new toposolid.
- **levelId** (`Autodesk.Revit.DB.ElementId`) - Id of the level on which the toposolid is to be placed.

## Returns
A new toposolid object within the project if successful.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

