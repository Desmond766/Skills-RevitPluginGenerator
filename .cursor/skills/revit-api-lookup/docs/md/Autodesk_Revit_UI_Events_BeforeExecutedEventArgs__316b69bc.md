---
kind: type
id: T:Autodesk.Revit.UI.Events.BeforeExecutedEventArgs
source: html/fa2b2985-1b98-420c-556a-3888b7929a5a.htm
---
# Autodesk.Revit.UI.Events.BeforeExecutedEventArgs

The event arguments used by AddInCommandBinding's BeforeExecuted event.

## Syntax (C#)
```csharp
public class BeforeExecutedEventArgs : CommandEventArgs
```

## Remarks
This event is cancellable. If your callback sets the Cancel property to true, the command will not execute.

