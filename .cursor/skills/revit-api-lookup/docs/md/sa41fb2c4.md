---
kind: method
id: M:Autodesk.Revit.DB.Structure.FabricArea.IsValidMajorLapSplice(System.Double)
source: html/0dfb7466-d504-e38b-7c1b-9f1d2a2eb736.htm
---
# Autodesk.Revit.DB.Structure.FabricArea.IsValidMajorLapSplice Method

Identifies if the specified value is valid for use as a major lap splice.

## Syntax (C#)
```csharp
public bool IsValidMajorLapSplice(
	double majorLapSplice
)
```

## Parameters
- **majorLapSplice** (`System.Double`) - The major lap splice value.

## Returns
True if the value is valid, false if the value is invalid.

## Remarks
The major lap splice should be less than or equal to half of the overall length.

