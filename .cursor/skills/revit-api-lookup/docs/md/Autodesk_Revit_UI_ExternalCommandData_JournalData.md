---
kind: property
id: P:Autodesk.Revit.UI.ExternalCommandData.JournalData
source: html/bb189da3-216c-3c59-dff4-cdd63c27d4f1.htm
---
# Autodesk.Revit.UI.ExternalCommandData.JournalData Property

A data map that can be used to read and write data to the Autodesk Revit journal file.

## Syntax (C#)
```csharp
public IDictionary<string, string> JournalData { get; set; }
```

## Remarks
The data map is a string to string map that can be used to store data in the Revit journal
file at the end of execution of the external command. If the command is then executed from the journal
file during playback this data is then passed to the external command in this Data property so the
external command can execute with this passed data in a UI-less mode, hence providing non interactive
journal playback for automated testing purposes. For more information on Revit's journaling features
contact the Autodesk Developer Network.

