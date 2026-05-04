---
kind: type
id: T:Autodesk.Revit.UI.IExternalEventHandler
source: html/f265a2c9-8540-9c97-9b37-4f7442becac2.htm
---
# Autodesk.Revit.UI.IExternalEventHandler

An interface to be executed when an external event is raised.

## Syntax (C#)
```csharp
public interface IExternalEventHandler
```

## Remarks
An instance of a class implementing this interface will be registered
 with Revit first, and every time the corresponding external event
 is raised, the Execute method of this interface will be invoked.

