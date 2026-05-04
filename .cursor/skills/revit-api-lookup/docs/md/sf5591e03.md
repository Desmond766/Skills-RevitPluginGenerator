---
kind: method
id: M:Autodesk.Revit.ApplicationServices.Application.PurgeReleasedAPIObjects
source: html/dea1a839-735e-e62f-a5b7-bb675e029112.htm
---
# Autodesk.Revit.ApplicationServices.Application.PurgeReleasedAPIObjects Method

Explicitly purges all API objects that have been released but are still awaiting to be finalized

## Syntax (C#)
```csharp
public void PurgeReleasedAPIObjects()
```

## Remarks
Revit purges API objects automatically every time when command control returns from
 an API application (an external command, event handler, etc.) back to Revit.
 This is necessary because Revit does not allow API objects to be finalized when the
 finalization is invoked from an outside thread (from the garbage collector, specifically).
 This automatic purging is adequate in most scenarios. When an application uses a lot
 of API objects during one single command though, it may be necessary or beneficial
 to invoke an additional purge explicitly to free the deleted API objects from memory.

