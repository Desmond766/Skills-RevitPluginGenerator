---
kind: property
id: P:Autodesk.Revit.DB.Events.DocumentReloadedLatestEventArgs.Location
source: html/d7619ab0-cad6-42f9-4092-bb047a45cce9.htm
---
# Autodesk.Revit.DB.Events.DocumentReloadedLatestEventArgs.Location Property

Full path of the central model which is to be operated.

## Syntax (C#)
```csharp
public string Location { get; set; }
```

## Remarks
For C4R model, it looks like 'Autodesk Docs://My project/my model.rvt'.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

