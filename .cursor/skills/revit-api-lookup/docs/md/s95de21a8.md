---
kind: property
id: P:Autodesk.Revit.DB.FabricationPart.ProductListEntry
source: html/8eff34e6-45d3-5840-5d4b-77ce6a4b0125.htm
---
# Autodesk.Revit.DB.FabricationPart.ProductListEntry Property

The product entry index of the fabrication part. A value of -1 indicates the fabrication part is not a product list.

## Syntax (C#)
```csharp
public int ProductListEntry { get; set; }
```

## Remarks
The product list is a catalog of available sizes for the part and the index refers to the entry on this list.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: modifying the product entry will cause the dimensions of connected ends to change.
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: The product entry index is not larger than 0 and less than GetProductCount.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property: 
 -or-
 When setting this property: the product entry fails to be set by index: productEntryIndex.

