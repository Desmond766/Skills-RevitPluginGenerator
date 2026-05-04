---
kind: method
id: M:Autodesk.Revit.DB.FabricationRodInfo.IsRodLockedWithHost(System.Int32)
source: html/8908e152-46ef-6526-10aa-2f6afbe1a0aa.htm
---
# Autodesk.Revit.DB.FabricationRodInfo.IsRodLockedWithHost Method

Checks if the rod is locked with the host. The method is applicable only for bearer hanger.

## Syntax (C#)
```csharp
public bool IsRodLockedWithHost(
	int rodIndex
)
```

## Parameters
- **rodIndex** (`System.Int32`) - The index of the rod.

## Returns
True if the rod is locked with its host.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - the index rodIndex is should be in range of rod count.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The hanger is not a bearer hanger.

