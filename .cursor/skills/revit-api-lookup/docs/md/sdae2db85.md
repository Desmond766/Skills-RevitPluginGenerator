---
kind: property
id: P:Autodesk.Revit.DB.Wall.WallType
zh: 墙、墙体
source: html/0c0d155f-5b2c-c09f-d7d4-41a8600560eb.htm
---
# Autodesk.Revit.DB.Wall.WallType Property

**中文**: 墙、墙体

Retrieves or changes the type of the wall.

## Syntax (C#)
```csharp
public WallType WallType { get; set; }
```

## Remarks
The WallType property can be used to retrieve the kind of the wall.
 This property can also be used to change the type of a wall by setting it to a different wall type.
 All the wall types in the project can be found using the Document.WallTypes property.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: The wall type wallType is not valid for the current wall.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

