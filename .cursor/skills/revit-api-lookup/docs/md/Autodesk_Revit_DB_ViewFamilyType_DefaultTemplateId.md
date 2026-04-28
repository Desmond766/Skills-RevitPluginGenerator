---
kind: property
id: P:Autodesk.Revit.DB.ViewFamilyType.DefaultTemplateId
source: html/0747cdc7-98e7-a8f5-92f4-6da70a0f8dec.htm
---
# Autodesk.Revit.DB.ViewFamilyType.DefaultTemplateId Property

The default template id assigned to this view type.

## Syntax (C#)
```csharp
public ElementId DefaultTemplateId { get; set; }
```

## Remarks
This value will be the view template for all newly created instances of this view type.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: val is not valid as a default template id.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

