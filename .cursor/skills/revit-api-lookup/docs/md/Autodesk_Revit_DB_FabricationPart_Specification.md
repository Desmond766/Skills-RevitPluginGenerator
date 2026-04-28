---
kind: property
id: P:Autodesk.Revit.DB.FabricationPart.Specification
source: html/dcdced16-7def-0961-ff5b-bb4652d14aa9.htm
---
# Autodesk.Revit.DB.FabricationPart.Specification Property

The fabrication part specification identifier.

## Syntax (C#)
```csharp
public int Specification { get; set; }
```

## Remarks
A value of 0 indicates the specification is set to undefined.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: the specification is invalid for the fabrication part.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property: the specification is not able to be modified.
 -or-
 When setting this property: the fabrication part is connected to more than one item.
 -or-
 When setting this property: the specification fails to be set by identifier: specId.

