---
kind: method
id: M:Autodesk.Revit.UI.Events.TransferringProjectStandardsEventArgs.SetExternalItems(System.Collections.Generic.IDictionary{System.Guid,System.String})
source: html/895aa402-927e-ba70-1b12-4bebe3935533.htm
---
# Autodesk.Revit.UI.Events.TransferringProjectStandardsEventArgs.SetExternalItems Method

Sets the collection of externally added items which should be shown in the Transfer Project Standards dialog as options.

## Syntax (C#)
```csharp
public void SetExternalItems(
	IDictionary<Guid, string> externalItems
)
```

## Parameters
- **externalItems** (`System.Collections.Generic.IDictionary < Guid , String >`) - The external items which are displayed in the Transfer Project Standards UI.
 GUIDvalue is used to identify the external item string.

## Remarks
The externally added items that the user opted to transfer will be reported in the args to the TransferredProjectStandards event.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

