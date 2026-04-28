---
kind: method
id: M:Autodesk.Revit.DB.BRepBuilder.IsResultAvailable
source: html/e4316883-9ea0-b9a5-7cc5-3ba58d1c7418.htm
---
# Autodesk.Revit.DB.BRepBuilder.IsResultAvailable Method

A validator function that checks the state of this BRepBuilder object. Returns true if this BRepBuilder object has successfully built a b-rep.

## Syntax (C#)
```csharp
public bool IsResultAvailable()
```

## Returns
True if this BRepBuilder object has successfully built a b-rep.

## Remarks
The b-rep object may be retrieved via GetResult().
 Use this function before calling GetResult() to avoid an exception being thrown.

