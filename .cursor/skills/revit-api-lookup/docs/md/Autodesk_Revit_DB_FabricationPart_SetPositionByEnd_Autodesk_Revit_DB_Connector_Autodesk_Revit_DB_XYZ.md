---
kind: method
id: M:Autodesk.Revit.DB.FabricationPart.SetPositionByEnd(Autodesk.Revit.DB.Connector,Autodesk.Revit.DB.XYZ)
source: html/11e80876-652b-dfb1-4384-281794c84da8.htm
---
# Autodesk.Revit.DB.FabricationPart.SetPositionByEnd Method

Positions the connector of the fabrication part element by the passed point.

## Syntax (C#)
```csharp
public void SetPositionByEnd(
	Connector connector,
	XYZ position
)
```

## Parameters
- **connector** (`Autodesk.Revit.DB.Connector`) - The connector of the fabrication part element.
- **position** (`Autodesk.Revit.DB.XYZ`) - The position to move to.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - this operation failed.

