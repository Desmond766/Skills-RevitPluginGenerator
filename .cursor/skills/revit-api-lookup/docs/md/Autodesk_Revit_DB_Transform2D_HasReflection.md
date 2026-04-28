---
kind: property
id: P:Autodesk.Revit.DB.Transform2D.HasReflection
source: html/9646b8fb-5ab4-8959-1660-4e3624c6d847.htm
---
# Autodesk.Revit.DB.Transform2D.HasReflection Property

The boolean value that indicates whether this transformation produces reflection (i.e., is orientation-reversing).

## Syntax (C#)
```csharp
public bool HasReflection { get; }
```

## Remarks
Reflection transformation changes the handedness of a coordinate system.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This transformation is singular and the reflection is undefined.

