---
kind: method
id: M:Autodesk.Revit.DB.Location.Move(Autodesk.Revit.DB.XYZ)
zh: 移动
source: html/c64687d8-ab52-e36d-a095-2715e5660df6.htm
---
# Autodesk.Revit.DB.Location.Move Method

**中文**: 移动

Move the element within the project by a specified vector.

## Syntax (C#)
```csharp
public bool Move(
	XYZ translation
)
```

## Parameters
- **translation** (`Autodesk.Revit.DB.XYZ`) - The vector by which the element is to be moved.

## Returns
If the element is moved successfully then the method return True, otherwise False.

## Remarks
The move method is used to move an element within the project. Other elements may also be
moved when this element is moved, for example: if the element is wall and it contains windows, the
windows will also be moved.

