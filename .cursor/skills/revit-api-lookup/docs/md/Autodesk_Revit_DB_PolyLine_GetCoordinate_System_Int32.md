---
kind: method
id: M:Autodesk.Revit.DB.PolyLine.GetCoordinate(System.Int32)
zh: 多段线、折线
source: html/1e24cbb8-92ed-9923-eca4-89b46fa1fa3f.htm
---
# Autodesk.Revit.DB.PolyLine.GetCoordinate Method

**中文**: 多段线、折线

Gets the coordinate point of the specified index.

## Syntax (C#)
```csharp
public XYZ GetCoordinate(
	int index
)
```

## Parameters
- **index** (`System.Int32`) - The index of the coordinates.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - Thrown when the index value is out of range.

