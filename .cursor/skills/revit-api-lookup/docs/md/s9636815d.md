---
kind: property
id: P:Autodesk.Revit.DB.Floor.FloorType
zh: 楼板、板、地板
source: html/18c20723-c74e-6924-406d-fd0d8bae7ae1.htm
---
# Autodesk.Revit.DB.Floor.FloorType Property

**中文**: 楼板、板、地板

Retrieves/sets an object that represents the type of the floor.

## Syntax (C#)
```csharp
public FloorType FloorType { get; set; }
```

## Remarks
The floor type can be used to access the multi layered structure of a floor.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: Floor type is not valid for this floor.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

