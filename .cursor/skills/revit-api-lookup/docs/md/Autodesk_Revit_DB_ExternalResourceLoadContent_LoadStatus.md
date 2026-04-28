---
kind: property
id: P:Autodesk.Revit.DB.ExternalResourceLoadContent.LoadStatus
source: html/a6442d68-17c4-aeb1-0e40-d5077936c9cd.htm
---
# Autodesk.Revit.DB.ExternalResourceLoadContent.LoadStatus Property

A value to indicate the status of an external resource load operation. IExternalResourceServers
 should set this in the LoadResource() method.

## Syntax (C#)
```csharp
public ExternalResourceLoadStatus LoadStatus { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: The ExternalResourceLoadContent does not contain all the necessary
 data. To see the requirements for this particular resource type,
 please see the documentation for the specific subclass of
 ExternalResourceLoadContent.
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: A value passed for an enumeration argument is not a member of that enumeration

