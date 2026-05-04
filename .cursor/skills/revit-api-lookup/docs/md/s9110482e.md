---
kind: method
id: M:Autodesk.Revit.DB.Structure.FabricArea.IsValidMinorLapSplice(System.Double)
source: html/604dc875-594e-1e63-4cc0-1fe22848b09d.htm
---
# Autodesk.Revit.DB.Structure.FabricArea.IsValidMinorLapSplice Method

Identifies if the specified value is valid for use as a minor lap splice.

## Syntax (C#)
```csharp
public bool IsValidMinorLapSplice(
	double minorLapSplice
)
```

## Parameters
- **minorLapSplice** (`System.Double`) - The minor lap splice value.

## Returns
True if the value is valid, false if the value is invalid.

## Remarks
The minor lap splice should be less than or equal to half of the overall width.

