---
kind: type
id: T:Autodesk.Revit.DB.Grid
zh: 轴网
source: html/47888507-2d69-664a-ead4-e481c7c5f42d.htm
---
# Autodesk.Revit.DB.Grid

**中文**: 轴网

Represents a single grid line within Autodesk Revit.

## Syntax (C#)
```csharp
public class Grid : DatumPlane
```

## Remarks
A Grid is a DatumPlane, so it is actually a three dimensional surface. It can be either a plane parallel to
 the project z-axis, or else a cylinder whose axis is parallel to the project z-xis. [!:Autodesk::Revit::DatumPlane]

