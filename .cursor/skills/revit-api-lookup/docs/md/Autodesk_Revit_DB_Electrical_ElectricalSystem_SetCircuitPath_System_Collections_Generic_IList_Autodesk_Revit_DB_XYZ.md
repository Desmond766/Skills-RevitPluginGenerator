---
kind: method
id: M:Autodesk.Revit.DB.Electrical.ElectricalSystem.SetCircuitPath(System.Collections.Generic.IList{Autodesk.Revit.DB.XYZ})
source: html/20a517d0-f464-42c7-aa7f-02ed6135ca93.htm
---
# Autodesk.Revit.DB.Electrical.ElectricalSystem.SetCircuitPath Method

Sets the electrical system circuit path by the list of node position.

## Syntax (C#)
```csharp
public void SetCircuitPath(
	IList<XYZ> nodes
)
```

## Parameters
- **nodes** (`System.Collections.Generic.IList < XYZ >`) - The list of the circuit path node position.

## Remarks
If succeed, it will also change the CircuitPathMode property to Custom mode implicitly.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The list of the electrical system circuit path node position is not valid. The length of the list should be more than one, the first node should be the position of the panel where the circuit begins at, the adjacent nodes should not be too close, and should be in the same level or on the same vertical line, to keep each segment of the circuit path always horizontal or vertical.
 Also note that the first node position should be the position of the connector (the one connects to the circuit) of the panel, but not the origin of the panel instance.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.DisabledDisciplineException** - None of the following disciplines is enabled: Mechanical Electrical Piping.

