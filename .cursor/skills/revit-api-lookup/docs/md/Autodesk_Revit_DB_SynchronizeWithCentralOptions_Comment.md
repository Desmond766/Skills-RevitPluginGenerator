---
kind: property
id: P:Autodesk.Revit.DB.SynchronizeWithCentralOptions.Comment
source: html/69f35c0d-2570-8f9d-9518-172b9a22f077.htm
---
# Autodesk.Revit.DB.SynchronizeWithCentralOptions.Comment Property

User description of changes made since the last Sync with Central. Empty by default.

## Syntax (C#)
```csharp
public string Comment { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: comment has more than 30,000 characters.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

