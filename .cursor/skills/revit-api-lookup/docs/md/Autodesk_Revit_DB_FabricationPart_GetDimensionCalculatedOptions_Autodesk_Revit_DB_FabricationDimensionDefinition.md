---
kind: method
id: M:Autodesk.Revit.DB.FabricationPart.GetDimensionCalculatedOptions(Autodesk.Revit.DB.FabricationDimensionDefinition)
source: html/9e1165f6-5f6e-8280-8395-22ab98df3aab.htm
---
# Autodesk.Revit.DB.FabricationPart.GetDimensionCalculatedOptions Method

Gets the calculated options of the fabrication dimension.

## Syntax (C#)
```csharp
public IList<string> GetDimensionCalculatedOptions(
	FabricationDimensionDefinition dim
)
```

## Parameters
- **dim** (`Autodesk.Revit.DB.FabricationDimensionDefinition`) - The fabrication dimension.

## Returns
The calculated options of the fabrication dimension.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

