---
kind: method
id: M:Autodesk.Revit.DB.FabricationRodInfo.SetRodStructureExtension(System.Int32,System.Double)
source: html/f07b84e8-0615-46bf-f38b-2361ec5f066b.htm
---
# Autodesk.Revit.DB.FabricationRodInfo.SetRodStructureExtension Method

Set the length of the rod's top extension into structure. The rod must be attached to structure.

## Syntax (C#)
```csharp
public bool SetRodStructureExtension(
	int rodIndex,
	double extension
)
```

## Parameters
- **rodIndex** (`System.Int32`) - The rod index.
- **extension** (`System.Double`) - Distance the rod will extend into the structure.

## Returns
Returns true if it was successful otherwise false.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - the index rodIndex is should be in range of rod count.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The rods do not attached to any structue.

