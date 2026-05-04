---
kind: property
id: P:Autodesk.Revit.DB.Structure.RebarShapeConstraintAngleFromFixedDir.Sign
source: html/bb429dd4-600e-777b-4c03-94cf6390d9d5.htm
---
# Autodesk.Revit.DB.Structure.RebarShapeConstraintAngleFromFixedDir.Sign Property

When the sign is 1, the Direction is rotated clockwise by the angle's value.
 When -1, the Direction is rotated counter-clockwise.

## Syntax (C#)
```csharp
public int Sign { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: sign is not 1 or -1.

