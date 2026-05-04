---
kind: method
id: M:Autodesk.Revit.UI.Events.TransferredProjectStandardsEventArgs.GetSelectedExternalItems
source: html/681a3f49-d95e-5180-6ced-04061bd6ab27.htm
---
# Autodesk.Revit.UI.Events.TransferredProjectStandardsEventArgs.GetSelectedExternalItems Method

Gets the collection of externally added items that the user opted to enable for transfer in the Transfer Project Standards dialog.

## Syntax (C#)
```csharp
public IDictionary<Guid, string> GetSelectedExternalItems()
```

## Returns
External items user wants to transfer.

## Remarks
If more than one add-in has registered external items, this will report items enabled for transfer for all such add-ins. Add-ins should handle the transfer only for those items which they actually registered in the TransferringProjectStandards event.

