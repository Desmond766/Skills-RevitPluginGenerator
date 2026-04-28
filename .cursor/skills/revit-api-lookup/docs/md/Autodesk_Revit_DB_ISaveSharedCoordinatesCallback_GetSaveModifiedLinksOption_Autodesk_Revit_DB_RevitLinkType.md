---
kind: method
id: M:Autodesk.Revit.DB.ISaveSharedCoordinatesCallback.GetSaveModifiedLinksOption(Autodesk.Revit.DB.RevitLinkType)
source: html/e18771f3-0861-b58b-544b-972a1ae6a02b.htm
---
# Autodesk.Revit.DB.ISaveSharedCoordinatesCallback.GetSaveModifiedLinksOption Method

Determines whether Revit should save the link, not save the link,
 or discard shared positioning entirely.

## Syntax (C#)
```csharp
SaveModifiedLinksOptions GetSaveModifiedLinksOption(
	RevitLinkType link
)
```

## Parameters
- **link** (`Autodesk.Revit.DB.RevitLinkType`) - The Revit link which has modified shared coordinates.

## Returns
The options when saving a linked file which has been modified
 in-memory by shared coordinates operations.

