---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarInSystem.CanEditIndividualBars
source: html/f7753081-b760-9756-c38c-5cd214c4a768.htm
---
# Autodesk.Revit.DB.Structure.RebarInSystem.CanEditIndividualBars Method

Checks if individual bars can be moved, excluded or included.

## Syntax (C#)
```csharp
public bool CanEditIndividualBars()
```

## Returns
True if individual bars can be moved, excluded or included, false otherwise.

## Remarks
Individual bars can be moved, exlucded or included only for RebarInSystem that is owned by PathReinforcement. For RebarInSystem owned by AreaReinforcement these operations are not supported.

