---
kind: property
id: P:Autodesk.Revit.DB.Structure.FabricSheetType.MinorDirectionWireType
source: html/963f96c5-6e30-3dd7-1fa6-a31a6cee9856.htm
---
# Autodesk.Revit.DB.Structure.FabricSheetType.MinorDirectionWireType Property

The id of the FabricWireType to be used in the minor direction.

## Syntax (C#)
```csharp
public ElementId MinorDirectionWireType { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: the ElementId minorDirectionWireType is either invalid or not a FabricWireType.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property: Fabric Sheet Type is Custom

