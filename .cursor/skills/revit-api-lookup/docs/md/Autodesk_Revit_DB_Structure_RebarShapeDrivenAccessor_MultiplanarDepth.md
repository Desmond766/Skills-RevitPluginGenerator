---
kind: property
id: P:Autodesk.Revit.DB.Structure.RebarShapeDrivenAccessor.MultiplanarDepth
source: html/28ff121c-c1a4-6598-f6f5-0b1411d866fd.htm
---
# Autodesk.Revit.DB.Structure.RebarShapeDrivenAccessor.MultiplanarDepth Property

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
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This RebarShapeDrivenAccessor is not an instance of a multiplanar shape.
 -or-
 This RebarShapeDrivenAccessor doesn't contain a valid rebar reference.

