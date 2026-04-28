---
kind: method
id: M:Autodesk.Revit.DB.FabricationRodInfo.SetBearerExtension(System.Int32,System.Double)
source: html/e2b31b5c-5edf-2f96-91cc-15af3a31c878.htm
---
# Autodesk.Revit.DB.FabricationRodInfo.SetBearerExtension Method

Sets the bearer extension. The method is applicable only for bearer hanger.

## Syntax (C#)
```csharp
public void SetBearerExtension(
	int rodIndex,
	double length
)
```

## Parameters
- **rodIndex** (`System.Int32`) - The index of the rod.
- **length** (`System.Double`) - The new length of bearer extension.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - the index rodIndex is should be in range of rod count.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The hanger is not a bearer hanger.

