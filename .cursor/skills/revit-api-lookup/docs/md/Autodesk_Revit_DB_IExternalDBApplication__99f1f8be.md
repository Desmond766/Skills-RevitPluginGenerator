---
kind: type
id: T:Autodesk.Revit.DB.IExternalDBApplication
source: html/97318be3-45c4-d93b-ee7b-174fa80ab951.htm
---
# Autodesk.Revit.DB.IExternalDBApplication

An interface that supports addition of DB-level external applications to Revit, to subscribe to DB-level events and updaters.

## Syntax (C#)
```csharp
public interface IExternalDBApplication
```

## Remarks
DB-level applications are permitted to add DB-level events and updaters to the session. 
They cannot create or modify UI.

