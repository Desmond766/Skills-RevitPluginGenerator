---
kind: method
id: M:Autodesk.Revit.DB.ISaveSharedCoordinatesCallbackForUnloadLocally.GetSaveModifiedLinksOptionForUnloadLocally(Autodesk.Revit.DB.RevitLinkType)
source: html/2c5e37e1-c298-8590-14d9-29b47f57fc09.htm
---
# Autodesk.Revit.DB.ISaveSharedCoordinatesCallbackForUnloadLocally.GetSaveModifiedLinksOptionForUnloadLocally Method

Determines whether Revit should save the link or not prior
 to unloading the link locally.

## Syntax (C#)
```csharp
SaveModifiedLinksOptionsForUnloadLocally GetSaveModifiedLinksOptionForUnloadLocally(
	RevitLinkType link
)
```

## Parameters
- **link** (`Autodesk.Revit.DB.RevitLinkType`) - The Revit link which has modified shared coordinates.

## Returns
The saving option when unloading locally a linked file which has been modified
 in-memory by shared coordinates operations.

