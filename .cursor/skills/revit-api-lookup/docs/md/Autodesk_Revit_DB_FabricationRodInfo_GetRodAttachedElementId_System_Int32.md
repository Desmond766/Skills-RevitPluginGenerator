---
kind: method
id: M:Autodesk.Revit.DB.FabricationRodInfo.GetRodAttachedElementId(System.Int32)
source: html/05e88086-4c9a-aa3e-316d-9eaa1c19cb93.htm
---
# Autodesk.Revit.DB.FabricationRodInfo.GetRodAttachedElementId Method

Gets the identifier of the attached component for the specified rod.

## Syntax (C#)
```csharp
public LinkElementId GetRodAttachedElementId(
	int rodIndex
)
```

## Parameters
- **rodIndex** (`System.Int32`) - The index of the specified rod.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - the index rodIndex is should be in range of rod count.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The rods do not attached to any structue.

