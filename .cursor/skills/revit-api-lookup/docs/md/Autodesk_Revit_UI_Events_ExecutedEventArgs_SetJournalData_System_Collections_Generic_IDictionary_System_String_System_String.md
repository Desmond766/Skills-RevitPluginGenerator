---
kind: method
id: M:Autodesk.Revit.UI.Events.ExecutedEventArgs.SetJournalData(System.Collections.Generic.IDictionary{System.String,System.String})
source: html/5c274484-2617-79e2-8593-9af4c70f8a59.htm
---
# Autodesk.Revit.UI.Events.ExecutedEventArgs.SetJournalData Method

Sets the journal data associated to this command (on journal playback).

## Syntax (C#)
```csharp
public void SetJournalData(
	IDictionary<string, string> data
)
```

## Parameters
- **data** (`System.Collections.Generic.IDictionary < String , String >`)

## Remarks
For details about the use of journal data associated to a command, see ExternalCommandData.JournalData.

