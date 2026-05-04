---
kind: property
id: P:Autodesk.Revit.DB.Structure.BendingDetailCustomFieldProperties.LineStyleId
source: html/c691f2b9-dc2b-d123-8374-4a9e34d67059.htm
---
# Autodesk.Revit.DB.Structure.BendingDetailCustomFieldProperties.LineStyleId Property

Identifies the line style that is used for drawing Bending Detail curves.

## Syntax (C#)
```csharp
public ElementId LineStyleId { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: The lineStyleId should be an id of a line style.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

