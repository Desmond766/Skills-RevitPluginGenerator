---
kind: method
id: M:Autodesk.Revit.DB.Events.ProgressChangedEventArgs.Cancel
source: html/bafd1603-f0db-4efb-e101-9fe0e3f33e85.htm
---
# Autodesk.Revit.DB.Events.ProgressChangedEventArgs.Cancel Method

Requests to cancel the progress bar's operation.

## Syntax (C#)
```csharp
public void Cancel()
```

## Remarks
Note that an operation may only be cancelled if its stage is
 'Unchanged' or if its stage is 'PositionChanged' and the 'Cancellable' property is 'true.'

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The operation cannot be cancelled.

