---
kind: type
id: T:Autodesk.Revit.DB.Transform1D
source: html/7366ab0c-173e-ff4b-fb56-4f307cf16bc9.htm
---
# Autodesk.Revit.DB.Transform1D

An affine transform of 1D Euclidean space.

## Syntax (C#)
```csharp
public class Transform1D : IDisposable
```

## Remarks
An affine transform is a linear transform plus a translation (which may be zero).
 1D space is tranformed according to the following formula: t -> A*t + B where A and B are constants.
 Some functions only accept certain kinds of transform (e.g., rigid motion, conformal, non-singular, etc.).

