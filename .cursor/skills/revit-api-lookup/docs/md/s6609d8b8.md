---
kind: property
id: P:Autodesk.Revit.DB.FabricationPart.InsulationSpecification
source: html/14c6d5cc-472e-c053-b676-5980f1ef56de.htm
---
# Autodesk.Revit.DB.FabricationPart.InsulationSpecification Property

The fabrication part insulation specification identifier.

## Syntax (C#)
```csharp
public int InsulationSpecification { get; set; }
```

## Remarks
A value of 0 indicates the insulation specification is set to off.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: the insulation specification is invalid for the fabrication part.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - -or-
 When setting this property: the fabrication part has taps connected.
 -or-
 When setting this property: the specification fails to be set by identifier: specId.

