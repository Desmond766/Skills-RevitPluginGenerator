---
kind: method
id: M:Autodesk.Revit.DB.FabricationPart.IsProductListEntryCompatibleSize(System.Int32)
source: html/f8d55767-6b19-dc5b-d58e-421f67e6affe.htm
---
# Autodesk.Revit.DB.FabricationPart.IsProductListEntryCompatibleSize Method

Checks to see if this part can be changed to the specified product entry without altering any connected dimensions.

## Syntax (C#)
```csharp
public bool IsProductListEntryCompatibleSize(
	int productEntry
)
```

## Parameters
- **productEntry** (`System.Int32`) - The product entry index.

## Returns
Returns true if the part can be changed to the specified product entry without altering any connected dimensions.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The product entry index is not larger than 0 and less than GetProductCount.

