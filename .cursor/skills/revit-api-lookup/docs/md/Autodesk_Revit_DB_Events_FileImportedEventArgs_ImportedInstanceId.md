---
kind: property
id: P:Autodesk.Revit.DB.Events.FileImportedEventArgs.ImportedInstanceId
source: html/3966f998-181c-c215-d7c3-2c0abeba879d.htm
---
# Autodesk.Revit.DB.Events.FileImportedEventArgs.ImportedInstanceId Property

The ElementId of the imported instance that represents the imported object(s) after a successful import.
 It could be used for further manipulation of that instance.

## Syntax (C#)
```csharp
public ElementId ImportedInstanceId { get; }
```

## Remarks
The value could be InvalidElementId for some type of import formats, such as GBXML and Inventor files.

