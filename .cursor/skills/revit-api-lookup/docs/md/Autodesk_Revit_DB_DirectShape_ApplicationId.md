---
kind: property
id: P:Autodesk.Revit.DB.DirectShape.ApplicationId
source: html/e4d69298-2138-d7f7-35eb-4519452a3438.htm
---
# Autodesk.Revit.DB.DirectShape.ApplicationId Property

A text string that identifies the creating application.

## Syntax (C#)
```csharp
public string ApplicationId { get; set; }
```

## Remarks
The creating application may use any text string as appropriate for its purposes, or leave this property unset.
 One option is to use Application.ActiveAddInId for a unique application id, or concatenate it with an application name for a more informative, but still unique id.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

