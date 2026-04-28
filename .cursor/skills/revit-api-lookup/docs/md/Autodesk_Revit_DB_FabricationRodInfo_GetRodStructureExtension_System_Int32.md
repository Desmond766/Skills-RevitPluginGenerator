---
kind: method
id: M:Autodesk.Revit.DB.FabricationRodInfo.GetRodStructureExtension(System.Int32)
source: html/59673418-04c3-797c-542c-00f542cf19da.htm
---
# Autodesk.Revit.DB.FabricationRodInfo.GetRodStructureExtension Method

Gets the length of the rod's top extension into structure.

## Syntax (C#)
```csharp
public double GetRodStructureExtension(
	int rodIndex
)
```

## Parameters
- **rodIndex** (`System.Int32`) - The rod index.

## Returns
Returns the extension length that will be applied if the rod is attached to structure.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - the index rodIndex is should be in range of rod count.

