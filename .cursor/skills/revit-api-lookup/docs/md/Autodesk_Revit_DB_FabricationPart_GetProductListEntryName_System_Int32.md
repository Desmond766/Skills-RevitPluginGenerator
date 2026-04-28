---
kind: method
id: M:Autodesk.Revit.DB.FabricationPart.GetProductListEntryName(System.Int32)
source: html/3c769108-6b9e-96e8-98bf-7793098265cb.htm
---
# Autodesk.Revit.DB.FabricationPart.GetProductListEntryName Method

Gets the specified product list entry name.

## Syntax (C#)
```csharp
public string GetProductListEntryName(
	int index
)
```

## Parameters
- **index** (`System.Int32`) - The product entry index.

## Returns
Returns the specified product entry name.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The product entry index is not larger than 0 and less than GetProductCount.

