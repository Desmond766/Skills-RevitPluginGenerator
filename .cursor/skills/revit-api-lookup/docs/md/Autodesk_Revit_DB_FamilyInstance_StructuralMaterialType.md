---
kind: property
id: P:Autodesk.Revit.DB.FamilyInstance.StructuralMaterialType
zh: 族实例
source: html/042b7922-53d9-d0ee-2f57-ce32cf5c5e4e.htm
---
# Autodesk.Revit.DB.FamilyInstance.StructuralMaterialType Property

**中文**: 族实例

This property returns the physical material from which the instance is made.

## Syntax (C#)
```csharp
public StructuralMaterialType StructuralMaterialType { get; }
```

## Remarks
Values of this property can be Steel, Concrete, Wood or some other material.
Different from Revit materials that geometry really consists of, this property is a family parameter
defining family behavior and can not be set per instance. Its value is the same with the type of the 
instance's family. For example, the instances of different kind of column families(Steel, Concrete or 
Wood) have different material values and can't be changed int the UI or RevitAPI.

