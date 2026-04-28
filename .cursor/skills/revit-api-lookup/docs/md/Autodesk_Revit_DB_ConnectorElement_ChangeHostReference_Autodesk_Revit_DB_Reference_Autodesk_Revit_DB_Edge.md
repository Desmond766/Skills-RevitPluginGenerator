---
kind: method
id: M:Autodesk.Revit.DB.ConnectorElement.ChangeHostReference(Autodesk.Revit.DB.Reference,Autodesk.Revit.DB.Edge)
source: html/1761f9f3-3967-9d02-befb-401d16fd100d.htm
---
# Autodesk.Revit.DB.ConnectorElement.ChangeHostReference Method

Changes the connector host reference to a new planar face and a new edge loop.

## Syntax (C#)
```csharp
public void ChangeHostReference(
	Reference planarFace,
	Edge edge
)
```

## Parameters
- **planarFace** (`Autodesk.Revit.DB.Reference`) - The planar face to place the connector on.
- **edge** (`Autodesk.Revit.DB.Edge`) - One of the edges in the edge loop that defines the new connector location on the planar face.

## Remarks
The connector referenced by an edge loop has the fixed origin as defined by the edge loop.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The face is not a planar face.
 -or-
 The edge is not on the planar face.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

