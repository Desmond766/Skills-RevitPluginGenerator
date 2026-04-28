---
kind: method
id: M:Autodesk.Revit.ApplicationServices.ControlledApplication.IsJournalPlaying
source: html/dcba9ff3-519f-0d86-b759-36be74d3c666.htm
---
# Autodesk.Revit.ApplicationServices.ControlledApplication.IsJournalPlaying Method

Determines if the application is currently in journal playback mode.

## Syntax (C#)
```csharp
public bool IsJournalPlaying()
```

## Returns
true if a journal is currently playing back, false otherwise.

## Remarks
Determines if Revit is in the process of playing back a journal. It can be
 used to help prevent any user interaction that may cause issues during playback.
 For more information on Revit's journaling features contact the Autodesk Developer Network.

