---
kind: property
id: P:Autodesk.Revit.DB.Transform2D.IsTranslation
source: html/5beef120-3918-7a2e-3ec4-d20445899e40.htm
---
# Autodesk.Revit.DB.Transform2D.IsTranslation Property

The boolean value that indicates whether this transformation is a translation.

## Syntax (C#)
```csharp
public bool IsTranslation { get; }
```

## Remarks
This property is true if the only effect of transformation is translation.
 It checks that the linear part of the transform is identity. The translation vector may be zero
 (which would make this an identity transformation) or nonzero (which would make this a non-trivial translation).

