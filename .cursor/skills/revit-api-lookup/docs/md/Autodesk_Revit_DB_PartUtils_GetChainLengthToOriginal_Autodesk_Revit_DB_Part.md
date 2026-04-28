---
kind: method
id: M:Autodesk.Revit.DB.PartUtils.GetChainLengthToOriginal(Autodesk.Revit.DB.Part)
source: html/be9f42c2-7db1-4c6b-5d93-1263bf16f02e.htm
---
# Autodesk.Revit.DB.PartUtils.GetChainLengthToOriginal Method

Calculates the length of the longest chain of divisions/merges to reach to an original non-Part element that is the source of the tested part.

## Syntax (C#)
```csharp
public static int GetChainLengthToOriginal(
	Part part
)
```

## Parameters
- **part** (`Autodesk.Revit.DB.Part`) - The part to be tested

## Returns
The length of the longest chain.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

