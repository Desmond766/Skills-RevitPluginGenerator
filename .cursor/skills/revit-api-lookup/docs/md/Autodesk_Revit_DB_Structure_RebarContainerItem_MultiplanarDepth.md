---
kind: property
id: P:Autodesk.Revit.DB.Structure.RebarContainerItem.MultiplanarDepth
source: html/6a44a37f-c914-9bcb-bcc8-18df3e69f159.htm
---
# Autodesk.Revit.DB.Structure.RebarContainerItem.MultiplanarDepth Property

For a multiplanar rebar, the depth of the instance.

## Syntax (C#)
```csharp
public double MultiplanarDepth { get; set; }
```

## Remarks
Applicable only when an instance of a RebarShape with
 a RebarShapeMultiplanarDefinition.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: multiplanarDepth must be positive.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This RebarContainerItem is not an instance of a multiplanar shape.

