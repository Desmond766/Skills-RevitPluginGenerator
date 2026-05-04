---
kind: method
id: M:Autodesk.Revit.DB.Electrical.Wire.AreVertexPointsValid(System.Collections.Generic.IList{Autodesk.Revit.DB.XYZ},Autodesk.Revit.DB.Connector,Autodesk.Revit.DB.Connector)
source: html/fd5fb218-eecf-c670-2907-59f5446a866c.htm
---
# Autodesk.Revit.DB.Electrical.Wire.AreVertexPointsValid Method

Checks if the given vertex points are valid for the wire.

## Syntax (C#)
```csharp
public static bool AreVertexPointsValid(
	IList<XYZ> vertexPoints,
	Connector startConnector,
	Connector endConnector
)
```

## Parameters
- **vertexPoints** (`System.Collections.Generic.IList < XYZ >`) - The vertex points.
- **startConnector** (`Autodesk.Revit.DB.Connector`) - The start connector of the wire.
- **endConnector** (`Autodesk.Revit.DB.Connector`) - The end connector of the wire.

## Returns
True if the given vertex points are valid, false otherwise.

## Remarks
X and Y values are compared of the vertices.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

