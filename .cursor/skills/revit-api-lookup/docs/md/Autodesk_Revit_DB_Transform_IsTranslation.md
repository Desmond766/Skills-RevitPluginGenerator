---
kind: property
id: P:Autodesk.Revit.DB.Transform.IsTranslation
zh: 变换
source: html/cc5067ec-8f08-a8cd-bdd9-88c10e17a08d.htm
---
# Autodesk.Revit.DB.Transform.IsTranslation Property

**中文**: 变换

The boolean value that indicates whether this transformation is a translation.

## Syntax (C#)
```csharp
public bool IsTranslation { get; }
```

## Remarks
This property is true if the only effect of transformation is translation. It checks that the 
basis of the transform is identity. The translation vector may be zero (which would make this 
an identity transformation) or nonzero (which would make this a non-trivial translation).

