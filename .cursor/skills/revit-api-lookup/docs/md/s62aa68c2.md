---
kind: property
id: P:Autodesk.Revit.DB.ElementBinding.Categories
source: html/ee40289c-c274-2c5d-def8-9ff211d06279.htm
---
# Autodesk.Revit.DB.ElementBinding.Categories Property

Retrieve or set the categories to which a parameter definition will be bound.

## Syntax (C#)
```csharp
public CategorySet Categories { get; set; }
```

## Remarks
The Categories property is used to set the categories to which the definition will
be bound when it is added to the document bindings. This property can also be read from existing
bindings to interrogate to which categories a parameter has been bound.

