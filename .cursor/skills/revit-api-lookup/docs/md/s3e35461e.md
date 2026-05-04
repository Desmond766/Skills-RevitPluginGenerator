---
kind: method
id: M:Autodesk.Revit.DB.ConnectorElement.ChangeHostReference(Autodesk.Revit.DB.Reference)
source: html/ab25dbec-9993-98b3-78e6-527bbd27fd1c.htm
---
# Autodesk.Revit.DB.ConnectorElement.ChangeHostReference Method

Changes the connector host reference to a new planar face.

## Syntax (C#)
```csharp
public void ChangeHostReference(
	Reference planarFace
)
```

## Parameters
- **planarFace** (`Autodesk.Revit.DB.Reference`) - The planar face to place the connector on.

## Remarks
The connector referenced by a planar face alone is placed at the plane origin, and may be moved later along the planar face.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The face is not a planar face.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

