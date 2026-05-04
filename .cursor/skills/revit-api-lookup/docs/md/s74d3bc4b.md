---
kind: property
id: P:Autodesk.Revit.ApplicationServices.ControlledApplication.RecordingJournalFilename
source: html/b51d0c47-7fd5-8c95-b99d-5456b5b97bc3.htm
---
# Autodesk.Revit.ApplicationServices.ControlledApplication.RecordingJournalFilename Property

Retrieve the name of the journal file the Revit is currently recording to.

## Syntax (C#)
```csharp
public string RecordingJournalFilename { get; }
```

## Remarks
As Revit operates it keeps a log of operations that the user performs 
within a file, known as a journal file. These files provide information
about the actions performed in a session and the state of Revit when a problem occurs.
These files are included during error reporting to Autodesk.

