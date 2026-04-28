---
kind: method
id: M:Autodesk.Revit.DB.FabricationRodInfo.GetRodEndPosition(System.Int32)
source: html/fce3a4b1-e029-5fd5-9f61-d389be460e03.htm
---
# Autodesk.Revit.DB.FabricationRodInfo.GetRodEndPosition Method

Gets the position of the rod end.

## Syntax (C#)
```csharp
public XYZ GetRodEndPosition(
	int rodIndex
)
```

## Parameters
- **rodIndex** (`System.Int32`) - The index of the rod.

## Returns
The position of the rod end.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - the index rodIndex is should be in range of rod count.

