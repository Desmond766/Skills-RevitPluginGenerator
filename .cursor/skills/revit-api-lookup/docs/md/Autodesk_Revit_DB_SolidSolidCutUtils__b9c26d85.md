---
kind: type
id: T:Autodesk.Revit.DB.SolidSolidCutUtils
source: html/f1a2d176-2ab6-fa4c-293e-970c5866e87c.htm
---
# Autodesk.Revit.DB.SolidSolidCutUtils

Exposes utilities which can cause one solid to cut another.

## Syntax (C#)
```csharp
public static class SolidSolidCutUtils
```

## Remarks
These utilities are applicable for the generic forms, geometry combinations and family instances in conceptual model,
 pattern based curtain panel, or adaptive component families, and family instances which are permitted to participate in
 joining in projects. Thus, for example, a beam cannot cut a wall (as the wall is not a family instance) in projects. Nor
 can a steel beam participate in cutting another family (because steel beams do not participate in joining).

