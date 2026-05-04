---
kind: method
id: M:Autodesk.Revit.DB.FabricationRodInfo.GetBearerExtension(System.Int32)
source: html/57999809-2894-24eb-d94b-fddeb16fd90e.htm
---
# Autodesk.Revit.DB.FabricationRodInfo.GetBearerExtension Method

Gets the bearer extension. The method is applicable only for bearer hanger.

## Syntax (C#)
```csharp
public double GetBearerExtension(
	int rodIndex
)
```

## Parameters
- **rodIndex** (`System.Int32`) - The index of the rod.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - the index rodIndex is should be in range of rod count.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The hanger is not a bearer hanger.

