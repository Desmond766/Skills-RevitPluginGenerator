---
kind: event
id: E:Autodesk.Revit.UI.UIControlledApplication.TransferredProjectStandards
source: html/82af10d1-5ebf-526d-0dbd-e5ea2270f944.htm
---
# Autodesk.Revit.UI.UIControlledApplication.TransferredProjectStandards Event

Subscribe to the TransferredProjectStandards event to be notified after the scope of a Transfer Project Standards operation has been finalized.

## Syntax (C#)
```csharp
public event EventHandler<TransferredProjectStandardsEventArgs> TransferredProjectStandards
```

## Remarks
This event is raised just after the native Revit items have been transferred, but before the transaction has been committed.
 An add-in that registered external items in TransferringProjectStandards should subscribe to this event to carry out the transfer of any items that it registered if the user enabled those items for transfer.
 During the scope of this event, modification is permitted to the target document and modification is not permitted to the source document.

