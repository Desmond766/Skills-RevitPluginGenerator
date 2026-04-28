---
kind: property
id: P:Autodesk.Revit.DB.Dimension.AreReferencesAvailable
zh: 尺寸标注、标注
source: html/cdfc60a1-dd37-9428-6b47-d94870801559.htm
---
# Autodesk.Revit.DB.Dimension.AreReferencesAvailable Property

**中文**: 尺寸标注、标注

Indicates if this dimension's references can be resolved.

## Syntax (C#)
```csharp
public bool AreReferencesAvailable { get; }
```

## Remarks
This property always returns true for model dimensions.
 It can return false for view-specific dimensions that can lose their
 references in certain situations. For example, the host element
 references may not be available when the view containing the
 dimension is closed. In general, if the host element view-specific
 geometry is not available, dimensions that reference that geometry
 will not be able to resolve their references.

