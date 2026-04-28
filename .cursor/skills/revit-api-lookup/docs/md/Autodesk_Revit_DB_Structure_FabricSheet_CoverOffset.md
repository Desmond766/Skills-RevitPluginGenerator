---
kind: property
id: P:Autodesk.Revit.DB.Structure.FabricSheet.CoverOffset
source: html/89e824ff-5721-78bf-ba75-9774852fa7e0.htm
---
# Autodesk.Revit.DB.Structure.FabricSheet.CoverOffset Property

The additional cover offset of the Fabric Sheet.

## Syntax (C#)
```csharp
public double CoverOffset { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: The given value for coverOffset is not a number
 -or-
 When setting this property: coverOffset is greater then the host thickness.
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: The given value for coverOffset must be between 0 and 30000 feet.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property:

