---
kind: method
id: M:Autodesk.Revit.DB.BRepBuilder.Finish
source: html/4e7da30b-68cf-5572-39d1-979dffef8d5a.htm
---
# Autodesk.Revit.DB.BRepBuilder.Finish Method

Complete construction of the geometry. The geometry will be validated and, if valid, stored in this Builder. Otherwise it will be deleted.

## Syntax (C#)
```csharp
public BRepBuilderOutcome Finish()
```

## Returns
BRepBuilderOutcome.Success if successful, BRepBuilderOutcome.Failure otherwise.

## Remarks
If this function returned anything but BRepBuilderOutcome.Success, this BrepBuilder object should be discarded.
 An attempt to retrieve the built b-rep via GetBRep() will cause an exception to be thrown.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This BRepBuilder object isn't accepting new data, either because it has already been used to build geometry, or because of an error.
 Consult the State property of the BRepBuilder object for more details.
 -or-
 BRep doesn't have enough faces.
 -or-
 FinishFace() must be called on all the faces of the BRepBuilder.

