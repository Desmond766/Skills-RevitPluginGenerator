---
kind: method
id: M:Autodesk.Revit.DB.Frame.IsRightHanded
source: html/9a9727f4-270c-f6b0-60ce-482889e15213.htm
---
# Autodesk.Revit.DB.Frame.IsRightHanded Method

Determine if this frame's basis is right-handed.

## Syntax (C#)
```csharp
public bool IsRightHanded()
```

## Returns
True if this frame's basis is right-handed, false if not.

## Remarks
The three basis vectors are "right-handed" if the triple vector product [vecX, vecY, vecZ]
 is positive, or equivalently if dot(vecX x vecY, vecZ) is positive, where "dot" represents the dot product.

