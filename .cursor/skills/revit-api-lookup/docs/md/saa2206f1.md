---
kind: property
id: P:Autodesk.Revit.DB.Structure.FabricArea.FabricSheetTypeId
source: html/1cf0d022-cc11-723b-88ee-6521b3700b29.htm
---
# Autodesk.Revit.DB.Structure.FabricArea.FabricSheetTypeId Property

The id of the Fabric Sheet Type for this element.

## Syntax (C#)
```csharp
public ElementId FabricSheetTypeId { get; set; }
```

## Remarks
Changing the value of this property causes change of MinorLapSplice and MajorLapSplice properties if needed

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: fabricSheetTypeId is not a Fabric Sheet Type.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

