---
kind: method
id: M:Autodesk.Revit.Creation.Document.NewSpaceTag(Autodesk.Revit.DB.Mechanical.Space,Autodesk.Revit.DB.UV,Autodesk.Revit.DB.View)
zh: 文档、文件
source: html/07f23ff4-61c1-54a4-8332-0c9dbcdad556.htm
---
# Autodesk.Revit.Creation.Document.NewSpaceTag Method

**中文**: 文档、文件

Creates a new SpaceTag.

## Syntax (C#)
```csharp
public SpaceTag NewSpaceTag(
	Space space,
	UV point,
	View view
)
```

## Parameters
- **space** (`Autodesk.Revit.DB.Mechanical.Space`) - The Space which the tag refers.
- **point** (`Autodesk.Revit.DB.UV`) - A 2D point that dictates the location on the level of the space.
- **view** (`Autodesk.Revit.DB.View`) - The view where the tag will lie.

## Returns
If successful a SpaceTag object will be returned, otherwise Nothing nullptr a null reference ( Nothing in Visual Basic) . 
Suitable exceptions will be fired if the parameters are invalid.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown if the space does not exist in the given document.
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown if the view does not exist in the given document.

