---
kind: property
id: P:Autodesk.Revit.DB.Structure.FabricSheetType.Material
zh: 材质、材料
source: html/7d91df23-bddb-9052-f05d-782a3bb4e618.htm
---
# Autodesk.Revit.DB.Structure.FabricSheetType.Material Property

**中文**: 材质、材料

The id of the material assigned to wires.

## Syntax (C#)
```csharp
public ElementId Material { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: The sheetMaterial cannot map to a valid material element.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

