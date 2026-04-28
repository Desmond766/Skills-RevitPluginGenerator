---
kind: property
id: P:Autodesk.Revit.ApplicationServices.Application.RecordingJournalFilename
source: html/531f5436-59e0-6df4-eb86-8ba093bf282c.htm
---
# Autodesk.Revit.ApplicationServices.Application.RecordingJournalFilename Property

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

