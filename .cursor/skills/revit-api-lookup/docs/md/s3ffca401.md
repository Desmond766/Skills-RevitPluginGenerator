---
kind: property
id: P:Autodesk.Revit.DB.FloorType.StructuralMaterialId
source: html/32e9a9f7-5d15-2391-c794-c038bc657f7d.htm
---
# Autodesk.Revit.DB.FloorType.StructuralMaterialId Property

Returns the identifier of the material that defines the element's structural analysis properties.

## Syntax (C#)
```csharp
public ElementId StructuralMaterialId { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property: the floor does not have a structural material

