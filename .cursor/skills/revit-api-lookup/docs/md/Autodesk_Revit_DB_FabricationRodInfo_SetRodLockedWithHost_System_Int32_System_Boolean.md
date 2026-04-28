---
kind: method
id: M:Autodesk.Revit.DB.FabricationRodInfo.SetRodLockedWithHost(System.Int32,System.Boolean)
source: html/77082f81-5eff-e5b6-edb0-11feded0e506.htm
---
# Autodesk.Revit.DB.FabricationRodInfo.SetRodLockedWithHost Method

Locks the rod with the host. The method is applicable only for bearer hanger.

## Syntax (C#)
```csharp
public void SetRodLockedWithHost(
	int rodIndex,
	bool locked
)
```

## Parameters
- **rodIndex** (`System.Int32`) - The index of the rod.
- **locked** (`System.Boolean`) - Locks the rod with the host.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - the index rodIndex is should be in range of rod count.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The hanger is not a bearer hanger.

