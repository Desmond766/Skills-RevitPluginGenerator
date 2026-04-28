---
kind: type
id: T:Autodesk.Revit.Exceptions.BackgroundTaskCancelledException
source: html/656ff28c-486a-49ea-69e7-53ce76f75567.htm
---
# Autodesk.Revit.Exceptions.BackgroundTaskCancelledException

The exception thrown when Revit cancels a background operation. Third-party 
developers are not expected to catch and handle this exception. Instead, if allowed
to propagate back to Revit code, it will be handled by Revit.

## Syntax (C#)
```csharp
[SerializableAttribute]
public class BackgroundTaskCancelledException : ApplicationException
```

