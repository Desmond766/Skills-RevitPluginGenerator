---
kind: event
id: E:Autodesk.Revit.UI.UIControlledApplication.TransferringProjectStandards
source: html/4c9b9e55-9805-a1ef-bcf9-37687fca3217.htm
---
# Autodesk.Revit.UI.UIControlledApplication.TransferringProjectStandards Event

Subscribe to the TransferringProjectStandards event to be notified before the scope of an impending Transfer Project Standards operation has been finalized in the Transfer Project Standards dialog.

## Syntax (C#)
```csharp
public event EventHandler<TransferringProjectStandardsEventArgs> TransferringProjectStandards
```

## Remarks
This event allows an external application to add additional items to the possible list of items to be transferred.
 These items will be visible and selectable in the Transfer Project Standards dialog box. By default, new items added in this manner will be enabled for transfer.
 During the scope of this event, modification is not permitted to either the source or target documents. And this event is not cancellable.

