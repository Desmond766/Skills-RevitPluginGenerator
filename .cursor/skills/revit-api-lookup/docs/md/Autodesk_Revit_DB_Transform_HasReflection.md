---
kind: property
id: P:Autodesk.Revit.DB.Transform.HasReflection
zh: 变换
source: html/dbdbb5b6-157a-9b89-b9ee-03cf1fe4d58f.htm
---
# Autodesk.Revit.DB.Transform.HasReflection Property

**中文**: 变换

The boolean value that indicates whether this transformation produces reflection.

## Syntax (C#)
```csharp
public bool HasReflection { get; }
```

## Remarks
Reflection transformation changes the handedness of a coordinate system.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when this transformation is not conformal and the reflection is undefined.

