---
kind: method
id: M:Autodesk.Revit.Creation.Document.NewRoom(Autodesk.Revit.DB.Phase)
zh: 文档、文件
source: html/0bf2d8e2-593f-1ba7-c0dc-5274749abe19.htm
---
# Autodesk.Revit.Creation.Document.NewRoom Method

**中文**: 文档、文件

Creates a new unplaced room and with an assigned phase.

## Syntax (C#)
```csharp
public Room NewRoom(
	Phase phase
)
```

## Parameters
- **phase** (`Autodesk.Revit.DB.Phase`) - The phase in which the room is to exist.

## Returns
If successful the new room , otherwise Nothing nullptr a null reference ( Nothing in Visual Basic) .

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown if the phase does not exist in the given document.

