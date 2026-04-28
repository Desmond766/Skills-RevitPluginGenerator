---
kind: method
id: M:Autodesk.Revit.DB.BRepBuilder.CanAddGeometry
source: html/8bf14f8a-bbf4-c661-1588-1626e574238b.htm
---
# Autodesk.Revit.DB.BRepBuilder.CanAddGeometry Method

A validator function that checks the state of this BRepBuilder object. Returns true if this BRepBuilder object is accepting b-rep data, false otherwise.

## Syntax (C#)
```csharp
public bool CanAddGeometry()
```

## Returns
True if this BRepBuilder object is accepting b-rep data, false otherwise.

## Remarks
Use this function before calling AddFace(), AddEdge(), etc. to avoid an exception being thrown.

