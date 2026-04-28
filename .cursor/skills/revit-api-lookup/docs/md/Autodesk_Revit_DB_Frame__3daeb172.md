---
kind: type
id: T:Autodesk.Revit.DB.Frame
source: html/d44b3fd1-34d0-bfd0-55f6-de24235edf2e.htm
---
# Autodesk.Revit.DB.Frame

A Frame comprises three vectors at a base point in 3D space.

## Syntax (C#)
```csharp
public class Frame : IDisposable
```

## Remarks
A Frame consists of three vectors at a base point in 3D space.
 The vectors need not be orthogonal, have unit length, or even be linearly
 independent, although in practice Frames will usually have linearly
 independent vectors.
 Frames may be used to represent a coordinate frame of reference,
 a moving frame field on a curve, or for other purposes.

