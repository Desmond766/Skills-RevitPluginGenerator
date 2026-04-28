---
kind: property
id: P:Autodesk.Revit.DB.DirectShape.ApplicationDataId
source: html/e755cb13-e327-da62-5748-23b976c1bac0.htm
---
# Autodesk.Revit.DB.DirectShape.ApplicationDataId Property

A text string that identifies the data to the creating application.

## Syntax (C#)
```csharp
public string ApplicationDataId { get; set; }
```

## Remarks
The intended use is to enable the creating application to identify the native data that was the source of this DirectShape.
 However, the creating application may use any text string as appropriate for its purposes, or leave this property unset.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

