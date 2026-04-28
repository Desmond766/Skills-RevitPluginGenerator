---
kind: property
id: P:Autodesk.Revit.DB.Structure.FabricSheetType.MajorDirectionWireType
source: html/bdf9641d-5810-e238-1dd4-42c127a9477e.htm
---
# Autodesk.Revit.DB.Structure.FabricSheetType.MajorDirectionWireType Property

The id of the FabricWireType to be used in the major direction.

## Syntax (C#)
```csharp
public ElementId MajorDirectionWireType { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: the ElementId majorDirectionWireType is either invalid or not a FabricWireType.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property: Fabric Sheet Type is Custom

