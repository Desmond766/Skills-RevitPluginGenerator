---
kind: property
id: P:Autodesk.Revit.DB.SchedulableField.ParameterId
source: html/99e6189b-59e1-100d-cca6-d8eb5e7e917a.htm
---
# Autodesk.Revit.DB.SchedulableField.ParameterId Property

The ID of the parameter displayed by the field.

## Syntax (C#)
```csharp
public ElementId ParameterId { get; set; }
```

## Remarks
Most non-calculated field types require a parameter ID.
 The Count field doesn't have a parameter ID.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

