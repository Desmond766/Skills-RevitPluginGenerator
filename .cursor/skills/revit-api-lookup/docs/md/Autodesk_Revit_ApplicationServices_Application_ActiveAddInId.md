---
kind: property
id: P:Autodesk.Revit.ApplicationServices.Application.ActiveAddInId
source: html/08272796-d8b8-8122-c712-08b108184334.htm
---
# Autodesk.Revit.ApplicationServices.Application.ActiveAddInId Property

Retrieves the Id of the currently running external application.

## Syntax (C#)
```csharp
public AddInId ActiveAddInId { get; }
```

## Remarks
The application can be either a UI application, DB application, or an external command. If no addin is active, this property will return Nothing nullptr a null reference ( Nothing in Visual Basic) .
If an event handler is currently being executed, the returned value will be the Id of the application or command in which the event handler was registered.

