---
kind: method
id: M:Autodesk.Revit.DB.Electrical.ElectricalSystem.IsCircuitPathValid(System.Collections.Generic.IList{Autodesk.Revit.DB.XYZ})
source: html/d92fa2ae-b129-af44-e166-b7a37516a72b.htm
---
# Autodesk.Revit.DB.Electrical.ElectricalSystem.IsCircuitPathValid Method

Checks whether the list of the electrical system circuit path node position is valid.

## Syntax (C#)
```csharp
public bool IsCircuitPathValid(
	IList<XYZ> nodes
)
```

## Parameters
- **nodes** (`System.Collections.Generic.IList < XYZ >`) - The list of the electrical system circuit path node position.

## Remarks
The length of the list should be more than one, the first node should be the position of the panel where the circuit begins at, the adjacent nodes should not be too close, and should be in the same level or on the same vertical line, to keep each segment of the circuit path always horizontal or vertical.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

