---
kind: method
id: M:Autodesk.Revit.Creation.Document.NewOpening(Autodesk.Revit.DB.Wall,Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.XYZ)
zh: 文档、文件
source: html/06a216d4-2cf6-ec8f-df5b-10f007b70531.htm
---
# Autodesk.Revit.Creation.Document.NewOpening Method

**中文**: 文档、文件

Creates a rectangular opening on a wall.

## Syntax (C#)
```csharp
public Opening NewOpening(
	Wall wall,
	XYZ pntStart,
	XYZ pntEnd
)
```

## Parameters
- **wall** (`Autodesk.Revit.DB.Wall`) - Host element of the opening.
- **pntStart** (`Autodesk.Revit.DB.XYZ`) - One corner of the rectangle.
- **pntEnd** (`Autodesk.Revit.DB.XYZ`) - The opposite corner of the rectangle.

## Returns
If successful, an Opening object is returned.

## Remarks
Slanted stacked walls do not support rectangular openings.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown if the wall 
does not exist in the given document, or if the wall doesn't support
rectangular openings.

