---
kind: method
id: M:Autodesk.Revit.Creation.Document.NewRoom(Autodesk.Revit.DB.Level,Autodesk.Revit.DB.UV)
zh: 文档、文件
source: html/28262c8c-d18a-338c-eb17-f406438949d8.htm
---
# Autodesk.Revit.Creation.Document.NewRoom Method

**中文**: 文档、文件

Creates a new room on a level at a specified point.

## Syntax (C#)
```csharp
public Room NewRoom(
	Level level,
	UV point
)
```

## Parameters
- **level** (`Autodesk.Revit.DB.Level`) - The level on which the room is to exist.
- **point** (`Autodesk.Revit.DB.UV`) - A 2D point that dictates the location of the room on that specified level.

## Returns
If successful the new room will be returned, otherwise Nothing nullptr a null reference ( Nothing in Visual Basic) .

## Remarks
This method will regenerate the document even in manual regeneration mode.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown if the level does not exist in the given document.

