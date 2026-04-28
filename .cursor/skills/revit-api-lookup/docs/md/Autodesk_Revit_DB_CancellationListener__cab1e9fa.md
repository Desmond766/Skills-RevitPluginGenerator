---
kind: type
id: T:Autodesk.Revit.DB.CancellationListener
source: html/ca6ab020-ad9b-783d-f8f5-6a6a1382dbf0.htm
---
# Autodesk.Revit.DB.CancellationListener

Allows clients to poll the cancellation status of a background operation. Revit instantiates
 CancellationListener objects for internal background operation implementations only. As such,
 third-party developers are not expected to instantiate or handle CancellationListener objects.

## Syntax (C#)
```csharp
public class CancellationListener : IDisposable
```

