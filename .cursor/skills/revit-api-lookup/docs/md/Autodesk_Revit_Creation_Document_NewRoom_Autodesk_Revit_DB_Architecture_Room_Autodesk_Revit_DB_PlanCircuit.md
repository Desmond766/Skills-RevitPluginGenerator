---
kind: method
id: M:Autodesk.Revit.Creation.Document.NewRoom(Autodesk.Revit.DB.Architecture.Room,Autodesk.Revit.DB.PlanCircuit)
zh: 文档、文件
source: html/9ceb1869-e41b-8a3f-557c-0b13eb062e0b.htm
---
# Autodesk.Revit.Creation.Document.NewRoom Method

**中文**: 文档、文件

Creates a new room within the confines of a plan circuit, or places an unplaced room within the confines of the plan circuit.

## Syntax (C#)
```csharp
public Room NewRoom(
	Room room,
	PlanCircuit circuit
)
```

## Parameters
- **room** (`Autodesk.Revit.DB.Architecture.Room`) - The room which you want to locate in the circuit. Pass Nothing nullptr a null reference ( Nothing in Visual Basic) to create a new room.
- **circuit** (`Autodesk.Revit.DB.PlanCircuit`) - The circuit in which you want to locate a room.

## Returns
If successful the room is returned, otherwise Nothing nullptr a null reference ( Nothing in Visual Basic) .

## Remarks
This method will regenerate the document even in manual regeneration mode.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - If the existing room is already placed.
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown if the room does not exist in the given document.
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown if the circuit does not exist in the given document.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown if the level obtained from the circuit has no associated view .

