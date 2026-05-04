---
kind: method
id: M:Autodesk.Revit.DB.FabricationPart.GetDimensionValue(Autodesk.Revit.DB.FabricationDimensionDefinition)
source: html/f50c781c-34b8-65c6-f007-bc17e85e8b1c.htm
---
# Autodesk.Revit.DB.FabricationPart.GetDimensionValue Method

Gets the value of the fabrication dimension, returns value in Revit internal units.

## Syntax (C#)
```csharp
public double GetDimensionValue(
	FabricationDimensionDefinition dim
)
```

## Parameters
- **dim** (`Autodesk.Revit.DB.FabricationDimensionDefinition`) - The fabrication dimension.

## Returns
The dimension value.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

