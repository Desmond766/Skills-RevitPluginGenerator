---
kind: method
id: M:Autodesk.Revit.DB.FabricationRodInfo.SetRodLength(System.Int32,System.Double)
source: html/0a227101-3cee-9f7f-87fb-f86757c22fc1.htm
---
# Autodesk.Revit.DB.FabricationRodInfo.SetRodLength Method

Set the rod length of the hanger for the specified rod index, excluding top extension. The hanger must not be set to be auto-hosted.

## Syntax (C#)
```csharp
public bool SetRodLength(
	int rodIndex,
	double newLength
)
```

## Parameters
- **rodIndex** (`System.Int32`) - The rod index.
- **newLength** (`System.Double`)

## Returns
Returns true if it was successful otherwise false.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - the index rodIndex is should be in range of rod count.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The rod length cannot be set because the hanger is set to automatically host to other elements.

