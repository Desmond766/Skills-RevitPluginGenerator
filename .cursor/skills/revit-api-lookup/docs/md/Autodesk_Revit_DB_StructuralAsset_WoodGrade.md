---
kind: property
id: P:Autodesk.Revit.DB.StructuralAsset.WoodGrade
source: html/a98aaea3-ed08-8e83-3e2c-0a3dfd59a3f6.htm
---
# Autodesk.Revit.DB.StructuralAsset.WoodGrade Property

The grade of wood used in a wood-based asset.

## Syntax (C#)
```csharp
public string WoodGrade { get; set; }
```

## Remarks
Applies to wood-based structural assets.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null
- **Autodesk.Revit.Exceptions.InapplicableDataException** - When setting this property: the material type must be wood to set this property.

