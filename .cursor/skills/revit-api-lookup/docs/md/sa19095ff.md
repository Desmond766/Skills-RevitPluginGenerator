---
kind: method
id: M:Autodesk.Revit.DB.Events.FailuresProcessingEventArgs.SetProcessingResult(Autodesk.Revit.DB.FailureProcessingResult)
source: html/8c50ec1e-1709-1d01-994a-079a05ed6fcb.htm
---
# Autodesk.Revit.DB.Events.FailuresProcessingEventArgs.SetProcessingResult Method

Sets the result of the failures processing accomplished during this event callback.

## Syntax (C#)
```csharp
public void SetProcessingResult(
	FailureProcessingResult result
)
```

## Parameters
- **result** (`Autodesk.Revit.DB.FailureProcessingResult`) - The result.

## Remarks
If this value is not explicitly set, the default value (Continue) will be used. If the event callback
 is resolving errors explicitly, it must be set to ProceedWithCommit - see the remarks for the
 FailuresProcessingEventArgs object for more details. Note that ProceedWithCommit should not be set if the handler has not resolved any errors - the
 handler will be called again as a result of the commit request and Revit failure handling will
 never be reached. Setting this result may not affect the outcome if other observers of the event are invoked after this one.
 The most prohibitive result set by all handlers will be used.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

